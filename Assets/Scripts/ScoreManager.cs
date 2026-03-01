using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private int upgradeCost;
    private int score;
	private int streak = 0;
	private float streakMultiplier = 1.0f;
	private float multChange = 0.1f;

	public int Wallet
	{
		get => score;
	}
	
	void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{score} kr";
    }

	public void AddScore(int value)
	{
		score += (int)(value * streakMultiplier);
		streak++;
	
		if(streak % 5 == 0)
		{
			streakMultiplier += multChange;
		}
	}

	public void RemoveScore(int cost)
	{
		score -= cost;
	}

	public void Miss(int value)
	{
		score -= value;
		streakMultiplier = 0.0f;
		streak = 0;
	}

	public void UpgradeStreak()
	{
		if (score >= upgradeCost)
		{
			multChange += 0.05f;
			score -= upgradeCost;
		}
	}
}
