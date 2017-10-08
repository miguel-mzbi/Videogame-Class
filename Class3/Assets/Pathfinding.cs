using System.Collections.Generic;

public class Pathfinding {
    
    public static List<Waypoint> BreadthWise(Waypoint start, Waypoint end) {

        Queue<Waypoint> work = new Queue<Waypoint>();
        List<Waypoint> seen = new List<Waypoint>();

        Waypoint current;
        work.Enqueue(start);
        seen.Add(start);

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

        return null;
    }

    public static List<Waypoint> DepthWise(Waypoint start, Waypoint end) {
        return null;
    }

    public static List<Waypoint> AStar(Waypoint start, Waypoint end) {
        return null;
    }
}
