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

    //I WANT THE FOLLOWING PUT INTO GAMEMANAGER BUT IT NO NO WANNA WORK RIGHT NOW
    public GameObject interactText;
    public GameObject inspectText;
    public TMP_Text desc;
    public GameObject buttons;
    public GameObject exitButton;

    public int questsCompleted;
    public int questsFailed;
    public bool questEndFail = false;
    public bool questEndWin = false;
    //if the quest is done and you got the right answer, you can choose an option in the rest period
    //if the quest is done but you fail, you get to do nothing and the shapeshifter gets to do something
    public int collectionHints;
    public int investigationHints;

    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rig.velocity = new Vector2(x, y) * moveSpeed;
    }

    public void addItem(int itemNum)
    {
        inventory[locationSpace] = itemNum;
        locationSpace++;
        // add this to ui inventory slots at some point
    }

    public void addLocation(string locationDesc)
    {
        locInventory[locationSpace] = locationDesc;
        locationSpace++;
        //add a way to make sure there are no duplicates
        // i want this put into a journal of sorts in the order you recieve them
    }

    public int[] sortArray(int[] array)
    {
        int nonZero = 0;

        for (int i = 0; i < array.Length; i++)
        {
            Debug.Log("test");
            if (array[i] != 0)
            {
                Debug.Log("yuh");
                array[nonZero] = array[i];
                nonZero++;
            }
        }
        for (int i = nonZero; i < array.Length; i++)
        {
            Debug.Log("no");
            array[i] = 0;
        }
        return array;
    }
}