using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public float thrust = 1f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPos.z = 0;
        Vector3 dir = cursorPos - transform.position;
        transform.up = dir;
	}

    private void FixedUpdate() {
        anim.SetBool("shipIsMoving", Input.GetButton("Fire1"));
        if (Input.GetButton("Fire1")) {
            rb.AddForce(thrust*transform.up);
       }
    }

    void OnTriggerEnter(Collider other) {
        //will depend what kind of object it is
    }
}
