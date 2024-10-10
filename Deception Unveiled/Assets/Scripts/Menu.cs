using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private PlayerController player;
    // make public, set npc while interacting
    // playercontroller variables, npc send to playercontroller, which then sends to menu
    // satic variables below?
    // menu finds all npcs in the scene, find objects put into an array, when interacting set a flag

    //ITEM QUESTS WORK. FIX INTERVIEW AND LOCATION QUESTS
    public NPC npc;
    public NPC_Locations locnpc;
    public NPC_Interview intnpc;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
        player.questsFailed++;
    }
}
