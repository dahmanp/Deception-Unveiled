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
            player.addItem(1);
            DescribeItem();
        }
        else if (type == PickupType.footprints)
        {
            player.addItem(2);
            DescribeItem();
        }
        else if (type == PickupType.symbols)
        {
            player.addItem(3);
            DescribeItem();
        }
        else if (type == PickupType.whispers)
        {
            player.addItem(4);
            DescribeItem();
        }
        else if (type == PickupType.folklore)
        {
            player.addItem(5);
            DescribeItem();
        }
        else if (type == PickupType.tome)
        {
            player.addItem(6);
            DescribeItem();
        }
        else if (type == PickupType.bones)
        {
            player.addItem(7);
            DescribeItem();
        }
        else if (type == PickupType.chains)
        {
            player.addItem(8);
            DescribeItem();
        }
        else if (type == PickupType.clothing)
        {
            player.addItem(9);
            DescribeItem();
        }
        else if (type == PickupType.gemstone)
        {
            player.addItem(10);
            DescribeItem();
        }
        Destroy(gameObject);
        //dont forget to change this - item should not be destroyed if it is not collected
    }

    void DescribeItem()
    {
        Debug.Log(description);
    }


}
