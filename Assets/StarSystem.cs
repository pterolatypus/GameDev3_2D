using System;
using System.Collections.Generic;
using UnityEngine;

class StarSystem
{

    static readonly String[] sizes = {
        "Dwarf",
        "Star",
        "Giant",
        "Supergiant"
    };

    static readonly String[] temps = {
        "Red",
        "Yellow",
        "White",
        "Blue"
    };

    public Vector2 coords { get; private set; }
    public int seed { get; private set; }
    public String type {
        get { return temps[temp] + " " + sizes[size]; }
    }

    private bool isGenerated = false;
    private int temp, size;
    private List<Orbital> satellites = new List<Orbital>();


    public StarSystem(Vector2 coords, int seed) {
        this.coords = coords;
        this.seed = seed;
    }

    public bool Generate() {
        if (isGenerated) return false;
        var rand = new System.Random(seed);
        temp = rand.Next(temps.Length);
        size = rand.Next(sizes.Length);
        int numOrbits = 5 * (size + 1);
        for (int i = 0; i < numOrbits; i++) {
            double r = rand.NextDouble();
            if (r < 0.5) {
                Planetoid p = new Planetoid(rand.Next());
                satellites.Insert(i, p); //not sure if this works, we'll see
            }
        }
        return true;
    }

}