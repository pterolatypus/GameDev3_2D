using System;
using System.Collections.Generic;
using UnityEngine;

class Galaxy {

    System.Random rand;
    public List<StarSystem> stars { get; private set; }
    public StarSystem home { get; private set; }

    public Galaxy(int numberOfSystems) {
        new Galaxy(numberOfSystems, new System.Random().Next());
    }

    public Galaxy(int numberOfSystems, int seed) {
        rand = new System.Random(seed);
        GenerateWorld(numberOfSystems);
    }

    public StarSystem GetRandomStar() {
        int r = rand.Next(stars.Count);
        return stars[r];
    }

    private void GenerateWorld(int numberOfSystems) {
        //Generate Galaxy
        for (int i = 0; i < numberOfSystems; i++) {
            StarSystem s = GenerateStar(rand);
        }
        stars.Sort(
            (l, r) => Vector2.SqrMagnitude(l.coords).CompareTo(Vector2.SqrMagnitude(r.coords))
        );
        home = stars[0];
    }

    public StarSystem GenerateStar(System.Random generator) {
        return new StarSystem(
            new Vector2(generator.Next() - Int32.MaxValue/2, generator.Next() - Int32.MaxValue/2),
            generator.Next()
        );
    }


}
