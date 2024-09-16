using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Info")]
    public float moveSpeed;

    [Header("Components")]
    public Rigidbody2D rig;
    public SpriteRenderer sr;

    public int maxSpace = 4;
    public int curSpace = 0;

    public int[] inventory;
    public int[] locInventory;

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
        inventory[curSpace] = itemNum;
        curSpace++;
        // add this to ui inventory slots at some point
    }

    public void addLocation(int locationNum)
    {
        //locInventory[curSpace] = itemNum;
        //curSpace++;
        // i want this put into a journal of sorts in the order you recieve them
    }
}