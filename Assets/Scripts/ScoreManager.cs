using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI scoreText;
    
    [SerializeField] private AudioSource positiveSource;
    [SerializeField] private AudioSource negativeSource;
    private int score;
	private int streak = 0;
	private float streakMultiplier = 1.0f;
	[FormerlySerializedAs("multChange")] public float MultChange = 0.1f;
	private bool playPositiveSound = false;
	private bool playNegativeSound = false;
	

	public int Wallet
	{
		get => score;
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
		    scoreText.text = $"{score / 1000.0f:F1}k kr";
	    }
	    else
	    {
		    scoreText.text = $"{score / 1000000.0f:F1}M kr";
	    }

	    if (playPositiveSound == true && !positiveSource.isPlaying)
	    {
		    playPositiveSound = false;
		    positiveSource.Play();
	    }
	    
	    if (playNegativeSound == true && !negativeSource.isPlaying)
	    {
		    playNegativeSound = false;
		    negativeSource.Play();
	    }
    }

	public void AddScore(int value)
	{
		score += (int)(value * streakMultiplier);
		streak++;
		if(streak % 3 == 0)
		{
			streakMultiplier += MultChange;
			playPositiveSound = true;
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
		playNegativeSound = true;
	}

	public void UpgradeStreak(int upgradeCost)
	{
		if (score >= upgradeCost)
		{
			MultChange += 0.05f;
			score -= upgradeCost;
		}
	}
}
