using System;
using Unity.VisualScripting;
using UnityEngine;

public class Goals : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private int GoalCost;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject GoalImage;
    private float percentage;
    private float wallet;
    private Vector2 originalSize;
    private bool won;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalSize = bar.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        wallet = score.Wallet;
        percentage = wallet / GoalCost;
       bar.transform.localScale = new Vector2(1 - percentage, originalSize.y);
       
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
            score.RemoveScore(GoalCost);
            won = true;
            Debug.Log("purchased");
        }
    }
}
