using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] itemLocations;
    public GameObject[] npcLocations;

    public GameObject NPC_Prefab;
    public GameObject NPC_Location_Prefab;
    public GameObject NPC_Interview_Prefab;
    public GameObject item;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }
}
