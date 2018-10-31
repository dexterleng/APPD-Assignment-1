using System;
using System.Collections.Generic;

namespace APPD_Assignment_1
{
    public class GraphSearchStation
    {
        private Dictionary<string, string> edgeTo = new Dictionary<string, string>();
        private Dictionary<string, string> onLine = new Dictionary<string, string>();
        private Dictionary<string, int> transfers = new Dictionary<string, int>();

        private Boolean BFS(Graph<Station> g, Station source, Station dest, int transferLimit)
        {
            Dictionary<string, Boolean> visited = new Dictionary<string, Boolean>();
            visited[source.GetKey()] = true;
            Queue<Station> q = new Queue<Station>();
            Station curr;
            q.Enqueue(source);
            onLine[source.GetKey()] = null;
            transfers[source.GetKey()] = 0;
            while (q.Count != 0)
            {
                curr = q.Dequeue();
                if (curr.Equals(dest)) { return true; }
                foreach (Station neighbour in g.GetNeighbours(curr))
                {
                    if (!IsVisited(visited, neighbour))
                    {
                        onLine[neighbour.GetKey()] = curr.FirstCommonLine(neighbour);
                        if (onLine[neighbour.GetKey()].Equals(onLine[curr.GetKey()]) || onLine[curr.GetKey()] == null) {
                            transfers[neighbour.GetKey()] = transfers[curr.GetKey()];
                        } else {
                            transfers[neighbour.GetKey()] = transfers[curr.GetKey()] + 1;
                        }
                        if (transfers[neighbour.GetKey()] <= transferLimit)
                        {
                            this.edgeTo[neighbour.GetKey()] = curr.GetKey();
                            visited[neighbour.GetKey()] = true;
                            q.Enqueue(neighbour);
                        }
                    }
                }
            }
            return false;
        }

        //private Boolean BFS(Graph<T> g, T source, T dest)
        //{
        //    Dictionary<string, Boolean> visited = new Dictionary<string, Boolean>();
        //    visited[source.GetKey()] = true;
        //    Queue<T> q = new Queue<T>();
        //    T curr;
        //    q.Enqueue(source);
        //    while (q.Count != 0)
        //    {
        //        curr = q.Dequeue();
        //        if (curr.Equals(dest)) { return true; }
        //        foreach (T neighbour in g.GetNeighbours(curr))
        //        {
        //            if (!isVisited(visited, neighbour))
        //            {
        //                this.edgeTo[neighbour.GetKey()] = curr.GetKey();
        //                visited[neighbour.GetKey()] = true;
        //                q.Enqueue(neighbour);
        //            }
        //        }
        //    }
        //    return false;
        //}


        //public List<T> findPath(Graph<T> g, T source, T dest)
        //{
        //    BFS(g, source, dest);
        //    List<T> path = new List<T>();
        //    T curr = dest;
        //    while (!curr.Equals(source))
        //    {
        //        // inefficient, maybe change to LinkedList or Stack
        //        path.Insert(0, curr);
        //        curr = g.GetVertex(this.edgeTo[curr.GetKey()]);
        //    }
        //    path.Insert(0, curr);
        //    return path;
        //}

        //public List<T> findPathByKey(Graph<T> g, string sKey, string dKey)
        //{
        //    T s = g.GetVertex(sKey);
        //    T d = g.GetVertex(dKey);
        //    return this.findPath(g, s, d);
        //}

        //private static Boolean isVisited(Dictionary<string, Boolean> visited, T curr)
        //{
        //    return visited.ContainsKey(curr.GetKey());
        //}

        public List<Station> FindPath(Graph<Station> g, Station source, Station dest, int transferLimit = int.MaxValue)
        {
            Boolean success = BFS(g, source, dest, transferLimit);
            if (!success) { throw new Exception("Route not found"); }
            List<Station> path = new List<Station>();
            Station curr = dest;
            while (!curr.Equals(source))
            {
                // inefficient, maybe change to LinkedList or Stack
                path.Insert(0, curr);
                curr = g.GetVertex(this.edgeTo[curr.GetKey()]);
            }
            path.Insert(0, curr);
            return path;
        }

        //public List<Station> findPath(Graph<Station> g, Station source, Station dest)
        //{
        //    return findPath(g, source, dest, int.MaxValue);
        //}

        public List<Station> FindPathByKey(Graph<Station> g, string sKey, string dKey, int transferLimit = int.MaxValue) // defaults to unlimited transfers
        {
            Station s = g.GetVertex(sKey);
            Station d = g.GetVertex(dKey);
            return this.FindPath(g, s, d, transferLimit);
        }

        //public List<Station> findPathByKey(Graph<Station> g, string sKey, string dKey)
        //{
        //    return this.findPathByKey(g, sKey, dKey, int.MaxValue);
        //}

        private static Boolean IsVisited(Dictionary<string, Boolean> visited, Station curr)
        {
            return visited.ContainsKey(curr.GetKey());
        }
    }
}
