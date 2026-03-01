using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextImage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] List<GameObject> sprites;
    int currentIndex = 1;
    [SerializeField] int nextScene;

    public void Next()
    {
        if (currentIndex < sprites.Count)
        {
            if (currentIndex > 0)
            {
                sprites[currentIndex - 1].SetActive(false);
            }

            sprites[currentIndex].SetActive(true);
            currentIndex++;
        }
        else
        {
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Single);
        }
    }
}
