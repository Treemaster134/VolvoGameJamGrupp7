using System;
using Unity.VisualScripting;
using UnityEngine;

public class MachineManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private string acceptedPant;
    [SerializeField] private float score;
    
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
            score += other.gameObject.GetComponent<PantInformation>().value;
        }
        else
        {
          score -= other.gameObject.GetComponent<PantInformation>().value;
        }
        throw new NotImplementedException();
    }
}
