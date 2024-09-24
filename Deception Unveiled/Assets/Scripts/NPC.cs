using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemQuest
{
    quest1, quest2, quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10
}

public class NPC : MonoBehaviour
{
    private PlayerController player;
    private bool inRange = false;
    public ItemQuest quest;
    private BoxCollider2D boxCollider;

    public string[] intros;
    public string[] fails;
    public string[] wins;
    public int[] answers;

    public string intro;
    public int answer;
    public string fail;
    public string win;

    public bool inQuest = false;

    public int response;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        typeSwitch();
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (inQuest == false)
            {
                start();
            } else if (inQuest == true)
            {
                selectOption();
                check();
            }
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
        if (quest == ItemQuest.quest1)
        {
            setDialogue(0);
        }
        else if (quest == ItemQuest.quest2)
        {
            setDialogue(1);
        }
        else if (quest == ItemQuest.quest3)
        {
            setDialogue(2);
        }
        else if (quest == ItemQuest.quest4)
        {
            setDialogue(3);
        }
        else if (quest == ItemQuest.quest5)
        {
            setDialogue(4);
        }
        else if (quest == ItemQuest.quest6)
        {
            setDialogue(5);
        }
        else if (quest == ItemQuest.quest7)
        {
            setDialogue(6);
        }
        else if (quest == ItemQuest.quest8)
        {
            setDialogue(7);
        }
        else if (quest == ItemQuest.quest9)
        {
            setDialogue(8);
        }
        else if (quest == ItemQuest.quest10)
        {
            setDialogue(9);
        }
    }

    void start()
    {
        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
    }

    public void selectOption()
    {
        int i = 0;
        for (i=0; i<4; i++)
        {
            if (player.inventory[i] == answer)
            {
                response = player.inventory[i];
                player.inventory[i] = 0;
            }
        }
        //somehow allow the player to select an item from their inventory
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

            boxCollider.enabled = false;
        } else
        {
            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            inQuest = false;
            player.questsFailed++;
            player.questEndFail = true;

            boxCollider.enabled = false;
        }
    }
}
