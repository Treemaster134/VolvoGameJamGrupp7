using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Rullband : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [FormerlySerializedAs("one")] [SerializeField] private Transform spawnArea;
   
    public List<GameObject> Pant;
    [SerializeField] private float WaitTime;
    [SerializeField] private LayerMask mask;
    [SerializeField] private ScoreManager score;

    [Header("Animation")]
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float animationTime;
    
    
    private Animator animator;
    private float timer = 3.0f;
    void Start()
    {
        timer = WaitTime;
        
    }

    void Update()
    {
        if (!Physics2D.OverlapBox(spawnArea.position, Vector3.one, 0, mask))
        {
            timer -= Time.deltaTime;

            if (timer <= 0.0f)
            {
                GameObject newPant = Instantiate(Pant[UnityEngine.Random.Range(0, Pant.Count)], spawnArea.position, spawnArea.rotation);
                newPant.GetComponent<PantInformation>().score = score;
                newPant.transform.parent = spawnArea;
                newPant.transform.localPosition = Vector3.zero;
                
                timer = WaitTime;
            }
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        if (spawnArea != null)
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireCube(spawnArea.position, Vector3.one);
        }
        
    }
}
