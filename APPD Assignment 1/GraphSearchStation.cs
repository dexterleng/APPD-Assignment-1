using System;
using System.Collections.Generic;

namespace APPD_Assignment_1
{
    public class GraphSearchStation : Graph<Station>
    {
        private Dictionary<string, string> edgeTo = new Dictionary<string, string>();

        private Boolean BFS(Graph<Station> g, Station source, Station dest)
        {
            Dictionary<string, Boolean> visited = new Dictionary<string, Boolean>();
            visited[source.Name] = true;
            Queue<Station> q = new Queue<Station>();
            Station curr;
            q.Enqueue(source);
            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.Equals(dest)) { return true; }
                foreach (Station neighbour in g.GetNeighbours(curr))
                {
                    if (!IsVisited(visited, neighbour))
                    {
                        this.edgeTo[neighbour.Name] = curr.Name;
                        visited[neighbour.Name] = true;
                        q.Enqueue(neighbour);
                    }
                }
            }
            return false;
        }

        public List<Station> FindPath(Graph<Station> g, Station source, Station dest)
        {
            Boolean success = BFS(g, source, dest);
            if (!success) { throw new Exception("Route not found"); }
            List<Station> path = new List<Station>();
            Station curr = dest;
            while (!curr.Equals(source))
            {
                // inefficient, maybe change to LinkedList or Stack
                path.Insert(0, curr);
                curr = g.GetVertex(this.edgeTo[curr.Name]);
            }
            path.Insert(0, curr);
            return path;
        }

        public List<Station> FindPathByKey(Graph<Station> g, string sKey, string dKey)
        {
            Station s = g.GetVertex(sKey);
            Station d = g.GetVertex(dKey);
            return this.FindPath(g, s, d);
        }

        private static Boolean IsVisited(Dictionary<string, Boolean> visited, Station curr)
        {
            return visited.ContainsKey(curr.Name);
        }

		public GraphSearchStation(List<Station> vertices) : base(vertices){}
    }
}
