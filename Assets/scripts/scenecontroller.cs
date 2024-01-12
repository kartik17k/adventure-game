using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scenecontroller : MonoBehaviour
{
    public static scenecontroller instances;

    private void Awake()
    {
        if (instances == null) {
            instances = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void nextLevel()
    {
        int x = SceneManager.GetActiveScene().buildIndex;

        if (x == 3)
        {
            SceneManager.LoadSceneAsync("level1");
            AudioManager.instance.Play("FinishPoint");
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.instance.Play("FinishPoint");
        }

    }

    public void loadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
}
