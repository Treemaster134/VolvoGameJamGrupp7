using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MachineUpgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] ScoreManager score;
   
    [Header("Pant")]
    [SerializeField] private GameObject storPET;
    [SerializeField]private GameObject metalCan;
    [SerializeField]private GameObject glassBottle;
    [SerializeField] private Rullband rullband;
    [SerializeField]private GameObject metalMachine, glassMachine;
    [SerializeField] TextMeshProUGUI price;
    [SerializeField] int cost;
    
    [Header("Button Unlocks")]
    [SerializeField] private GameObject SPButton;
    [SerializeField] private GameObject MPButton;
    [SerializeField] private GameObject GPButton;
    
    
    private UpgradeEnum upgrade;
    void Start()
    {
      upgrade = new UpgradeEnum();
      upgrade = UpgradeEnum.First;
      gameObject.GetComponent<Image>().color =  new Color(150, 201, 88);
      price.text = $"{cost} kr";
    }
    
    public void NewMachine()
    {
        if (upgrade == UpgradeEnum.First && score.Wallet >= cost)
        {
            score.RemoveScore(cost);
            rullband.Pant.Add(storPET);
            upgrade = UpgradeEnum.Second;
            gameObject.GetComponent<Image>().color =  new Color(252, 239, 134);
            price.text = $"{cost * 2} kr";
            
            SPButton.SetActive(true);
        }

        else if (upgrade == UpgradeEnum.Second && score.Wallet >= cost * 2)
        {
            score.RemoveScore(cost * 2);
            metalMachine.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            Debug.Log(metalMachine.gameObject.GetComponent<CircleCollider2D>().enabled);
            metalMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            upgrade = UpgradeEnum.Third;
            rullband.Pant.Add(metalCan);
            gameObject.GetComponent<Image>().color =  new Color(227, 145, 182);
            price.text = $"{cost * 3} kr";
            
            MPButton.SetActive(true);
        }

       else  if (upgrade == UpgradeEnum.Third && score.Wallet >= cost * 3)
        {
            score.RemoveScore(cost * 3);
            glassMachine.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            glassMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            rullband.Pant.Add(glassBottle);
            gameObject.GetComponent<Image>().color = Color.gray;
            price.text = $"SOLD OUT";
            upgrade = UpgradeEnum.Fourth;
            GPButton.SetActive(true);
        }
    }

    
}
