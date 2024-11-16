using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PicShift : MonoBehaviour
{
    public int num;
    public int key;
    public bool correct = false;

    public void test()
    {
        this.gameObject.transform.Rotate(0.0f, 0.0f, 90.0f, Space.Self);
        num++;
        if (num == 4)
        {
            num = 0;
        }
    }

    void Update()
    {
        if (num == key)
        {
            correct = true;
        }
        else
        {
            correct = false;
        }
    }
}
