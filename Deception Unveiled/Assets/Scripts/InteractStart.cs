using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractStart : MonoBehaviour
{
    private NPC npc;
    private PlayerController player;
    private bool inRange = false;

    void Start()
    {
        npc = GetComponent<NPC>();
        npc.enabled = false;
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (player.playerInQuest == false)
            {
                npc.enabled = true;
                npc.typeSwitch();
                npc.start();
                this.enabled = false;
                player.playerInQuest = true;
            } else
            {
                Debug.Log("In a quest already!");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController potentialPlayer))
        {
            player = potentialPlayer;
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerController exitingPlayer) && exitingPlayer == player)
        {
            inRange = false;
            player = null;
        }
    }
}