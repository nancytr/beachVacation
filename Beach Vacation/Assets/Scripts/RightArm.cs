using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{

    [SerializeField] private RaycastManager raycastManager;
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

        if (Input.GetMouseButtonDown(0) && raycastManager.IsLookingAtTree)
        {

            anim.SetBool("IsSwinging", true);
            //anim.SetTrigger("Swing");
        }

        else if (Input.GetMouseButton(0) && !raycastManager.IsLookingAtTree)
        {
            //anim.SetBool("IsSwinging", false);
            anim.SetTrigger("Swing");
        }

        else
        {
            anim.SetBool("IsSwinging", false);
        }
    }
}
