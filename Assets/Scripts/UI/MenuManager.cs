using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject Credits;

    // Play game
    public void Play()
    {
        SceneManager.LoadScene("level");
    }

    // Show/Hide Credits
    public void ShowHideCredits()
    {
        if(Credits.active)
        {
            Credits.SetActive(false);
        }
        else
        {
            Credits.SetActive(true);
        }
    }

    // quit game
    public void Quit()
    {
        Application.Quit();
    }
}
