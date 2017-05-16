using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int numberOfSystems = 100;
    public WorldUI radar;
    Galaxy g;
	// Use this for initialization
	void Awake () {
        g = new Galaxy(numberOfSystems);
        LoadSystem(g.home);
        foreach (GameObject obj in g.home) {
            if (obj == null) continue;
            radar.AddTrackingObject(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadSystem(StarSystem star) {
        star.Load();
    }

}
