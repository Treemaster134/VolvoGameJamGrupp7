using System;
using UnityEngine;

public class Rullband : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform one;
    [SerializeField] private Transform two;
    [SerializeField] private Transform three;
    [SerializeField]private GameObject petfalska;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.OverlapBox(three.position, Vector3.one * 0.1f, 0))
        {
            Instantiate(petfalska, three.position, three.rotation);
        }
        
    }

    
}
