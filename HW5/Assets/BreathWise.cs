using System.Collections.Generic;
using UnityEngine;

public class BreathWise {

    public static List<Waypoint> BFSearch(Waypoint start) {

        Queue<Waypoint> work = new Queue<Waypoint>();
        List<Waypoint> seen = new List<Waypoint>();

        work.Enqueue(start);
        seen.Add(start);

        Waypoint current;

        while(work.Count > 0) {

            current = work.Dequeue();

            foreach(Waypoint currentNeighbor in current.neighbors) {
                if(!seen.Contains(currentNeighbor)) {

                    work.Enqueue(currentNeighbor);
                    seen.Add(currentNeighbor);

                }
            }
        }

        return seen;

    }
}
