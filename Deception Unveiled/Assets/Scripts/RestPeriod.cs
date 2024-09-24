using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestPeriod : MonoBehaviour
{
    public GameObject canvas; 
    public GameObject failTransitionPage;
    public GameObject winTransitionPage;
    public GameObject restPeriodIntro;
    public GameObject selectOption;

    public GameObject prefab;

    private PlayerController player;
    private Menu menu;

    int locID;
    int locNPC;
    int SS_eventID;
    public GameObject[] tpSpots;
    public GameObject[] fakeNPCSpots;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        if (player.questEndWin == true)
        {
            canvas.SetActive(true);
            SetScreen(restPeriodIntro);
            chooseEvent();
            player.questEndWin = false;
        }
        else if (player.questEndFail == true)
        {
            canvas.SetActive(true);
            SetScreen(failTransitionPage);
            chooseEvent();
            player.questEndFail = false;
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

    public void D_BLANK()
    {
        //idk yet
        SetScreen(winTransitionPage);
    }
}
