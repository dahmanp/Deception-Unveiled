using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainTrigger : MonoBehaviour
{
    public Collider2D exitcollider;
    public bool mayorCompleted = false;
    public bool itemCompleted = true;
    public bool locCompleted = true;

    public GameObject journalScreen;
    public GameObject[] screens;
    public int currScreen;

    //for location interaction, maybe the city gates?

    void Awake()
    {
        exitcollider.enabled = false;
    }

    void Update()
    {
        if (mayorCompleted && itemCompleted && locCompleted)
        {
            exitcollider.enabled = true;
        }
    }

    public void openJournal()
    {
        journalScreen.SetActive(true);
        currScreen = 0;
        screens[0].SetActive(true);
        screens[1].SetActive(false);
        screens[2].SetActive(false);
        screens[3].SetActive(false);
        Time.timeScale = 0f;
    }

    public void closeJournal()
    {
        journalScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void leftButton()
    {
        if (currScreen <= 0)
        {
            Debug.Log("Already at leftmost screen!");
            if (currScreen < 0)
            {
                currScreen = 0;
            }
        }
        else
        {
            screens[currScreen].SetActive(false);
            currScreen--;
            screens[currScreen].SetActive(true);
        }
    }

    public void rightButton()
    {
        if (currScreen >= 3)
        {
            Debug.Log("Already at rightmost screen!");
            if (currScreen > 3)
            {
                currScreen = 3;
            }
        }
        else
        {
            screens[currScreen].SetActive(false);
            currScreen++;
            screens[currScreen].SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Main");
    }
}
