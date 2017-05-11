using System;
using System.Collections.Generic;
using UnityEngine;

struct Star {
    public Vector2 coords { get; private set; }
    public int seed { get; private set; }
    public Star(Vector2 coords, int seed) {
        this.coords = coords;
        this.seed = seed;
    }
}

class Galaxy {

    System.Random rand;
    public List<Star> stars { get; private set; }
    public Star home { get; private set; }

    public Galaxy(int numberOfSystems) {
        new Galaxy(numberOfSystems, new System.Random().Next());
    }

    public Galaxy(int numberOfSystems, int seed) {
        rand = new System.Random(seed);
        GenerateWorld(numberOfSystems);
    }

    public Star GetRandomStar() {
        int r = rand.Next(stars.Count);
        return stars[r];
    }

    private void GenerateWorld(int numberOfSystems) {
        //Generate Galaxy
        for (int i = 0; i < numberOfSystems; i++) {
            Star s = GenerateStar(rand);
        }
        stars.Sort(
            (l, r) => Vector2.SqrMagnitude(l.coords).CompareTo(Vector2.SqrMagnitude(r.coords))
        );
        home = stars[0];
    }

    public Star GenerateStar(System.Random generator) {
        return new Star(
            new Vector2(generator.Next() - Int32.MaxValue/2, generator.Next() - Int32.MaxValue/2),
            generator.Next()
        );
    }


}
