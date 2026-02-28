using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private TextMeshProUGUI scoreText;
    public float Score;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{Score} kr";
    }
}
