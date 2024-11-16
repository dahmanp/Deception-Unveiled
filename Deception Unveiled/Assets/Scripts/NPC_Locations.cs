using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum LocQuest
{
    quest1, quest2, quest3, quest4, quest5
}

public class NPC_Locations : MonoBehaviour
{
    private PlayerController player;
    private RestPeriod rp;
    private GameManager gm;
    private bool inRange = false;
    public LocQuest quest;
    public GameObject interact;

    public int image_id;
    public SpriteRenderer groundImage;

    private BoxCollider2D boxCollider;

    public string[] intros;
    public string[] fails;
    public string[] wins;
    public string[] hints;
    public int[] answers;
    public string[] objectives;

    public int response = 0;

    public string intro;
    public int answer;
    public string fail;
    public string win;
    public string hint;

    public bool inQuest = false;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        gm = FindObjectOfType<GameManager>();
        rp = FindObjectOfType<RestPeriod>();
    }

    void Start()
    {
        groundImage.sprite = gm.npc_sprites[image_id];
    }

    void Update()
    {
        if (inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if (player.playerInQuest == false)
            {
                typeSwitch();
                start();
            } else
            {
                Debug.Log("In a quest already!");
            }
        }
        if (inQuest==true && response!=0)
        {
            player.locQuestButtons.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            inRange = true;
        }
        interact.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
        }
        interact.SetActive(false);
    }

    void setDialogue(int i)
    {
        intro = intros[i];
        win = wins[i];
        fail = fails[i];
        answer = answers[i];
        hint = hints[i];
        player.objective.text = objectives[i];
    }

    void typeSwitch()
    {
        if (quest == LocQuest.quest1)
        {
            setDialogue(0);
        }
        else if (quest == LocQuest.quest2)
        {
            setDialogue(1);
        }
        else if (quest == LocQuest.quest3)
        {
            setDialogue(2);
        }
        else if (quest == LocQuest.quest4)
        {
            setDialogue(3);
        }
        else if (quest == LocQuest.quest5)
        {
            setDialogue(4);
        }
    }

    void start()
    {
        player.charaImages.SetActive(true);
        gm.image_mc.sprite = gm.neutral_mc;
        gm.npc_image.sprite = gm.neutral[image_id];

        player.playerInQuest = true;
        player.locnpc = this;
        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
        interact.SetActive(false);

        if (player.investigationHints > 0)
        {
            player.hintText.text = hint;
            player.hintScreen.SetActive(true);
            player.investigationHints--;
        }
    }

    public void check()
    {
        if (response == answer)
        {
            gm.image_mc.sprite = gm.happy_mc;
            gm.npc_image.sprite = gm.happy[image_id];

            player.desc.text = win;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.hintScreen.SetActive(false);
            inQuest = false;
            player.questsCompleted++;
            player.totalQuests++;

            //rp.WinRest();
            player.questEndWin = true;
            player.playerInQuest = false;

            Destroy(this.gameObject);
        } else
        {
            gm.image_mc.sprite = gm.sad_mc;
            gm.npc_image.sprite = gm.angry[image_id];

            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.hintScreen.SetActive(false);
            inQuest = false;
            player.questsFailed++;
            player.totalQuests++;

            //rp.FailRest();
            player.questEndFail = true;
            player.playerInQuest = false;

            Destroy(this.gameObject);
        }
    }
}
