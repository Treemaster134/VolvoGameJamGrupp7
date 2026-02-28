using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MachineUpgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] ScoreManager score;
   
    [SerializeField] private GameObject storPET;
    [SerializeField]private GameObject metalCan;
    [SerializeField]private GameObject glassBottle;
    [SerializeField] private Rullband rullband;
    [SerializeField]private GameObject metalMachine, glassMachine;
    
    private UpgradeEnum upgrade;
    void Start()
    {
      upgrade = new UpgradeEnum();
      upgrade = UpgradeEnum.First;
      gameObject.GetComponent<Image>().color =  new Color(150, 201, 88);
    }
    
    public void NewMachine(int cost)
    {
        if (upgrade == UpgradeEnum.First && score.Score >= cost)
        {
            score.Score -= cost;
            rullband.Pant.Add(storPET);
            upgrade = UpgradeEnum.Second;
            glassMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            gameObject.GetComponent<Image>().color =  new Color(252, 239, 134);
            Debug.Log("upgrade");
        }

        else if (upgrade == UpgradeEnum.Second && score.Score >= cost * 2)
        {
            Debug.Log("Upgrade 2");
            score.Score -= cost;
            metalMachine.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            metalMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            upgrade = UpgradeEnum.Third;
            rullband.Pant.Add(metalCan);
            gameObject.GetComponent<Image>().color =  new Color(227, 145, 182);
        }

       else  if (upgrade == UpgradeEnum.Third && score.Score >= cost * 3)
        {Debug.Log("Upgrade 3");
            score.Score -= cost;
            glassMachine.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            glassMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            rullband.Pant.Add(glassBottle);
            gameObject.GetComponent<Image>().color = Color.gray;
        }
    }
}
