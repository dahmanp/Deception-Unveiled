using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalMap : MonoBehaviour
{
    public GameObject[] blocks;
    public GameObject[] checks;

    public Image playerMark;
    public RectTransform mapRectTransform;
    public Transform playerLoc;

    public Vector2 worldMin = new Vector2(-1110, -660);
    public Vector2 worldMax = new Vector2(1110, 660);

    private void Update()
    {
        Vector3 playerPosition = playerLoc.position;
        Vector2 mapPosition = MapCalculation(playerPosition);
        playerMark.rectTransform.localPosition = mapPosition;
    }

    Vector2 MapCalculation(Vector3 worldPosition)
    {
        float normalizedX = (worldPosition.x - worldMin.x) / (worldMax.x - worldMin.x);
        float normalizedY = (worldPosition.y - worldMin.y) / (worldMax.y - worldMin.y);

        float mapWidth = mapRectTransform.rect.width;
        float mapHeight = mapRectTransform.rect.height;

        Vector2 mapPosition = new Vector2(normalizedX * mapWidth, normalizedY * mapHeight);

        mapPosition -= new Vector2(mapWidth / 2, mapHeight / 2);

        mapPosition.x = Mathf.Clamp(mapPosition.x, -mapWidth / 2, mapWidth / 2);
        mapPosition.y = Mathf.Clamp(mapPosition.y, -mapHeight / 2, mapHeight / 2);

        return mapPosition;
    }

    public void unlockSection(int i)
    {
        blocks[i].SetActive(false);
    }

    public void checkNPC(int i)
    {
        checks[i].SetActive(true);
    }
}
