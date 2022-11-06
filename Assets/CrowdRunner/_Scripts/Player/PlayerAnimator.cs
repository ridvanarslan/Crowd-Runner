using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [Header(" Elements ")] [SerializeField]
    private Transform runnersParent;
    

    public void Run()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            runnersParent.GetChild(i).GetComponent<Animator>().Play("Run");
        }
    }

    public void Idle()
    {
        for (int i = 0; i < runnersParent.childCount; i++)
        {
            runnersParent.GetChild(i).GetComponent<Animator>().Play("Idle");
        }
    }
}
