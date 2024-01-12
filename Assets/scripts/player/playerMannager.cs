using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;
public class playerMannager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;
    public GameObject pauseMenu;


    public static Vector2 lastCheckPoint = new Vector2(-3,0);
    public static int numOfCoin = 0;
    public TextMeshProUGUI cointext;

    public CinemachineVirtualCamera Vcam;

    public GameObject[] playerPrefabs;
    int charIndex;


    private void Awake()
    {
        charIndex = PlayerPrefs.GetInt("selectedCharacter", 0);
        GameObject player =  Instantiate(playerPrefabs[charIndex], lastCheckPoint, Quaternion.identity);
        Vcam.m_Follow = player.transform;
        numOfCoin = PlayerPrefs.GetInt("NumOfCoin",0);
        isGameOver = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        cointext.text = numOfCoin.ToString();
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void replayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Pause()
    {
        Time.timeScale = 0;     //Pause
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;     //Resume
        pauseMenu.SetActive(false);

    }

    public void ManiMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    
}
