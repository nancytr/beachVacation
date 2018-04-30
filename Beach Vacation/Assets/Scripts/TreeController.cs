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

    // Use this for initialization
    void Start () {
        rbTree = GetComponent<Rigidbody>();
        rbTree.isKinematic = true;
        tree = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        if (treeHealth <= 0)
        {
            rbTree.isKinematic = false;
            rbTree.AddForce(transform.forward * speed);
            StartCoroutine(destroyTree());

            FMODUnity.RuntimeManager.PlayOneShot(fallingSound);
        }
	}

    IEnumerator destroyTree()
    {

        
        //Destroy(this);
        yield return new WaitForSeconds(3);

        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(logs, this.transform.position + new Vector3(0, 0, 0) + position, this.transform.rotation);
        Instantiate(logs, this.transform.position + new Vector3(1, 1, 0) + position, this.transform.rotation);
        Instantiate(logs, this.transform.position + new Vector3(2, 2, 0) + position, this.transform.rotation);

        Destroy(gameObject);
        Destroy(this);

        

        //Instantiate(coconut, this.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
    }
}
