using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class Rullband : MonoBehaviour
{
    [FormerlySerializedAs("one")] [SerializeField] private Transform spawnArea;
   
    public List<GameObject> Pant;
    [SerializeField] private float WaitTime;
    [SerializeField] private LayerMask mask;
    [SerializeField] private ScoreManager score;

    [Header("Animation")]
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float animationTime;
    [SerializeField] private Image prompt;

    private float animationProgress = 0.0f;
    private bool animationPromptTurnedOn = false;
    
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
                animationPromptTurnedOn = false;
                
                timer = WaitTime;
            }
        }

        if (animationProgress < animationTime && Physics2D.OverlapBox(spawnArea.position, Vector3.one, 0, mask))
        {
            animationProgress = Mathf.Min(animationProgress + Time.deltaTime, animationTime);
            spawnArea.localPosition = Vector3.Lerp(startPosition, endPosition, animationProgress / animationTime);
        }
        else if(animationPromptTurnedOn == false)
        {
            prompt.enabled = true;
            animationPromptTurnedOn = true;
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
