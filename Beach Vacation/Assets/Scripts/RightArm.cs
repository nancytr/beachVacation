﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{

    public bool hasSwung = false;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Swing");
        }

        if (Input.GetMouseButton(1))
        {
            anim.SetBool("IsSwinging", true);
        }
        else
        {
            anim.SetBool("IsSwinging", false);
        }
    }
}
