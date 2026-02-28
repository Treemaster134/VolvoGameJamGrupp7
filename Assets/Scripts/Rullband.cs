using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rullband : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform one;
   
    [SerializeField]public List<GameObject> pant;
    [SerializeField]private float WaitTime;
    private bool coroutineStarted;
    
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Physics2D.OverlapBox(one.position, Vector3.one, 0, 3));
        if (!Physics2D.OverlapBox(one.position, Vector3.one, 0, 3) && !coroutineStarted)
        {
            coroutineStarted = true;
           StartCoroutine(Instantiate());
        }

    }

    IEnumerator Instantiate()
    {
        yield return new WaitForSeconds(WaitTime);
        Instantiate(pant[0], one.position, one.rotation);
        coroutineStarted = false;
       
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
