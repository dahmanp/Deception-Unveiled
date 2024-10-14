using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RestPeriod : MonoBehaviour
{
    public GameObject canvas; 
    public GameObject failTransitionPage;
    public GameObject winTransitionPage;
    public GameObject restPeriodIntro;
    public GameObject selectOption;

    public TMP_Text dateAndTime;
    public int day = 1;
    public TMP_Text failStat;
    public TMP_Text winStat;
    public TMP_Text totalStat;

    public GameObject prefab;

    public GameObject playerObj;
    private PlayerController player;
    private Menu menu;

    int locID;
    int locNPC;
    int SS_eventID;
    public GameObject[] tpSpots;
    public GameObject[] fakeNPCSpots;

    void Start()
    {
        player = playerObj.GetComponent<PlayerController>();
    }

    void SetScreen(GameObject screen)
    {
        winTransitionPage.SetActive(false);
        failTransitionPage.SetActive(false);
        restPeriodIntro.SetActive(false);
        selectOption.SetActive(false);

        screen.SetActive(true);
    }

    void Update()
    {
        //for some reason it isnt logging whether you win or lose, it just goes to the win screen
        // sometimes it works???? idk lol
        if (player.winRest == true)
        {
            canvas.SetActive(true);
            SetScreen(restPeriodIntro);
            chooseEvent();
            player.winRest = false;
        }
        else if (player.failRest == true)
        {
            canvas.SetActive(true);
            SetScreen(failTransitionPage);
            chooseEvent();
            player.failRest = false;
        }
    }

    public void SelectOption()
    {
        SetScreen(selectOption);
    }

    public void exit()
    {
        canvas.SetActive(false);
        winTransitionPage.SetActive(false);
        failTransitionPage.SetActive(false);
        restPeriodIntro.SetActive(false);
        selectOption.SetActive(false);

        day++;
        dateAndTime.text = "Day " + day + ", Morning.";

        totalStat.text = "Total Quests: " + player.totalQuests;
        failStat.text = "Quests Failed: " + player.questsFailed;
        winStat.text = "Quests Won: " + player.questsCompleted;
    }


    //SHAPESHIFTER:::
    void chooseEvent()
    {
        SS_eventID = Random.Range(0, 9);
        if (SS_eventID == 0 || SS_eventID == 1 || SS_eventID == 2 || SS_eventID == 3 || SS_eventID == 4)
        {
            SS_teleport();
        }
        else if (SS_eventID == 5 || SS_eventID == 6 || SS_eventID == 7)
        {
            SS_fakeQuest();
        }
        else if (SS_eventID == 8 || SS_eventID == 9)
        {
            SS_autoFail();
        }
    }

    void SS_teleport()
    {
        //Debug.Log("TELEPORT");
        locID = Random.Range(0, 9);
        Vector3 randomPosition = tpSpots[locID].transform.position;
        player.transform.position = randomPosition;
    }

    void SS_fakeQuest()
    {
        //Debug.Log("FAKE");
        locNPC = Random.Range(0, 4);
        Vector3 randomPosition = fakeNPCSpots[locNPC].transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(prefab, randomPosition, spawnRotation);
    }

    void SS_autoFail()
    {
        //Debug.Log("AUTOFAIL");
        player.questsFailed++;
        player.totalQuests++;
    }


    //DETECTIVE:::
    public void D_hintCollection()
    {
        //get a hint for a collection quest
        player.collectionHints++;
        SetScreen(winTransitionPage);
    }

    public void D_hintInvestigation()
    {
        //get a hint for an investigation quest
        player.investigationHints++;
        SetScreen(winTransitionPage);
    }

    public void D_hintInterview()
    {
        player.interviewHints++;
        SetScreen(winTransitionPage);
    }
}
