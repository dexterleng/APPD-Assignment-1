using System;
using System.Collections.Generic;
namespace APPD_Assignment_1
{
    public class Graph<T> where T:IVertex
    {
        // vert key -> Set of adj vert keys
        private Dictionary<string, HashSet<string>> adj = new Dictionary<string, HashSet<string>>();
        private Dictionary<string, T> vertexMap = new Dictionary<string, T>();
        private Dictionary<string, string> edgeTo = new Dictionary<string, string>();

        public Graph(List<T> vertices)
        {
            foreach(T vertex in vertices)
            {
                vertexMap[vertex.GetKey()] = vertex;
            }
        }

        public void AddVertex(T v)
        {
            this.vertexMap[v.GetKey()] = v;
        }

        public T GetVertex(string key)
        {
            if (!this.vertexMap.ContainsKey(key))
            {
                throw new Exception(
                    String.Format("Vertex with key \"{0}\" does not exist.", key)
                );
            }
            return this.vertexMap[key]; // returns station type given station name
        }

		public List<T> GetAllVertices()
		{
			return new List<T>(this.vertexMap.Values);
		}

		public List<string> GetAllKeys()
		{
			return new List<string>(vertexMap.Keys);
		}

		// private because ideally vertex must exist in graph because edge
		// with it can be added.
		// use AddEdgeByKey instead.
		private void AddEdge(T v, T w)
        {
            if (!this.adj.ContainsKey(v.GetKey()))
            {
                this.adj[v.GetKey()] = new HashSet<string>();
            }
            if (!this.adj.ContainsKey(w.GetKey()))
            {
                this.adj[w.GetKey()] = new HashSet<string>();
            }

            this.adj[v.GetKey()].Add(w.GetKey());
            this.adj[w.GetKey()].Add(v.GetKey());
        }

        public void AddEdgeByKey(string vKey, string wKey)
        {
            T v = this.GetVertex(vKey);
            T w = this.GetVertex(wKey);
            this.AddEdge(v, w);
        }

        public List<T> GetNeighbours(T v)
        {
            List<T> neighbours = new List<T>();
            HashSet<string> nKeys = this.adj[v.GetKey()];
            foreach (string key in nKeys)
            {
                neighbours.Add(this.vertexMap[key]);
            }
            return neighbours;
        }

        public List<T> GetNeighboursByKey(string vKey)
        {
            T v = this.GetVertex(vKey);
            return this.GetNeighbours(v);
        }

        public Boolean IsNeighbour(T a, T b)
        {
            List<T> aNeighbours = this.GetNeighbours(a);
            return aNeighbours.Contains(b);
        }
    }

}
