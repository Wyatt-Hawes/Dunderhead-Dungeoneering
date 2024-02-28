using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource soundPlayer;

    private void Start()
    {
        soundPlayer = GameObject.Find("AudioSource").GetComponent<AudioSource>();
    }

    public void ButtonSoundEffect()
    {
        soundPlayer.Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
