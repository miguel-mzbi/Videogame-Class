using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {
    
    public static List<Waypoint> BreadthWise(Waypoint start, Waypoint end) {

        Queue<Waypoint> work = new Queue<Waypoint>();
        List<Waypoint> seen = new List<Waypoint>();

        Waypoint current;
        work.Enqueue(start);
        seen.Add(start);

        start.history = new List<Waypoint>();
        List<Waypoint> result = new List<Waypoint>();

        while(work.Count > 0) {
            current = work.Dequeue();

            if(current == end) {
                result = current.history;
                result.Add(current);
                return result;
            }
            else {
                for(int i = 0; i < current.neighbors.Length; i++) {
                    Waypoint currentNeighbor = current.neighbors[i];
                    if(!seen.Contains(currentNeighbor)) {
                        work.Enqueue(currentNeighbor);
                        seen.Add(currentNeighbor);
                        currentNeighbor.history = new List<Waypoint>(current.history);
                        currentNeighbor.history.Add(current);
                    }
                }
            }
        }

        return result;
    }

    public static List<Waypoint> DepthWise(Waypoint start, Waypoint end) {
        Stack<Waypoint> stack = new Stack<Waypoint>();
        List<Waypoint> seen = new List<Waypoint>();
        stack.Push(start);
        seen.Add(start);
        start.history = new List<Waypoint>();
        while(stack.Count > 0) {
            Waypoint current = stack.Pop();
            if(current == end) {
                List<Waypoint> result = new List<Waypoint>(current.history);
                result.Add(current);
                return result;
            }
            else {
                for(int i = 0; i < current.neighbors.Length; i++) {
                    Waypoint currentNeighbor = current.neighbors[i];
                    if(!seen.Contains(currentNeighbor)) {
                        stack.Push(currentNeighbor);
                        seen.Add(currentNeighbor);
                        currentNeighbor.history = new List<Waypoint>(current.history);
                        currentNeighbor.history.Add(current);
                    }
                }
            }
        }

        return null;
    }

    public static List<Waypoint> AStar(Waypoint start, Waypoint end) {
        List<Waypoint> work = new List<Waypoint>();
        List<Waypoint> visited = new List<Waypoint>();
        work.Add(start);
        visited.Add(start);
        start.history = new List<Waypoint>();
        start.g = 0;
        start.f = start.g + Vector3.Distance(start.transform.position, end.transform.position);

        while(work.Count > 0) {

            Waypoint actual = work[0];
            for(int i = 0; i < work.Count; i++) {
                if(work[i].f < actual.f) {
                    actual = work[i];
                }
            }

            work.Remove(actual);

            if(actual == end) {
                List<Waypoint> result = new List<Waypoint>(actual.history);
                result.Add(actual);
                return result;
            }
            else {
                for(int i = 0; i < actual.neighbors.Length; i++) {
                    Waypoint currentNeighbor = actual.neighbors[i];
                    if(!visited.Contains(currentNeighbor)) {
                        work.Add(currentNeighbor);
                        visited.Add(currentNeighbor);
                        currentNeighbor.history = new List<Waypoint>(actual.history);
                        currentNeighbor.history.Add(actual);
                        currentNeighbor.g = actual.g + Vector3.Distance(actual.transform.position, currentNeighbor.transform.position);
                        float h = Vector3.Distance(currentNeighbor.transform.position, end.transform.position);
                        currentNeighbor.f = currentNeighbor.g + h;
                    }
                }
            }
        }

        return null;
    }
}
