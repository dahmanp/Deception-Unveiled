using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private PlayerController player;
    private NPC npc;
    private NPC_Locations locnpc;
    private NPC_Interview intnpc;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        npc = FindObjectOfType<NPC>();
        locnpc = FindObjectOfType<NPC_Locations>();
        intnpc = FindObjectOfType<NPC_Interview>();
    }

    //DO NOT CHANGE PLEASEPLEASE
    public void selectObject(int i)
    {
        if (player.inventory[i] != 0)
        {
            npc.response = player.inventory[i];
            player.inventory[i] = 0;
            player.curSpace--;
            npc.check();
        }
    }

    public void optionA()
    {
        intnpc.response = 1;
        intnpc.check();
    }

    public void optionB()
    {
        intnpc.response = 2;
        intnpc.check();
    }

    public void optionC()
    {
        intnpc.response = 3;
        intnpc.check();
    }

    public void selectLocation()
    {
        locnpc.check();
        locnpc.response = 0;
    }

    public void Exit()
    {
        player.inspectText.SetActive(false);
        player.exitButton.SetActive(false);
        player.locQuestButtons.SetActive(false);

        if (player.questEndWin == true)
        {
            player.winRest = true;
        }
        else if (player.questEndFail == true)
        {
            player.failRest = true;
        }
    }

    public void acceptQuest()
    {
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
        player.hintScreen.SetActive(false);
    }

    public void rejectQuest()
    {
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
        player.questsFailed++;
    }
}
