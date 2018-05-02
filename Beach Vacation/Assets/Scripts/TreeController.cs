using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    [SerializeField] public int treeHealth = 5;
    [SerializeField] private Transform logs;
    [SerializeField] private Transform coconut;

    [SerializeField] public static GameObject tree = null;

    [FMODUnity.EventRef]
    public string fallingSound;

    [SerializeField] public int speed = 8;

    public Rigidbody rbTree;

    private Transform treeTransform;
    private Vector3 treeVector;

    private bool soundOn;

    // Use this for initialization
    void Start () {
        rbTree = GetComponent<Rigidbody>();
        rbTree.isKinematic = true;
        tree = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        // treeTransform = tree.GetComponent<Transform>().transform;
        treeVector = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);

        if (treeHealth <= 0)
        {
            rbTree.isKinematic = false;
            rbTree.AddForce(transform.forward * speed);
            StartCoroutine(destroyTree());

            PlaySound();


        }
	}

    IEnumerator destroyTree()
    {

        
        //Destroy(this);
        yield return new WaitForSeconds(3);

        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(logs, this.transform.position + new Vector3(0, 0, 0) + position, this.transform.rotation);
        // Instantiate(logs, this.transform.position + new Vector3(1, 1, 0) + position, this.transform.rotation);
        // Instantiate(logs, this.transform.position + new Vector3(2, 2, 0) + position, this.transform.rotation);

        Destroy(gameObject);
        Destroy(this);

        

        //Instantiate(coconut, this.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
    }

    void PlaySound()
    {
        if(!soundOn)
        {
            soundOn = true;
            FMODUnity.RuntimeManager.PlayOneShot(fallingSound, treeVector);

            Invoke("TurnOffSound", 5f);
        }    
            
    }

    void TurnOffSound()
    {
        soundOn = false;
    }
}
