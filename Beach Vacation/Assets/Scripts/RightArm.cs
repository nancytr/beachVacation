using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{

    [SerializeField] private RaycastManager raycastManager;
    public bool hasSwung = false;

    [FMODUnity.EventRef]
    public string hitSound;
    [FMODUnity.EventRef]
    public string chopSound;
    [FMODUnity.EventRef]
    public string hurtSound;
    [FMODUnity.EventRef]
    public string rockSound;

    Animator anim;

    //private RaycastManager raycast;
    //private Vector3 treeLoc;
    //private Vector3 creatureLoc;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1) && (raycastManager.IsLookingAtTree))
        {

            anim.SetBool("IsSwinging", true);
            //anim.SetTrigger("Swing");

            Invoke("ChopSound", .8f);
        }

        else if (Input.GetMouseButtonDown(1) && (raycastManager.IsLookingAtCreature))
        {
            
            anim.SetTrigger("IsSwinging");

            if (raycastManager.llama)
            {
                Invoke("HitSound", .8f);
                Invoke("HurtSound", .8f);
                print ("llama");
            }
            else if (raycastManager.rock)
            {
                Invoke("RockSound", .8f);
                print ("rock");

            }
        }

        else if (Input.GetMouseButton(1) && !raycastManager.IsLookingAtTree)
        {
            //anim.SetBool("IsSwinging", false);
            anim.SetTrigger("Swing");
            

        }

        else
        {
            anim.SetBool("IsSwinging", false);
        }
    }

    void HitSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hitSound);
    }

    void ChopSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(chopSound);
    }

    void HurtSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(hurtSound, raycastManager.creatureVector);
    }

    void RockSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(rockSound, raycastManager.creatureVector);
    }
}
