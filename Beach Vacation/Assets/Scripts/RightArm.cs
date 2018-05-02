﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{

    [SerializeField] private RaycastManager raycastManager;
    public bool hasSwung = false;

    [FMODUnity.EventRef]
    public string hittingSound;
    [FMODUnity.EventRef]
    public string chopSound;
    [FMODUnity.EventRef]
    public string hurtSound;

    Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && (raycastManager.IsLookingAtTree))
        {

            anim.SetBool("IsSwinging", true);
            //anim.SetTrigger("Swing");
        }

        else if (Input.GetMouseButtonDown(0) && (raycastManager.IsLookingAtCreature))
        {
            
            anim.SetTrigger("IsSwinging");

        }

        else if (Input.GetMouseButton(0) && !raycastManager.IsLookingAtTree)
        {
            //anim.SetBool("IsSwinging", false);
            anim.SetTrigger("Swing");
            
            // FMODUnity.RuntimeManager.PlayOneShot(chopSound, treeVector);
        }

        else
        {
            anim.SetBool("IsSwinging", false);
        }
    }
}
