using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum LocQuest
{
    quest1, quest2, quest3, quest4, quest5//, quest6, quest7, quest8, quest9, quest10
}

public class NPC_Locations : MonoBehaviour
{
    private PlayerController player;
    private bool inRange = false;
    public LocQuest quest;

    private BoxCollider2D boxCollider;

    public string[] intros;
    public string[] fails;
    public string[] wins;
    public int[] answers;

    public int response = 0;

    public string intro;
    public int answer;
    public string fail;
    public string win;

    public bool inQuest = false;

    void Update()
    {
        typeSwitch();
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            start();
        }
        if (inQuest==true && response!=0)
        {
            //Debug.Log("testing");
            check();
            response = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
    }

    void setDialogue(int i)
    {
        intro = intros[i];
        win = wins[i];
        fail = fails[i];
        answer = answers[i];
    }

    void typeSwitch()
    {
        if (quest == LocQuest.quest1)
        {
            setDialogue(0);
        }
        else if (quest == LocQuest.quest2)
        {
            setDialogue(1);
        }
        else if (quest == LocQuest.quest3)
        {
            setDialogue(2);
        }
        else if (quest == LocQuest.quest4)
        {
            setDialogue(3);
        }
        else if (quest == LocQuest.quest5)
        {
            setDialogue(4);
        }
        /*else if (quest == LocQuest.quest6)
        {
            setDialogue(5);
        }
        else if (quest == LocQuest.quest7)
        {
            setDialogue(6);
        }
        else if (quest == LocQuest.quest8)
        {
            setDialogue(7);
        }
        else if (quest == LocQuest.quest9)
        {
            setDialogue(8);
        }
        else if (quest == LocQuest.quest10)
        {
            setDialogue(9);
        }*/
    }

    void start()
    {
        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
    }

    void check()
    {
        if (response == answer)
        {
            player.desc.text = win;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            inQuest = false;
            player.questsCompleted++;
            player.questEndWin = true;
            player.curSpace--;
            player.sortArray(player.inventory);
        } else
        {
            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            inQuest = false;
            player.questsFailed++;
            player.questEndFail = true;
        }
    }
}
