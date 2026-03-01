using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string acceptedPant;
    [SerializeField] private ScoreManager score;
    [SerializeField] private float bigTime;
    private float timer = 0;
    public int UpgradeMultiply;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(acceptedPant))
        {
            score.AddScore(other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply);
            Destroy(other.gameObject);
            while (timer <= bigTime)
            {
                Debug.Log("Inside Loop" + timer);
                timer += Time.deltaTime;
                gameObject.transform.localScale = new Vector3(2f,2f,2f);
            }
            Debug.Log("Out of Loop");
            gameObject.transform.localScale = new Vector3(1f,1f,1f);
            timer = 0;
        }
        else
        {
          score.Miss(other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply);
          Destroy(other.gameObject);
        }
    }
}
