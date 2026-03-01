using TMPro;
using UnityEngine;

public class ScoreTextFlying : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (5 * Time.deltaTime);
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - Time.deltaTime);
        
        if(text.color.a <= 0.0f) {Destroy(gameObject);}
    }

    public void SetText(string t)
    {
        text.text = t;
    }
}
