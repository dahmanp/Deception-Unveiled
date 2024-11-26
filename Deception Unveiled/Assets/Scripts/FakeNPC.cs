using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FakeNPC : MonoBehaviour
{
    private PlayerController player;
    private bool inRange = false;
    //public Sprite[] sprites;
    public int option;

    void Awake()
    {
        option = Random.Range(0, 4);
        //this.GetComponent<SpriteRenderer>().sprite = sprites[option];
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            player.questsFailed++;
            player.totalQuests++;
            Destroy(gameObject);
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
        player.text_interactText.text = "E to Interact";
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.interactText.SetActive(false);
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
    }
}
