using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerControllerTutorial : MonoBehaviour
{
    [Header("Info")]
    public float moveSpeed;
    public string objective;

    [Header("Components")]
    public Rigidbody2D rig;
    public SpriteRenderer sr;

    [Header("Screens")]
    public TMP_Text objectiveText;
    public GameObject DialogueBox;
    public TMP_Text dialogue;
    public GameObject charaImages;
    public GameObject nextButton;
    public GameObject exitButton;
    public GameObject interactText;
    public GameObject journalButton;
    public TMP_Text text_interactText;
    public GameObject puzzleTime;

    private MayorNPC mayor;
    private ToMainTrigger mainTrigger;

    [Header("MC Image")]
    public Image mcImage;
    public Sprite[] sprites;
    public int spriteCount = 0;

    public AudioSource walking;
    public bool currPlaying = false;

    //ANIMATION
    private enum AnimationState { idle, front_walking, back_walking, side_walking }
    private Animator anim;
    Vector2 movement;
    private float directionY = 0f;
    private float directionX = 0f;

    private static PlayerControllerTutorial instance;

    void Start()
    {
        mayor = FindObjectOfType<MayorNPC>();
        mainTrigger = FindObjectOfType<ToMainTrigger>();
        objective = "Speak to the mayor of the town to learn more about your assignment.";
        objectiveText.text = objective;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        walkCycle();
    }

    public void NextButton()
    {
        if (mayor.dialogueCount+1 < 3)
        {
            mayor.dialogueCount++;
            mayor.spriteCount++;
            spriteCount++;
            mayor.mayorImage.sprite = mayor.sprites[mayor.spriteCount];
            mcImage.sprite = sprites[spriteCount];
            dialogue.text = mayor.dialogue[mayor.dialogueCount];
        } else
        {
            mayor.dialogueCount++;
            mayor.spriteCount++;
            spriteCount++;
            mayor.mayorImage.sprite = mayor.sprites[mayor.spriteCount];
            mcImage.sprite = sprites[spriteCount];
            dialogue.text = mayor.dialogue[mayor.dialogueCount];
            nextButton.SetActive(false);
            exitButton.SetActive(true);
        }
    }

    public void ExitButton()
    {
        nextButton.SetActive(false);
        exitButton.SetActive(false);
        DialogueBox.SetActive(false);
        charaImages.SetActive(false);
        objectiveText.text = "Continue forward to the town.";
        mainTrigger.mayorCompleted = true;
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
}