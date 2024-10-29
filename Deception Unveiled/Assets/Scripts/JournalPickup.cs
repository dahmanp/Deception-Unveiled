using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPickup : MonoBehaviour
{
    private PlayerControllerTutorial player;
    private ToMainTrigger door;
    private bool inRange = false;
    public string description;

    void Start()
    {
        door = FindObjectOfType<ToMainTrigger>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            check();
        }
        else if (inRange == true && Input.GetKeyDown(KeyCode.Q))
        {
            DescribeItem();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerControllerTutorial>();
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

    void DescribeItem()
    {
        player.DialogueBox.SetActive(true);
        player.dialogue.text = description;
    }

    void check()
    {
        door.itemCompleted = true;
        player.journalButton.SetActive(true);
        Destroy(gameObject);
        /*if (player.curSpace < player.maxSpace)
        {
            //Debug.Log("Added to inventory!");
            //player.addItem(i);
            //menu.itemList[menu.numItems].text = description;
            //menu.numItems++;
            Destroy(gameObject);
            //player.inspectText.SetActive(false);
        }
        else
        {
            Debug.Log("Too full!");
        }*/
    }
}
