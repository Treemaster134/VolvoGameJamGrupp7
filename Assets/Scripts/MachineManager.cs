using System;
using TMPro;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string acceptedPant;
    [SerializeField] private ScoreManager score;
    [SerializeField] private float bigTime;
    [SerializeField] private ParticleSystem moneyParticles;
    [SerializeField] private AudioClip moneySound;
    [SerializeField] private AudioClip acceptSound;
    [SerializeField] private AudioClip rejectSound;
    private AudioSource source;
    
    private float timer;
    private bool startTimer = false;
    public int UpgradeMultiply;
    
    void Start()
    {
        timer = bigTime;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            while (timer <= 0)
            {
                gameObject.transform.localScale = new Vector3(1f,1f,1f);
                startTimer = false;
                timer = bigTime;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(acceptedPant))
        {
            score.AddScore(other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply);
            moneyParticles.Play();
            moneyParticles.GetComponent<UIAudioManager>().PlaySound(moneySound);
            Destroy(other.gameObject);
            startTimer = true;
            source.clip = acceptSound;
        }
        else
        {
          score.Miss(other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply);
          Destroy(other.gameObject);
          source.clip = rejectSound;
        }
        
        source.Play();
    }
}
