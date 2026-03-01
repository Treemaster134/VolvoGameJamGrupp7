using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottleUpgrade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject PantMachine; 
    [SerializeField] private ScoreManager score;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private int cost, multiplier;
    private UpgradeEnum upgrade;
    
    void Start()
    {
        price.text = $"{cost} kr";
        upgrade = new UpgradeEnum();
        upgrade = UpgradeEnum.First;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradePant()
    {
        if (score.Wallet >= cost && upgrade == UpgradeEnum.First)
        {
            score.RemoveScore(cost);
            PantMachine.GetComponent<MachineManager>().UpgradeMultiply *= multiplier;
            upgrade = UpgradeEnum.Second;
            price.text = $"{cost * 2} kr";
        }
        else if (score.Wallet >= cost * 2 && upgrade == UpgradeEnum.Second)
        {
            score.RemoveScore(cost * 2);
            PantMachine.GetComponent<MachineManager>().UpgradeMultiply *= multiplier;
            upgrade = UpgradeEnum.Third;
            price.text = $"{cost * 3} kr";
        }
        else if (score.Wallet >= cost * 3 && upgrade == UpgradeEnum.Third)
        {
            score.RemoveScore(cost * 3);
            PantMachine.GetComponent<MachineManager>().UpgradeMultiply *= multiplier;
            upgrade = UpgradeEnum.Fourth;
            gameObject.GetComponent<Image>().color = Color.gray;
            price.text = $"SOLD OUT";
        }
    }
}
