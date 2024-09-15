using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LocationType
{
    church, graveyard, mine, forest, grove, woods, library, square, laboratory, ruins
}

public class Location : MonoBehaviour
{
    public LocationType type;

    void OnTriggerEnter2D(Collider2D collision)
    { //mayhaps an if statement to do the button press interaction thing
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (type == LocationType.church)
        {
            //player("addclue1", player, value);
        }
        else if (type == LocationType.graveyard)
        {
            //player("addclue2", player, value);
        }
        else if (type == LocationType.mine)
        {
            //player("GiveKey", player, value);
        }
        else if (type == LocationType.forest)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.grove)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.woods)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.library)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.square)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.laboratory)
        {
            //player("Sus", player, value);
        }
        else if (type == LocationType.ruins)
        {
            //player("Sus", player, value);
        }
        Destroy(gameObject);
    }
}
