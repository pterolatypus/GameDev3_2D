using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Close() {
        GameObject.Destroy(this);
    }

    public void AddTab(OrbitalInteraction interaction) {

    }
}
