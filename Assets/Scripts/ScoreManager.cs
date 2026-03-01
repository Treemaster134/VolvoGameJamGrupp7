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
	    if (score < 1000)
	    {
		    scoreText.text = $"{score} kr";
	    }
	    else if (score < 1000000)
	    {
		    scoreText.text = $"{score / 1000.0f:F3}k kr";
	    }
	    else
	    {
		    scoreText.text = $"{score / 1000000.0f:F3}M kr";
	    }
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

		if (score < 0)
		{
			score = 0;
		}
	}

	public void Miss(int value)
	{
		RemoveScore(value);
		streakMultiplier = 1.0f;
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
