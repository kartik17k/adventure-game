using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class menuEvents : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioMixer mixer;
    private float value;

    private void Start()
    {
        Time.timeScale = 1;
        mixer.GetFloat("volume", out value);
        volumeSlider.value = value;
    }
    public void setvolume()
    {
        mixer.SetFloat("volume",volumeSlider.value);
    }

    public void loadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
