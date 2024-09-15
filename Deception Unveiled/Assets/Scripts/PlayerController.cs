using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Info")]
    public float moveSpeed;
    public int gold;
    public int keys;
    public bool dead;

    [Header("Components")]
    public Rigidbody2D rig;
    public SpriteRenderer sr;
    public Animator weaponAnim;

    [Header("Audio")]
    public AudioSource coinA;
    public AudioSource keyA;
    public AudioSource spawn;
    public AudioSource die;

    // Local player
    public static PlayerController me;

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

    public void GiveGold(int goldToGive)
    {
        coinA.Play();
        gold += goldToGive;
        //GameUI.instance.UpdateGoldText(gold);
    }

    public void GiveKey(int keysToGive)
    {
        keyA.Play();
        keys += keysToGive;
        //GameUI.instance.UpdateKeysText(keys);
    }
}