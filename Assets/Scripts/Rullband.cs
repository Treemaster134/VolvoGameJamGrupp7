using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rullband : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform one;
   
    [SerializeField] public List<GameObject> pant;
    [SerializeField] private float WaitTime;
    [SerializeField] private LayerMask mask;
    private float timer = 3.0f;
    void Start()
    {
        timer = WaitTime;
    }

    void Update()
    {
        if (!Physics2D.OverlapBox(one.position, Vector3.one, 0, mask))
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                Instantiate(pant[UnityEngine.Random.Range(0, pant.Count)], one.position, one.rotation);
                timer = WaitTime;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (one != null)
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(one.position, Vector3.one);
        }
        
    }
}
