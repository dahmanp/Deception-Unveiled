using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum LocQuest
{
    quest1, quest2, quest3, quest4, quest5
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
    public string[] hints;
    public int[] answers;

    public int response = 0;

    public string intro;
    public int answer;
    public string fail;
    public string win;
    public string hint;

    public bool inQuest = false;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        typeSwitch();
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            start();
        }
        if (inQuest==true && response!=0)
        {
            check();
            response = 0;
            //open the button menu
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
        hint = hints[i];
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
    }

    void start()
    {
        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;

        if (player.investigationHints > 0)
        {
            player.hintText.text = hint;
            player.hintScreen.SetActive(true);
            player.investigationHints--;
        }
    }

    public void check()
    {
        if (response == answer)
        {
            player.desc.text = win;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            inQuest = false;
            player.questsCompleted++;
            player.questEndWin = true;

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
