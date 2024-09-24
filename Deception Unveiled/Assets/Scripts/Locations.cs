using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationType
{
    church, graveyard, mine, forest, grove, woods, library, square, laboratory, ruins
}

public class Locations : MonoBehaviour
{
    public LocationType type;
    private PlayerController player;
    private bool inRange = false;
    public string badDesc;
    public string goodDesc;

    public bool collected = false;

    private NPC_Locations npcLoc;

    void Start()
    {
        npcLoc = FindObjectOfType<NPC_Locations>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
        {
            if (npcLoc.inQuest == false)
            {
                DescribeLocationGood();
            } else if (npcLoc.inQuest == true)
            {
                typeSwitch();
                //option, do you want to choose this for your answer?
            }
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
        if (type == LocationType.church)
        {
            check(1);
            collected = true;
        }
        else if (type == LocationType.graveyard)
        {
            check(2);
            collected = true;
        }
        else if (type == LocationType.mine)
        {
            check(3);
            collected = true;
        }
        else if (type == LocationType.forest)
        {
            check(4);
            collected = true;
        }
        else if (type == LocationType.grove)
        {
            check(5);
            collected = true;
        }
        else if (type == LocationType.woods)
        {
            check(6);
            collected = true;
        }
        else if (type == LocationType.library)
        {
            check(7);
            collected = true;
        }
        else if (type == LocationType.square)
        {
            check(8);
            collected = true;
        }
        else if (type == LocationType.laboratory)
        {
            check(9);
            collected = true;
        }
        else if (type == LocationType.ruins)
        {
            check(10);
            collected = true;
        }
    }

    void DescribeLocationGood()
    {
        Debug.Log(goodDesc);
    }

    void DescribeLocationBad()
    {
        Debug.Log(badDesc);
    }

    void check(int i)
    {
        npcLoc.response = i;
        DescribeLocationBad();
        if (collected==false)
        {
            player.addLocation(goodDesc);
        }
    }
}
