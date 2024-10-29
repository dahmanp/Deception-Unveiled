using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MayorNPC : MonoBehaviour
{
    //Start: we are assigned to solve the mysterious disappearences of the town
    //We talk to the mayor: They tell us about shapeshifters in the town
    //We set out to help the townspeople: end cutscene and spit player out into the map

    [SerializeField]
    private PlayerControllerTutorial player;

    private bool inRange = false;
    private BoxCollider2D boxCollider;
    public GameObject interact;

    public string[] dialogue;
    public int dialogueCount = 0;

    public Image mayorImage;
    public Sprite[] sprites;
    public int spriteCount = 0;

    public bool spokenTo = false;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerControllerTutorial>();
    }

    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (spokenTo == false)
            {
                start();
                spokenTo = true;
            }
            else
            {
                player.charaImages.SetActive(true);
                player.DialogueBox.SetActive(true);
                player.exitButton.SetActive(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControllerTutorial potentialPlayer = collision.gameObject.GetComponent<PlayerControllerTutorial>();
        if (potentialPlayer != null)
        {
            player = potentialPlayer;
            inRange = true;
        }
        interact.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerTutorial>() == player)
        {
            inRange = false;
            player = null;
        }
        interact.SetActive(false);
    }

    public void start()
    {
        mayorImage.sprite = sprites[spriteCount];
        player.dialogue.text = dialogue[dialogueCount];
        player.charaImages.SetActive(true);
        player.DialogueBox.SetActive(true);
        player.nextButton.SetActive(true);
    }
}