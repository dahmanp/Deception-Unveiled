using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Info")]
    public float moveSpeed;

    [Header("Components")]
    public Rigidbody2D rig;
    public SpriteRenderer sr;

    private int maxSpace = 4;
    private int curSpace = 0;

    public int[] inventory;

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
        if (curSpace < maxSpace)
        {
            inventory[curSpace] = itemNum;
            curSpace++;
            Debug.Log("Added to inventory!");
        } else
        {
            Debug.Log("Too full!");
        }  
    }
}