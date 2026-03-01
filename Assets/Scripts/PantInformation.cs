using UnityEngine;

[System.Serializable]
public class PantInformation : MonoBehaviour
{
    public int value;
    public ScoreManager score;

    void Update()
    {
        if (transform.position.x < -10.0f || transform.position.x > 10.0f || transform.position.y < -7.0f)
        {
            score.Miss(value);
            Destroy(gameObject);
        }
    }
}