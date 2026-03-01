using TMPro;
using UnityEngine;

public class StreakUpgrade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ScoreManager score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int upgradeCost;
    private UpgradeEnum upgrade;
    
    void Start()
    {
        upgrade = new UpgradeEnum();
        upgrade = UpgradeEnum.First;
        scoreText.text = $"{upgradeCost} kr";
    }

    void UpgradeStreak()
    {
        if (upgrade == UpgradeEnum.First)
        {
            score.UpgradeStreak(upgradeCost);
            scoreText.text = "Streak upgraded";
            upgrade = UpgradeEnum.Second;
            scoreText.text = $"{upgradeCost * 2} kr";
        }
        else if (upgrade == UpgradeEnum.Second)
        {
            score.UpgradeStreak(upgradeCost * 2);
            upgrade = UpgradeEnum.Third;
            scoreText.text = $"{upgradeCost * 3} kr";
        }
        else if (upgrade == UpgradeEnum.Third)
        {
            score.UpgradeStreak(upgradeCost * 3);
            upgrade = UpgradeEnum.Fourth;
            scoreText.text = $"SOLD OUT";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
