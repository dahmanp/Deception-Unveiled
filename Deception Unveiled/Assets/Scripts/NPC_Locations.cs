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
    public GameObject interact;

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
            if (player.playerInQuest == false)
            {
                start();
            } else
            {
                Debug.Log("In a quest already!");
            }
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
        interact.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
        interact.SetActive(false);
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
        player.playerInQuest = true;
        player.locnpc = this;
        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
        interact.SetActive(false);

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
            player.hintScreen.SetActive(false);
            inQuest = false;
            player.questsCompleted++;
            player.totalQuests++;
            player.questEndWin = true;
            player.playerInQuest = false;

            this.enabled = false;
        } else
        {
            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.hintScreen.SetActive(false);
            inQuest = false;
            player.questsFailed++;
            player.totalQuests++;
            player.questEndFail = true;
            player.playerInQuest = false;

            this.enabled = false;
        }
    }
}
