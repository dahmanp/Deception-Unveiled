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
    private bool inRange = false;
    public string description;

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            typeSwitch();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
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

    void DescribeItem()
    {
        Debug.Log(description);
    }

    void check(int i)
    {
        if (player.curSpace < player.maxSpace)
        {
            Debug.Log("Added to inventory!");
            DescribeItem();
            player.addItem(i);
            Destroy(gameObject);
        } else
        {
            Debug.Log("Too full!");
        }
    }
}
