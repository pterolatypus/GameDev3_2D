using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int numberOfSystems = 100;
    Galaxy g;
	// Use this for initialization
	void Awake () {
        g = new Galaxy(numberOfSystems);
        LoadSystem(g.home);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadSystem(StarSystem star) {
        star.Load();
    }

}
