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

    [Header("Current NPCS")]
    public NPC npc;
    public NPC_Locations locnpc;
    public NPC_Interview intnpc;

    public bool playerInQuest = false;

    //I WANT THE FOLLOWING PUT INTO GAMEMANAGER BUT IT NO NO WANNA WORK RIGHT NOW
    public GameObject puzzleTime;
    public GameObject interactText;
    public TMP_Text text_interactText;
    public GameObject inspectText;
    public TMP_Text desc;
    public GameObject buttons;
    public GameObject buttonsInt;
    public GameObject exitButton;
    public GameObject invScreen;
    public GameObject charaImages;
    public TMP_Text hintText;
    public GameObject hintScreen;
    public GameObject locQuestButtons;
    public GameObject quiz;
    public TMP_Text question;
    public TMP_Text answer1;
    public TMP_Text answer2;
    public TMP_Text answer3;

    public TMP_Text dateTime;
    public TMP_Text objective;

    public int questsCompleted;
    public int questsFailed;
    public int totalQuests;
    public bool questEndFail = false;
    public bool questEndWin = false;

    public AudioSource evilLaugh;
    public AudioSource walking;
    public bool currPlaying = false;

    public bool winRest = false;
    public bool failRest = false;
    
    public int collectionHints;
    public int investigationHints;
    public int interviewHints;

    public Image[] itemInvSlots;
    public Sprite[] itemSprites;

    //ANIMATION
    private enum AnimationState { idle, front_walking, back_walking, side_walking }
    private Animator anim;
    Vector2 movement;
    private float directionY = 0f;
    private float directionX = 0f;

    private static PlayerController instance;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        sortArray(inventory);
        if (curSpace < 0) {
            curSpace = 0;
        }
        if (playerInQuest == false)
        {
            objective.text = "Talk to someone around the town of Whispering Pines.";
        }
        walkCycle();
    }

    void Move()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(directionX, directionY) * moveSpeed;

        if (directionY == 0 && directionX == 0)
        {
            walking.Stop();
            currPlaying = false;
        }
        else if (currPlaying == false)
        {
            walking.Play();
            currPlaying = true;
        }
    }

    private void walkCycle()
    {
        AnimationState currState;

        if (directionX > 0f)
        {
            currState = AnimationState.side_walking;
            sr.flipX = false;
            
        }
        else if (directionX < 0f)
        {
            currState = AnimationState.side_walking;
            sr.flipX = true;
        }
        else if (directionY > 0f)
        {
            currState = AnimationState.back_walking;

        }
        else if (directionY < 0f)
        {
            currState = AnimationState.front_walking;
        }
        else
        {
            currState = AnimationState.idle;
        }

        anim.SetInteger("State", (int)currState);
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