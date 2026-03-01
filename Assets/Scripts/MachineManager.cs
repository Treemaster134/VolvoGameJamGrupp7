using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string acceptedPant;
    [SerializeField] private ScoreManager score;
    [SerializeField] private float bigTime;
    private float timer;
    private bool startTimer = false;
    public int UpgradeMultiply;
    
    void Start()
    {
        timer = bigTime;
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
            Destroy(other.gameObject);
            startTimer = true;
           
        }
        else
        {
          score.Miss(other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply);
          Destroy(other.gameObject);
        }
    }
}
