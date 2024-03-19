using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Blackjack");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void HelpButton()
    {
        SceneManager.LoadScene("Rules");
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
