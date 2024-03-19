using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchEndUI : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("BlackJack");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
