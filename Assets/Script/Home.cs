using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Home : MonoBehaviour
{

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
        audioManager.PlaySFX(audioManager.click);
    }

    public void Option()
    {
        SceneManager.LoadSceneAsync(3);
        audioManager.PlaySFX(audioManager.click);
    }

    public void Ship()
    {
        SceneManager.LoadSceneAsync(4);
        audioManager.PlaySFX(audioManager.click);
    }
}
