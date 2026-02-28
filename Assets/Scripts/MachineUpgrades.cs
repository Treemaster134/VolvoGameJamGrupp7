using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
    }
    
    public void NewMachine(int cost)
    {
        if (upgrade == UpgradeEnum.First && score.Score >= cost)
        {
            score.Score -= cost;
            rullband.Pant.Add(storPET);
            upgrade = UpgradeEnum.Second;
        }

        if (upgrade == UpgradeEnum.Second && score.Score >= cost)
        {
            score.Score -= cost;
            metalMachine.SetActive(true);
            metalMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            rullband.Pant.Add(metalCan);
        }

        if (upgrade == UpgradeEnum.Third && score.Score >= cost)
        {
            score.Score -= cost;
            glassMachine.SetActive(true);
            glassMachine.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            rullband.Pant.Add(glassBottle);
        }
    }
}
