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

    void Update()
    {
        if (score.Wallet <= GoalCost && won)
        {
            bar.gameObject.SetActive(true);
            won = false;
        }
    }
    void OnMouseEnter()
    {
        if (!won)
        {
            GoalImage.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        if (score.Wallet >= GoalCost)
        {
            bar.gameObject.SetActive(false);
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
        if (score.Wallet >= GoalCost)
        {
            
            winCanvas.gameObject.SetActive(true);
            won = true;
        }

        

    }
}
