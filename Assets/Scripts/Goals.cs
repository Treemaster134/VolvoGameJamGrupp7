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
            bar.transform.localScale = Vector3.one;
            won = false;
        }
        if (score.Wallet >= GoalCost)
        {
            bar.transform.localScale = Vector3.zero;
        }
    }
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
        if (score.Wallet >= GoalCost)
        {
            
            winCanvas.gameObject.SetActive(true);
            won = true;
        }

        

    }
}
