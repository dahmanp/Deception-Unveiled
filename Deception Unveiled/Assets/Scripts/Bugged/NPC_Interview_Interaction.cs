using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InterviewOtherQuest
{
    quest1, quest2, quest3, quest4, quest5
}

public class NPC_Interview_Interaction : MonoBehaviour
{
    private PlayerController player;
    private NPC_Interview intnpc;
    private bool inRange = false;
    public InterviewOtherQuest quest;
    private BoxCollider2D boxCollider;

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

    public int answer1;
    public int answer2;

    public bool wonQuest = false;
    public bool inQuest = false;

    public int response;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        intnpc = GetComponent<NPC_Interview>();
    }
    //consider moving this to just be the interview one. it might simplify all of this lol

    void Update()
    {
        //add an if statement here mayhaps?
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            typeSwitch();
            start();
            /*if (intnpc.inQuest == false)
            {
                //do nothing
            }
            else if (intnpc.inQuest == true)
            {
                start();
            }*/
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
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
            player = null;
        }
    }

    void setDialogue(int i)
    {
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
    }

    public void typeSwitch()
    {
        if (quest == InterviewOtherQuest.quest1)
        {
            setDialogue(0);
            answer1 = 2;
            answer2 = 1;
        }
        else if (quest == InterviewOtherQuest.quest2)
        {
            setDialogue(1);
            answer1 = 3;
            answer2 = 1;
        }
        else if (quest == InterviewOtherQuest.quest3)
        {
            setDialogue(2);
            answer1 = 3;
            answer2 = 2;
        }
        else if (quest == InterviewOtherQuest.quest4)
        {
            setDialogue(3);
            answer1 = 1;
            answer2 = 3;
        }
        else if (quest == InterviewOtherQuest.quest5)
        {
            setDialogue(4);
            answer1 = 2;
            answer2 = 1;
        }
    }

    public void start()
    {
        if (player == null)
        {
            Debug.Log("start Error");
            return;
        }

        player.question.text = intro;
        player.answer1.text = Q1response1;
        player.answer2.text = Q1response2;
        player.answer3.text = Q1response3;
        player.quiz.SetActive(true);

        if (player.interviewHints > 0)
        {
            //player.hintText.text = hint;
            player.hintScreen.SetActive(true);
            player.interviewHints--;
        }
    }

    public void check()
    {
        if (response == answer1)
        {
            player.question.text = win1;
            player.answer1.text = Q2response1;
            player.answer2.text = Q2response2;
            player.answer3.text = Q2response3;
            response = 0;
        }
        else if (response == answer2)
        {
            player.desc.text = win2;
            player.inspectText.SetActive(true);
            wonQuest = true;
        }
        else
        {
            player.quiz.SetActive(false);
            player.desc.text = fail;
            player.inspectText.SetActive(true);
        }
    }
}
