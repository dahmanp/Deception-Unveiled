using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPickup : MonoBehaviour
{
    private PlayerControllerTutorial player;
    private PicCheck puzzleCheck;
    private ToMainTrigger door;
    private bool inRange = false;
    public string goodDesc;
    public string badDesc;

    public GameObject puzzleScreen;
    public GameObject puzzle;

    void Start()
    {
        player = FindObjectOfType<PlayerControllerTutorial>();
        door = FindObjectOfType<ToMainTrigger>();
        puzzleScreen = player.puzzleTime;
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            door.itemCompleted = true;
            player.journalButton.SetActive(true);
            Destroy(gameObject);
        }
        else if (inRange == true && Input.GetKeyDown(KeyCode.Q))
        {
            puzzleScreen.SetActive(true);
            GameObject instantiatedPuzzle = Instantiate(puzzle, puzzleScreen.transform);
            puzzleCheck = instantiatedPuzzle.GetComponent<PicCheck>();

            StartCoroutine(CheckResult(instantiatedPuzzle));
        }
    }

    IEnumerator CheckResult(GameObject puzzle)
    {
        while (!puzzleCheck.puzzleEnd)
        {
            yield return null;
        }

        if (puzzleCheck.puzzleComplete == true)
        {
            player.DialogueBox.SetActive(true);
            player.dialogue.text = goodDesc;
        }
        else
        {
            player.DialogueBox.SetActive(true);
            player.dialogue.text = badDesc;
        }
        puzzleScreen.SetActive(false);
        Destroy(puzzle);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (player != null)
        {
            inRange = true;
        }
        player.interactText.SetActive(true);
        player.text_interactText.text = "E to Collect         Q to Investigate";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerTutorial>() == player)
        {
            inRange = false;
        }
        player.interactText.SetActive(false);
        player.DialogueBox.SetActive(false);
    }
}