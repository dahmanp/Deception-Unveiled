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

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.F))
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
        if (type == LocationType.church)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.graveyard)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.mine)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.forest)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.grove)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.woods)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.library)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.square)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.laboratory)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        else if (type == LocationType.ruins)
        {
            DescribeLocationGood();
            //add desc to inventory
        }
        //Destroy(gameObject);
    }

    void DescribeLocationGood()
    {
        Debug.Log(goodDesc);
    }

    void DescribeLocationBad()
    {
        Debug.Log(goodDesc);
    }
}
