using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour {

    [SerializeField] public int treeHealth = 5;
    [SerializeField] private Transform logs;
    [SerializeField] private Transform coconut;

    [SerializeField] public static GameObject tree = null;



    [SerializeField] private int speed = 8;

    Rigidbody rbTree;

    // Use this for initialization
    void Start () {
        Rigidbody rbTree = GetComponent<Rigidbody>();
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
        }
	}

    IEnumerator destroyTree()
    {
        yield return new WaitForSeconds(7);
        Destroy(tree);

        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(logs, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        Instantiate(logs, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);

        Instantiate(coconut, tree.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        Instantiate(coconut, tree.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        Instantiate(coconut, tree.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
    }
}
