using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Info")]
    public float moveSpeed;

    [Header("Components")]
    public Rigidbody2D rig;
    public SpriteRenderer sr;

    public int maxSpace = 4;
    public int curSpace = 0;
    public int locationSpace = 0;

    public int[] inventory;
    public string[] locInventory;

    public NPC npc;
    public NPC_Locations locnpc;
    public NPC_Interview intnpc;

    public bool playerInQuest = false;

    //I WANT THE FOLLOWING PUT INTO GAMEMANAGER BUT IT NO NO WANNA WORK RIGHT NOW
    public GameObject interactText;
    public TMP_Text text_interactText;
    public GameObject inspectText;
    public TMP_Text desc;
    public GameObject buttons;
    public GameObject buttonsInt;
    public GameObject exitButton;
    public GameObject invScreen;
    public TMP_Text hintText;
    public GameObject hintScreen;
    public GameObject locQuestButtons;
    public GameObject quiz;
    public TMP_Text question;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;

    public int questsCompleted;
    public int questsFailed;
    public int totalQuests;
    public bool questEndFail = false;
    public bool questEndWin = false;

    public bool winRest = false;
    public bool failRest = false;
    
    public int collectionHints;
    public int investigationHints;
    public int interviewHints;

    public Image[] itemInvSlots;
    public Sprite[] itemSprites;

    private static PlayerController instance;

    void Update()
    {
        Move();
        sortArray(inventory);
        if (curSpace < 0) {
            curSpace = 0;
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(x, y) * moveSpeed;
    }

    public void addItem(int itemNum)
    {
        inventory[curSpace] = itemNum;
        setSprite(curSpace, itemNum);
        curSpace++;
    }

    void setSprite(int i, int itemNum)
    {
        if (curSpace <= 4)
        {
            itemInvSlots[i].sprite = itemSprites[itemNum - 1];
        }
    }

    public void addLocation(string locationDesc)
    {
        locInventory[locationSpace] = locationDesc;
        locationSpace++;
        // i want this put into a journal of sorts in the order you recieve them
    }

    public int[] sortArray(int[] array)
    {
        int nonZero = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != 0)
            {
                array[nonZero] = array[i];
                itemInvSlots[nonZero].sprite = itemInvSlots[i].sprite;
                nonZero++;
            } else
            {
                itemInvSlots[i].sprite = null;
            }
        }
        for (int i = nonZero; i < array.Length; i++)
        {
            array[i] = 0;
            itemInvSlots[i].sprite = null;
        }
        return array;
    }
}