using System;
using System.Collections.Generic;
using UnityEngine;

public class Planetoid : Orbital, Interactable {

    public struct PlanetType {
        public string name { get; private set; }
        public float weight { get; private set;  }
        public PlanetType(string name, float weight) {
            this.name = name;
            this.weight = weight;
        }
    }

    private static PlanetType[] types = {
        new PlanetType("Moon", 1f),
        new PlanetType("Rocky Planet", 1f),
        new PlanetType("Ice Planet", 1f),
        new PlanetType("Ice Giant", 1f),
        new PlanetType("Gas Giant", 1f)
    };

    private static String[] techlevels = {
        "Uninhabited",
        "Agricultural",
        "Industrial",
        "Technological"
    };

    private int techlevel;
    private GameObject prefab;
    private float rotation;
    private List<OrbitalInteraction> interactions;

    public Planetoid(int seed) : base(seed) { }

    new public bool Generate(int orbital) {
        if (!base.Generate(orbital)) return false;
        var r = new System.Random(seed);
        double val = r.NextDouble();
        float div = 0f;
        foreach (PlanetType t in types) {
            div += t.weight;
        }
        float total = 0f;
        PlanetType type = types[types.Length-1];
        foreach (PlanetType t in types) {
            total += t.weight / div;
            if (total > val) {
                type = t;
                break;
            }
        }
        techlevel = r.Next(techlevels.Length);

        if (techlevel > 0) {
            TradeInteraction trade = new TradeInteraction(this, seed);
            trade.Generate(techlevel);
            interactions.Add(trade);
        }
        prefab = Resources.Load("Prefabs/Planets/" + type.name) as GameObject;
        rotation = (int) (360 * r.NextDouble());
        return true;
    }

    public override void Load() {
        int x = (int) (radius * Mathf.Cos(angle));
        int y = (int)(radius * Mathf.Sin(angle));
        gameObject = GameObject.Instantiate(prefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, rotation));
        WorldPlanetoid wp = gameObject.GetComponent<WorldPlanetoid>();
        wp.Source = this;
    }

    public string GetInteractionText() {
        return "Press the interact key to land";
    }

    public void Interact() {
        Debug.Log("Oh no you friccin moron, you just got INTERACTED! Tag your friend to totally INTERACT them.");
    }

}
