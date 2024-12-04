using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMainTrigger : MonoBehaviour
{
    public Collider2D exitcollider;
    public bool mayorCompleted = false;
    public bool itemCompleted = true;

    public GameObject door;
    public GameObject journalScreen;
    public GameObject[] screens;
    public int currScreen;

    public AudioSource pageTurn;

    void Awake()
    {
        exitcollider.enabled = false;
    }

    void Update()
    {
        if (mayorCompleted && itemCompleted)
        {
            exitcollider.enabled = true;
            door.SetActive(false);
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
        pageTurn.Play();
    }

    public void closeJournal()
    {
        journalScreen.SetActive(false);
        Time.timeScale = 1f;
        pageTurn.Play();
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
        pageTurn.Play();
    }

    public void rightButton()
    {
        if (currScreen >= 4)
        {
            Debug.Log("Already at rightmost screen!");
            if (currScreen > 4)
            {
                currScreen = 4;
            }
        }
        else
        {
            screens[currScreen].SetActive(false);
            currScreen++;
            screens[currScreen].SetActive(true);
        }
        pageTurn.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("Main");
    }
}
