using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipController : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    public float thrust = 1f;
    private float animSpeedMin = 0.5f, animSpeedMax = 2f;
    private float maxSpeed = 1f;
    [SerializeField]
    private Text txtInteract;
    private Interactable interactionTarget;

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
        if (Input.GetButtonDown("Interact") && interactionTarget != null) {
            interactionTarget.Interact();
        }
	}

    private void FixedUpdate() {
        anim.SetBool("shipIsMoving", Input.GetButton("Forward"));
        float thrust = (Input.GetButton("Boost")) ? this.thrust*4 : this.thrust;
        if (Input.GetButton("Forward")) {
            rb.AddForce(thrust*transform.up);
        }
        float curSpd = GetComponent<Rigidbody2D>().velocity.magnitude;
        maxSpeed = Mathf.Max(curSpd, maxSpeed);
        float animSpeed = animSpeedMin + (curSpd / maxSpeed) * (animSpeedMax - animSpeedMin);
        anim.SetFloat("animSpeed", animSpeed);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<WorldOrbital>().Source is Interactable) {
            SetInteractionTarget((Interactable)other.gameObject.GetComponent<WorldOrbital>().Source);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<WorldOrbital>().Source is Interactable) {
            SetInteractionTarget(null);
        }
    }

    private void SetInteractionTarget(Interactable interactable) {
        interactionTarget = interactable;
        if (interactionTarget == null) {
            txtInteract.gameObject.SetActive(false);
        } else {
            string text = interactable.GetInteractionText();
            txtInteract.text = text;
            txtInteract.gameObject.SetActive(true);
        }
    }
}