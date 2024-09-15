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

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (type == PickupType.journal)
        {
            //player("addclue1", player, value);
        }
        else if (type == PickupType.footprints)
        {
            //player("addclue2", player, value);
        }
        else if (type == PickupType.symbols)
        {
            //player("GiveKey", player, value);
        }
        else if (type == PickupType.whispers)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.folklore)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.tome)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.bones)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.chains)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.clothing)
        {
            //player("Sus", player, value);
        }
        else if (type == PickupType.gemstone)
        {
            //player("Sus", player, value);
        }
        Destroy(gameObject);
    }
}
