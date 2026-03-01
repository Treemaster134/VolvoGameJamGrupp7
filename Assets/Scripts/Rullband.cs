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

    private float animationProgress = 0.0f;
    
    
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
                GameObject newPant = Instantiate(Pant[UnityEngine.Random.Range(0, Pant.Count)], spawnArea);
                newPant.GetComponent<PantInformation>().score = score;
                animationProgress = 0.0f;
                
                timer = WaitTime;
            }
        }

        if (animationProgress < animationTime)
        {
            animationProgress = Mathf.Min(animationProgress + Time.deltaTime, animationTime);
            spawnArea.localPosition = Vector3.Lerp(startPosition, endPosition, animationProgress / animationTime);
        }
        
        Debug.Log(animationProgress);
        
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
