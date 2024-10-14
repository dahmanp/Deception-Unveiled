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
    private Menu menu;
    private bool inRange = false;
    public string badDesc;
    public string goodDesc;

    public bool collected = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        menu = FindObjectOfType<Menu>();
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
        {
            if (player.locnpc == null || player.locnpc.inQuest == false)
            {
                DescribeLocationGood();
                player.addLocation(goodDesc);
                menu.locList[menu.numLoc].text = goodDesc;
            } else if (player.locnpc.inQuest == true)
            {
                typeSwitch();
            }
            player.interactText.SetActive(false);
        }
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

    public void check(int i)
    {
        player.locnpc.response = i;
        //DescribeLocationBad();
        if (collected==false)
        {
            Debug.Log(menu);
            player.addLocation(goodDesc);
            menu.locList[menu.numLoc].text = goodDesc;
            menu.numLoc++;
        }
    }
}
