using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public float time =60;
    public Text timeText;
    public GameObject losePanel;
    public GameObject homePanel;
    // Update is called once per frame
    void Update()
    {
        if(time>0)
        {
        time-=Time.deltaTime;
        }
        else
        {
            time = 0;
        }
        Displaytime(time);
    }
    void Displaytime(float timeToDisplay)
    {
        if(timeToDisplay<0)
        {
            timeToDisplay = 0;
        }
         float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
         timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
         if(time == 0)
         {
            losePanel.SetActive(true);
          
         }
    }

    public void replay()
    {
        SceneManager.LoadScene("Game");
        PlayerPrefs.DeleteAll();
    }
    public void Quit()
    {
        Application.Quit();
        PlayerPrefs.DeleteAll();
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
    public void homescreen()
    {
        SceneManager.LoadScene("HomePanel");
    }
}
