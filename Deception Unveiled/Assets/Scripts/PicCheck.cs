using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PicCheck : MonoBehaviour
{
    public GameObject[] rowA;
    public GameObject[] rowB;
    public GameObject[] rowC;
    public GameObject[] rowD;

    public bool Acheck = true;
    public bool Bcheck = true;
    public bool Ccheck = true;
    public bool Dcheck = true;
    public bool puzzleComplete = false;
    public bool puzzleEnd = false;

    private float timer = 30f;
    private bool timerRunning = true;

    public TMP_Text timerText;

    void Awake()
    {
        Acheck = testing(rowA, ref Acheck);
        Bcheck = testing(rowB, ref Bcheck);
        Ccheck = testing(rowC, ref Ccheck);
        Dcheck = testing(rowD, ref Dcheck);

        timerRunning = true;
    }

    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                CheckPuzzle();
                timerRunning = false;
            }
        }

        timerText.text = timer.ToString("F2");

        if (timerRunning)
        {
            Acheck = testing(rowA, ref Acheck);
            Bcheck = testing(rowB, ref Bcheck);
            Ccheck = testing(rowC, ref Ccheck);
            Dcheck = testing(rowD, ref Dcheck);

            puzzleComplete = Acheck && Bcheck && Ccheck && Dcheck;
        }
    }

    void CheckPuzzle()
    {
        if (puzzleComplete)
        {
            Debug.Log("correct");
        }
        else
        {
            Debug.Log("git gud");
        }
        puzzleEnd = true;
    }

    bool testing(GameObject[] row, ref bool check)
    {
        foreach (GameObject block in row)
        {
            if (!block.GetComponent<PicShift>().correct)
            {
                return false;
            }
        }
        return true;
    }
}

