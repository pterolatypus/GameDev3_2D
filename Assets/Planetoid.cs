using System;
using System.Collections.Generic;
using UnityEngine;

class Planetoid : Orbital {

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

    private int seed, techlevel;
    private bool isGenerated = false;
    

    public Planetoid(int seed) {
        this.seed = seed;
    }

    public bool Generate() {
        if (isGenerated) return false;
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
        return true;
    }
}
