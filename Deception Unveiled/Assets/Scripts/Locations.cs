using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    private PlayerController player;
    private PicCheck puzzleCheck;
    private Menu menu;
    private JournalMap map;
    private bool inRange = false;
    public string badDesc;
    public string goodDesc;
    public int index;

    public GameObject puzzleScreen;
    public GameObject puzzle;

    public bool collected = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        menu = FindObjectOfType<Menu>();
        map = FindObjectOfType<JournalMap>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
        {
            PuzzleTime();
            player.interactText.SetActive(false);
            //set active the commentary text so that players can read the location descriptions.
        }
    }

    private void PuzzleTime()
    {
        puzzleScreen.SetActive(true);
        GameObject instantiatedPuzzle = Instantiate(puzzle, puzzleScreen.transform);
        puzzleCheck = instantiatedPuzzle.GetComponent<PicCheck>();

        StartCoroutine(CheckResult(instantiatedPuzzle));
    }

    IEnumerator CheckResult(GameObject puzzle)
    {
        while (!puzzleCheck.puzzleEnd)
        {
            yield return null;
        }
        Debug.Log(collected);
        if (collected == false)
        {
            if (puzzleCheck.puzzleComplete == true)
            {
                player.addLocation(goodDesc);
                menu.locList[menu.numLoc].text = goodDesc;
            }
            else
            {
                player.addLocation(badDesc);
                menu.locList[menu.numLoc].text = badDesc;
            }
            menu.numLoc++;
            collected = true;
        }

        if (player.locnpc != null && player.locnpc.inQuest == true)
        {
            player.locnpc.response = index+1;
        }

        puzzleScreen.SetActive(false);
        map.unlockSection(index);
        Destroy(puzzle);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            inRange = true;
        }
        player.interactText.SetActive(true);
        player.text_interactText.text = "F to Investigate";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
        player.interactText.SetActive(false);
        player.inspectText.SetActive(false);
    }
}
