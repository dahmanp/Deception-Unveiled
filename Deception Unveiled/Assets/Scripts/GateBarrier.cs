using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateBarrier : MonoBehaviour
{
    public GameObject interactMenu;
    public TMP_Text interactText;
    private PlayerController player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController potentialPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (potentialPlayer != null)
        {
            player = potentialPlayer;
        }
        interactMenu.SetActive(true);
        interactText.text = "This gate is locked... talk to the villagers?";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            player = null;
        }
        interactMenu.SetActive(false);
    }
}
