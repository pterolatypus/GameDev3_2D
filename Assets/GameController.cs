using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int numberOfSystems = 1000;
    Galaxy g;
	// Use this for initialization
	void Start () {
        g = new Galaxy(numberOfSystems);
        LoadSystem(g.home);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadSystem(StarSystem star) {
        
    }

}
