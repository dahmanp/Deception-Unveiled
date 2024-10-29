using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Player Info")]
    public GameObject playerObj;
    public PlayerController player;

    [Header("Locations")]
    public GameObject[] itemLocations;
    public GameObject[] npcLocations;

    [Header("Prefabs")]
    public GameObject[] NPC_Prefabs;
    public GameObject[] NPC_Location_Prefabs;
    public GameObject[] NPC_Interview_Prefabs;
    public GameObject[] items_surface;
    public GameObject[] items_deepEnd;

    [Header("NPC UI")]
    public Sprite[] angry;
    public Sprite[] happy;
    public Sprite[] neutral;
    public Image npc_image;

    [Header("NPC Images")]
    public Sprite[] npc_sprites;

    [Header("MC UI")]
    public Sprite sad_mc;
    public Sprite happy_mc;
    public Sprite neutral_mc;
    public Image image_mc;

    [Header("Misc")]
    public GameObject barrier;
    private int selection; //number corresponds to an assortment

    [Header("Screens")]
    public GameObject endWin;
    public GameObject endLose;
    public GameObject failedMenu;


    //consider: after rest period, you enter a dream sequence? maybe you walk around the town at night and the shapeshifter chases you? a later thing

    void Awake()
    {
        image_mc.sprite = neutral_mc;
        instance = this;
        selection = Random.Range(0, 4);
        player = playerObj.GetComponent<PlayerController>();
        spawnNPCS(selection);
        spawnItems(selection);
    }

    //LOCATION QUESTS: quests 1-2 are SURFACE, quests 3-5 are DEEP END
    //ITEM QUESTS: quests 1-5 are SURFACE, quests 6-10 are DEEP END
    //ITEMS: gemstone, tome, clothing, folklore, and whispers are SURFACE, footprints, chains, symbols, bones, and journal are DEEP END
    //INFO QUESTS: quests 1-3 are SURFACE, quests 4-5 are DEEP END

    void spawnNPCS(int npcInterval)
    {
        //Surface
        int[][] surfaceNPC_index = {
            new int[] { 0, 1, 2, 0, 0 },
            new int[] { 2, 3, 4, 1, 1 },
            new int[] { 0, 3, 4, 0, 2 },
            new int[] { 1, 2, 3, 1, 0 },
            new int[] { 1, 4, 0, 0, 1 }
        };

        int[][] surfaceLocation_index = {
            new int[] { 0, 1, 2, 3, 4 },
            new int[] { 3, 4, 0, 1, 2 },
            new int[] { 2, 3, 4, 0, 1 },
            new int[] { 1, 2, 3, 4, 0 },
            new int[] { 4, 3, 2, 1, 0 }
        };

        for (int i = 0; i < surfaceNPC_index[npcInterval].Length; i++)
        {
            GameObject npcInLine;
            if (i < 3)
            {
                npcInLine = Instantiate(NPC_Prefabs[surfaceNPC_index[npcInterval][i]], npcLocations[surfaceLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            else if (i == 3)
            {
                npcInLine = Instantiate(NPC_Location_Prefabs[surfaceNPC_index[npcInterval][i]], npcLocations[surfaceLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            else
            {
                npcInLine = Instantiate(NPC_Interview_Prefabs[surfaceNPC_index[npcInterval][i]], npcLocations[surfaceLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            SetImageId(npcInLine, i);
        }

        //Deep End
        int[][] deepEndNPC_index = {
            new int[] { 5, 6, 9, 2, 3 },
            new int[] { 5, 7, 8, 3, 4 },
            new int[] { 6, 7, 8, 4, 3 },
            new int[] { 6, 8, 9, 2, 4 },
            new int[] { 7, 8, 9, 3, 3 }
        };

        int[][] deepEndLocation_index = {
            new int[] { 5, 6, 7, 8, 9 },
            new int[] { 6, 7, 8, 9, 5 },
            new int[] { 7, 8, 9, 5, 6 },
            new int[] { 8, 9, 5, 6, 7 },
            new int[] { 9, 8, 7, 6, 5 }
        };

        for (int i = 0; i < deepEndNPC_index[npcInterval].Length; i++)
        {
            GameObject npcInLine;
            if (i < 3)
            {
                npcInLine = Instantiate(NPC_Prefabs[deepEndNPC_index[npcInterval][i]], npcLocations[deepEndLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            else if (i == 3)
            {
                npcInLine = Instantiate(NPC_Location_Prefabs[deepEndNPC_index[npcInterval][i]], npcLocations[deepEndLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            else
            {
                npcInLine = Instantiate(NPC_Interview_Prefabs[deepEndNPC_index[npcInterval][i]], npcLocations[deepEndLocation_index[npcInterval][i]].transform.position, Quaternion.identity);
            }
            SetImageId(npcInLine, i + 5);
        }
    }

    void SetImageId(GameObject npcInLine, int id)
    {
        NPC npc = npcInLine.GetComponent<NPC>();
        if (npc != null)
        {
            npc.image_id = id;
            return;
        }

        NPC_Interview intnpc = npcInLine.GetComponent<NPC_Interview>();
        if (intnpc != null)
        {
            intnpc.image_id = id;
            return;
        }

        NPC_Locations locnpc = npcInLine.GetComponent<NPC_Locations>();
        if (locnpc != null)
        {
            locnpc.image_id = id;
            return;
        }
    }

    void spawnItems(int itemInterval)
    {
        //Surface
        for (int i = 0; i < 5; i++)
        {
            int positionIndex_surface = (i + itemInterval) % 5;
            Instantiate(items_surface[i], itemLocations[positionIndex_surface].transform.position, Quaternion.identity);
        }

        //Deep End
        for (int i = 0; i < 5; i++)
        {
            int positionIndex_deepEnd = (i + itemInterval + 5) % 5 + 5;
            Instantiate(items_deepEnd[i], itemLocations[positionIndex_deepEnd].transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        if (player.totalQuests >=5)
        {
            barrier.SetActive(false);
        }
        if (player.totalQuests >=10)
        {
            if (player.questsCompleted >= player.questsFailed)
            {
                endWin.SetActive(true);
                endWin.GetComponent<IntroCutscene>().enabled = true;
                if (endWin.GetComponent<IntroCutscene>().completed == true)
                {
                    SceneManager.LoadScene("Epilogue");
                }
            }
            else if (player.questsCompleted < player.questsFailed)
            {
                endLose.SetActive(true);
                endLose.GetComponent<IntroCutscene>().enabled = true;
                if (endLose.GetComponent<IntroCutscene>().completed == true)
                {
                    endLose.SetActive(false);
                    failedMenu.SetActive(true);
                }
            }
        }
    }
}
