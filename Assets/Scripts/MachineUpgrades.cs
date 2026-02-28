using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MachineUpgrades : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] ScoreManager score;
    [SerializeField] List<float> cost;
    private UpgradeEnum upgrade;
    void Start()
    {
      upgrade = GetComponent<UpgradeEnum>();
      upgrade = UpgradeEnum.First;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void NewMachine(Transform Glass, Transform Metal)
    {
        if (upgrade == UpgradeEnum.First && score.Score >= cost[0])
        {
            score.Score -= cost[0];
            
        }
    }
}
