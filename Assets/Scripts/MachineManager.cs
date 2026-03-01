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
            
            score.Score += other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply;
            Destroy(other.gameObject);
            
        }
        else
        {
          score.Score -= other.gameObject.GetComponent<PantInformation>().value * UpgradeMultiply;
          Destroy(other.gameObject);
        }
    }
}
