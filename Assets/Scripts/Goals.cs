using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Goals : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private int GoalCost;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject GoalImage;
    [SerializeField] private Canvas winCanvas;
    
    private float percentage;
    
    
    private bool won;
    
    
    void OnMouseEnter()
    {
        if (!won)
        {
            GoalImage.GetComponent<SpriteRenderer>().color = Color.gray;
        }
        
    }

    void OnMouseExit()
    {
        if (!won)
        {
            GoalImage.GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
    private void OnMouseDown()
    {
        if (score.Wallet >= GoalCost && won == false)
        {
            Destroy(bar);
            score.RemoveScore(GoalCost);
            won = true;
            
        }

        if (won)
        {
            winCanvas.gameObject.SetActive(true);
        }
    }
}
