using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaycastManager : MonoBehaviour
{
    private GameObject raycastedObj;

    [Header("Raycast Settings")]
    [SerializeField] private float rayLength = 10;
    [SerializeField] private LayerMask newLayerMask;

    [Header("References")]
    [SerializeField] private Image crossHair;
    [SerializeField] private Text itemNameText;
    [SerializeField] private PlayerVitals playerVitals;

    // Tree Stuff
    [SerializeField] private TreeController treeController;
    [SerializeField] private RightArm rightArm;
    private Animator armAnim;

    private exit theArmAnimation;

    public bool hasSwung = false;

    void Start()
    {
        theArmAnimation = armAnim.GetBehaviour<exit>();
        theArmAnimation.rayCast = this;
    }

    void Awake()
    {
        armAnim = GetComponent<Animator>();
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, newLayerMask.value))
        {
            if (hit.collider.CompareTag("Consumable"))
            {
                CrosshairActive();
                raycastedObj = hit.collider.gameObject;
                // update UI name
                //itemNameText.text = raycastedObj.GetComponent<ItemProperties>().itemName;
                ItemProperties properties = raycastedObj.GetComponent<ItemProperties>();
                itemNameText.text = properties.itemName;

                if (Input.GetMouseButtonDown(0))
                {
                    //Object properties
                    //raycastedObj.GetComponent<ItemProperties>().Interaction();
                    //raycastedObj.SetActive(false);
                    properties.Interaction(playerVitals);
                }
                
            }
            // tree stuff
            
            if (hit.collider.gameObject.tag == "Tree")
            {
                treeController = GameObject.Find(hit.collider.gameObject.name).GetComponent<TreeController>();
                armAnim.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Swing2");
                //armAnim = GameObject.Find("Swing2").GetComponent<RightArm>();
                //Debug.Log(theArmAnimation.hasSwung);
                if (hasSwung)
                {
                    Debug.Log("yayayayay");
                    treeController.treeHealth -= 1;
                }
                //hasSwung = false;
            }
        }

        else
        {
            CrosshairNormal();
            // item name back to normal
            itemNameText.text = null;
        }
        hasSwung = false;
    }

    void CrosshairActive()
    {
        crossHair.color = Color.red;
    }

    void CrosshairNormal()
    {
        crossHair.color = Color.white;
    }


}
