using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour {

    [SerializeField] public int creatureHealth = 3;
    [SerializeField] private Transform DropOnKill;
    //[SerializeField] private Transform coconut;

    [SerializeField] public static GameObject tree = null;

    [FMODUnity.EventRef]
    public string hurtSound;

    [SerializeField] public int speed = 8;

    public Rigidbody rbTree;
    public Vector3 llamaVector;

    // Use this for initialization
    void Start () {
        rbTree = GetComponent<Rigidbody>();
        //rbTree.isKinematic = true;
        tree = this.gameObject;

	}
	
	// Update is called once per frame
	void Update () {
        llamaVector = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
        
        if (creatureHealth <= 0)
        {
            rbTree.isKinematic = false;
            rbTree.constraints = RigidbodyConstraints.None;
            rbTree.AddForce(transform.forward * speed);
            StartCoroutine(destroyTree());

            FMODUnity.RuntimeManager.PlayOneShot(hurtSound);
        }
	}

    IEnumerator destroyTree()
    {

        
        //Destroy(this);
        yield return new WaitForSeconds(2);

        Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        Instantiate(DropOnKill, this.transform.position + new Vector3(0, 0, 0) + position, this.transform.rotation);
        //Instantiate(DropOnKill, this.transform.position + new Vector3(1, 1, 0) + position, this.transform.rotation);
        //Instantiate(DropOnKill, this.transform.position + new Vector3(2, 2, 0) + position, this.transform.rotation);

        Destroy(gameObject);
        Destroy(this);

        

        //Instantiate(coconut, this.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
        //Instantiate(coconut, this.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
    }
}
