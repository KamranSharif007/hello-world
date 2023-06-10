using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Home : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene("Game");
        PlayerPrefs.DeleteAll();
    }
    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }
}
