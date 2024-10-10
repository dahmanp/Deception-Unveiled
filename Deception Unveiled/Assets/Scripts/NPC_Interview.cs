using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum InterviewQuest
{
    quest1, quest2, quest3, quest4, quest5
}

public class NPC_Interview : MonoBehaviour
{
    private PlayerController player;
    private bool inRange = false;
    public InterviewQuest quest;
    private BoxCollider2D boxCollider;
    public GameObject interact;

    public string[] intro_quests;
    public string[] intros;
    public string[] fails;
    public string[] win1s;
    public string[] win2s;
    public string[] Q1response1s;
    public string[] Q1response2s;
    public string[] Q1response3s;
    public string[] Q2response1s;
    public string[] Q2response2s;
    public string[] Q2response3s;
    public string[] hint1s;
    public string[] hint2s;

    public string intro_quest;
    public string intro;
    public string Q1response1;
    public string Q1response2;
    public string Q1response3;
    public string Q2response1;
    public string Q2response2;
    public string Q2response3;
    public string fail;
    public string win1;
    public string win2;
    public string hint1;
    public string hint2;

    public int answer1;
    public int answer2;

    public bool accepted = false;
    public bool inQuest = false;
    public bool q1 = false;
    public bool q2 = false;

    public int response;

    void Start()
    {
        typeSwitch();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (inQuest == false)
            {
                if (player.playerInQuest == false)
                {
                    start();
                }
                else
                {
                    Debug.Log("In a quest already!");
                }
            }
        }
        if (accepted == true)
        {
            player.question.text = intro;
            player.answer1.text = Q1response1;
            player.answer2.text = Q1response2;
            player.answer3.text = Q1response3;
            player.quiz.SetActive(true);

            if (player.interviewHints > 0)
            {
                player.hintText.text = hint1;
                player.hintScreen.SetActive(true);
                player.interviewHints--;
            }
            accepted = false;
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
        intro_quest = intro_quests[i];
        intro = intros[i];
        Q1response1 = Q1response1s[i];
        Q1response2 = Q1response2s[i];
        Q1response3 = Q1response3s[i];
        Q2response1 = Q2response1s[i];
        Q2response2 = Q2response2s[i];
        Q2response3 = Q2response3s[i];
        fail = fails[i];
        win1 = win1s[i];
        win2 = win2s[i];
        hint1 = hint1s[i];
        hint2 = hint2s[i];
    }

    public void typeSwitch()
    {
        if (quest == InterviewQuest.quest1)
        {
            setDialogue(0);
            answer1 = 2;
            answer2 = 1;
        }
        else if (quest == InterviewQuest.quest2)
        {
            setDialogue(1);
            answer1 = 3;
            answer2 = 1;
        }
        else if (quest == InterviewQuest.quest3)
        {
            setDialogue(2);
            answer1 = 3;
            answer2 = 2;
        }
        else if (quest == InterviewQuest.quest4)
        {
            setDialogue(3);
            answer1 = 1;
            answer2 = 3;
        }
        else if (quest == InterviewQuest.quest5)
        {
            setDialogue(4);
            answer1 = 2;
            answer2 = 1;
        }
    }

    public void start()
    {
        player.playerInQuest = true;
        player.intnpc = this;
        if (player == null)
        {
            Debug.Log("start Error");
            return;
        }
        interact.SetActive(false);

        player.desc.text = intro_quest;
        player.inspectText.SetActive(true);
        player.buttonsInt.SetActive(true);
        inQuest = true;
    }

    public void check()
    {
        if (response == answer1 && q1 == false)
        {
            player.question.text = win1;
            player.answer1.text = Q2response1;
            player.answer2.text = Q2response2;
            player.answer3.text = Q2response3;
            response = 0;
            q1 = true;
            q2 = true;
            if (player.interviewHints > 0)
            {
                player.hintText.text = hint2;
                player.hintScreen.SetActive(true);
                player.interviewHints--;
            }
        }
        else if (response == answer2 && q2 == true)
        {
            player.quiz.SetActive(false);
            player.desc.text = win2;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.hintScreen.SetActive(false);
            q2 = false;
            q1 = false;
            player.questsCompleted++;
            player.totalQuests++;
            player.questEndWin = true;
            player.playerInQuest = false;

            this.enabled = false;
        }
        else
        {
            player.quiz.SetActive(false);
            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.hintScreen.SetActive(false);
            player.questsFailed++;
            player.totalQuests++;
            player.questEndFail = true;
            player.playerInQuest = false;

            this.enabled = false;
        }
    }
}
