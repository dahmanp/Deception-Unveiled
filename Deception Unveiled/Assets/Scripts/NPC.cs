using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum ItemQuest
{
    quest1, quest2, quest3, quest4, quest5, quest6, quest7, quest8, quest9, quest10
}

public class NPC : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;
    private GameManager gm;
    private RestPeriod rp;

    public int image_id;
    public SpriteRenderer groundImage;

    private bool inRange = false;
    public ItemQuest quest;
    private BoxCollider2D boxCollider;
    public GameObject interact;

    public string[] intros;
    public string[] fails;
    public string[] wins;
    public string[] hints;
    public int[] answers;
    public string[] objectives;

    public string intro;
    public int answer;
    public string fail;
    public string win;
    public string hint;

    public bool inQuest = false;

    public int response;

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
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            if (inQuest == false)
            {
                if (player.playerInQuest == false)
                {
                    typeSwitch();
                    start();
                    player.playerInQuest = true;
                }
                else
                {
                    Debug.Log("In a quest already!");
                }
            }
            else if (inQuest == true)
            {
                player.charaImages.SetActive(true);
                selectOption();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController potentialPlayer = collision.gameObject.GetComponent<PlayerController>();
        if (potentialPlayer != null)
        {
            player = potentialPlayer;
            inRange = true;
        }
        interact.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == player)
        {
            inRange = false;
            player = null;
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

    public void typeSwitch()
    {
        if (quest == ItemQuest.quest1)
        {
            setDialogue(0);
        }
        else if (quest == ItemQuest.quest2)
        {
            setDialogue(1);
        }
        else if (quest == ItemQuest.quest3)
        {
            setDialogue(2);
        }
        else if (quest == ItemQuest.quest4)
        {
            setDialogue(3);
        }
        else if (quest == ItemQuest.quest5)
        {
            setDialogue(4);
        }
        else if (quest == ItemQuest.quest6)
        {
            setDialogue(5);
        }
        else if (quest == ItemQuest.quest7)
        {
            setDialogue(6);
        }
        else if (quest == ItemQuest.quest8)
        {
            setDialogue(7);
        }
        else if (quest == ItemQuest.quest9)
        {
            setDialogue(8);
        }
        else if (quest == ItemQuest.quest10)
        {
            setDialogue(9);
        }
    }

    public void start()
    {
        player.charaImages.SetActive(true);
        gm.image_mc.sprite = gm.neutral_mc;
        gm.npc_image.sprite = gm.neutral[image_id];

        player.playerInQuest = true;
        player.npc = this;
        if (player == null)
        {
            return;
        }

        player.desc.text = intro;
        player.inspectText.SetActive(true);
        player.buttons.SetActive(true);
        inQuest = true;
        interact.SetActive(false);

        if (player.collectionHints > 0)
        {
            player.hintText.text = hint;
            player.hintScreen.SetActive(true);
            player.collectionHints--;
        }
    }

    public void selectOption()
    {
        if (player == null)
        {
            return;
        }
        player.invScreen.SetActive(true);
        player.exitButton.SetActive(true);
    }

    public void check()
    {
        if (player == null)
        {
            return;
        }
        if (!inQuest)
        {
            return;
        }

        if (response == answer)
        {
            gm.image_mc.sprite = gm.happy_mc;
            gm.npc_image.sprite = gm.happy[image_id];

            player.desc.text = win;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.invScreen.SetActive(false);
            player.hintScreen.SetActive(false);

            inQuest = false;

            player.questsCompleted++;
            player.totalQuests++;

            //rp.WinRest();
            player.questEndWin = true;
            player.curSpace--;
            if (player.curSpace < 0) {
                player.curSpace = 0;
            }
            player.sortArray(player.inventory);
            player.playerInQuest = false;

            Destroy(this.gameObject);
        } else
        {
            gm.image_mc.sprite = gm.sad_mc;
            gm.npc_image.sprite = gm.angry[image_id];

            player.desc.text = fail;
            player.inspectText.SetActive(true);
            player.exitButton.SetActive(true);
            player.invScreen.SetActive(false);
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
