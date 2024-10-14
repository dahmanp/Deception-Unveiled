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
    [SerializeField]
    private PlayerController player;

    private bool inRange = false;
    public ItemQuest quest;
    private BoxCollider2D boxCollider;
    public GameObject interact;

    public string[] intros;
    public string[] fails;
    public string[] wins;
    public string[] hints;
    public int[] answers;
    public string[] objectives;

    public string intro;
    public int answer;
    public string fail;
    public string win;
    public string hint;

    public bool inQuest = false;

    public int response;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (inQuest == false)
            {
                start();
            } else if (inQuest == true)
            {
                selectOption();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController potentialPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (potentialPlayer != null)
        {
            player = potentialPlayer;
            inRange = true;
        }
        interact.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
            player = null;
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
        player.objective.text = objectives[i];

    }

    public void typeSwitch()
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

    public void start()
    {
        player.playerInQuest = true;
        player.npc = this;
        if (player == null)
        {
            Debug.Log("start Error");
            return;
        }

        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
        interact.SetActive(false);

        if (player.collectionHints > 0)
        {
            player.hintText.text = hint;
            player.hintScreen.SetActive(true);
            player.collectionHints--;
        }
    }

    public void selectOption()
    {
        if (player == null)
        {
            Debug.Log("selectOption Error");
            return;
        }
        player.invScreen.SetActive(true);
    }

    public void check()
    {
        Debug.Log(player);
        if (player == null)
        {
            Debug.Log("check (player) Error");
            return;
        }
        if (!inQuest)
        {
            Debug.Log("check (inquest) Error");
            return;
        }
        //Debug.Log(answer);
        //Debug.Log(response);

        if (response == answer)
        {
            //Debug.Log("correct");
            player.desc.text = win;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.invScreen.SetActive(false);
            player.hintScreen.SetActive(false);

            inQuest = false;

            player.questsCompleted++;
            player.totalQuests++;
            player.questEndWin = true;
            player.curSpace--;
            if (player.curSpace < 0) {
                player.curSpace = 0;
            }
            player.sortArray(player.inventory);
            player.playerInQuest = false;

            this.enabled = false;
        } else
        {
            //Debug.Log("incorrect");
            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.invScreen.SetActive(false);
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
