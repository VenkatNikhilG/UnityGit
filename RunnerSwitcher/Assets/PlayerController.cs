 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveForce; 

	// Use this for initialization
	void Start () {
		if(Physics.gravity.y > 0)
        {
            Physics.gravity *= -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Physics.gravity *= -1;
        }

        this.GetComponent<Rigidbody>().velocity = new Vector3(moveForce * Time.deltaTime, this.GetComponent<Rigidbody>().velocity.y, this.GetComponent<Rigidbody>().velocity.z);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            GameObject.Destroy(this.gameObject);
        }
        
    }
}
