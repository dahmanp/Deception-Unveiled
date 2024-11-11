using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private PlayerController player;
    private RestPeriod rp;
    public NPC npc;
    public NPC_Locations locnpc;
    public NPC_Interview intnpc;

    public GameObject journalScreen;
    public GameObject[] screens;
    public int currScreen;

    public TMP_Text[] itemList;
    public int numItems;
    public TMP_Text[] locList;
    public int numLoc;
    public TMP_Text[] intList;
    public int numInt;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        rp = FindObjectOfType<RestPeriod>();
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

    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
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
        } else
        {
            screens[currScreen].SetActive(false);
            currScreen--;
            screens[currScreen].SetActive(true);
        }
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
    }

    public void selectObject(int i)
    {
        npc = player.npc;
        if (player.inventory[i] != 0)
        {
            npc.response = player.inventory[i];
            player.inventory[i] = 0;
            player.curSpace--;
            npc.check();
            npc = null;
        }
    }

    public void optionA()
    {
        intnpc = player.intnpc;
        intnpc.response = 1;
        intnpc.check();
    }

    public void optionB()
    {
        intnpc = player.intnpc;
        intnpc.response = 2;
        intnpc.check();
    }

    public void optionC()
    {
        intnpc = player.intnpc;
        intnpc.response = 3;
        intnpc.check();
    }

    public void selectLocation()
    {
        locnpc = player.locnpc;
        locnpc.check();
        locnpc.response = 0;
    }

    public void Exit()
    {
        player.charaImages.SetActive(false);
        player.inspectText.SetActive(false);
        player.exitButton.SetActive(false);
        player.locQuestButtons.SetActive(false);
        player.invScreen.SetActive(false);

        if (player.questEndWin == true)
        {
            rp.WinRest();
            player.questEndWin = false;
        }
        else if (player.questEndFail == true)
        {
            rp.FailRest();
            player.questEndFail = false;
        }
    }

    public void acceptQuest()
    {
        player.charaImages.SetActive(false);
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
        player.hintScreen.SetActive(false);
    }

    public void acceptQuestinterview()
    {
        intnpc = player.intnpc;
        player.inspectText.SetActive(false);
        player.buttonsInt.SetActive(false);
        player.hintScreen.SetActive(false);
        intnpc.accepted = true;
    }

    public void rejectQuest()
    {
        player.charaImages.SetActive(false);
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);

        rp.FailRest();
        //player.questEndFail = true;
        player.playerInQuest = false;
        player.questsFailed++;
        player.totalQuests++;
    }
}
