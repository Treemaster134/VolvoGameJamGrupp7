using System;
using UnityEngine;

public class Rullband : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform one;
   
    [SerializeField]private GameObject petfalska;
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!Physics2D.OverlapBox(one.position, Vector3.one * 0.1f, 0, 3))
        {
            Instantiate(petfalska, one.position, one.rotation);
            Debug.Log(petfalska);
        }
     
    }

    
}
