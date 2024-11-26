using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    journal, footprints, symbols, whispers, folklore, tome, bones, chains, clothing, gemstone
}

public class Pickup : MonoBehaviour
{
    public PickupType type;
    private PlayerController player;
    private PicCheck puzzleCheck;
    private Menu menu;
    private bool inRange = false;
    public string goodDesc;
    public string badDesc;

    public GameObject puzzleScreen;
    public GameObject puzzle;

    void Start()
    {
        menu = FindObjectOfType<Menu>();
        player = FindObjectOfType<PlayerController>();
        puzzleScreen = player.puzzleTime;
        Debug.Log(puzzleScreen);
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            typeSwitch();

        } else if (inRange == true && Input.GetKeyDown(KeyCode.Q))
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
            menu.itemList[menu.numItems].text = goodDesc;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.desc.text = goodDesc;
        }
        else
        {
            menu.itemList[menu.numItems].text = badDesc;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.desc.text = badDesc;
        }

        menu.numItems++;
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
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
        player.interactText.SetActive(false);
        player.inspectText.SetActive(false);
    }

    void typeSwitch()
    {
        if (type == PickupType.journal)
        {
            check(1);
        }
        else if (type == PickupType.footprints)
        {
            check(2);
        }
        else if (type == PickupType.symbols)
        {
            check(3);
        }
        else if (type == PickupType.whispers)
        {
            check(4);
        }
        else if (type == PickupType.folklore)
        {
            check(5);
        }
        else if (type == PickupType.tome)
        {
            check(6);
        }
        else if (type == PickupType.bones)
        {
            check(7);
        }
        else if (type == PickupType.chains)
        {
            check(8);
        }
        else if (type == PickupType.clothing)
        {
            check(9);
        }
        else if (type == PickupType.gemstone)
        {
            check(10);
        }
    }

    void check(int i)
    {
        if (player.curSpace < player.maxSpace)
        {
            player.addItem(i);
            menu.itemList[menu.numItems].text = badDesc;
            menu.numItems++;
            Destroy(gameObject);
            player.inspectText.SetActive(false);
        } else
        {
            Debug.Log("Too full!");
        }
    }
}
