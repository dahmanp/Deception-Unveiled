using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void Exit()
    {
        player.inspectText.SetActive(false);
        player.exitButton.SetActive(false);
    }

    public void acceptQuest()
    {
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
    }

    public void rejectQuest()
    {
        player.inspectText.SetActive(false);
        player.buttons.SetActive(false);
        player.questsFailed++;
    }
}
