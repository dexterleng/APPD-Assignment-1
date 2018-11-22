using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_Assignment_1
{
	public static class Util //main parsing stuff and other methods in the original program.cs file
	{
		public static List<string[]> ParseMRTFile() // returns the mrt file in format {stationName, stationCode}
		{
			string[] MRTFile = File.ReadAllLines("MRT.txt");

			List<string[]> records = new List<string[]>();

			for (int i = 0; i < MRTFile.Length; i++)
			{
				if (MRTFile[i] != "(start)" && MRTFile[i] != "(end)")
				{
					string[] pair = { MRTFile[i + 1], MRTFile[i] };
					records.Add(pair);
					i++;
				}
			}

			return records;
		}

		public static List<Station> ToStations(this List<string[]> strArr)
		{
			// do shit from parseMRTFileForStations()
			Dictionary<string, Station> stations = new Dictionary<string, Station>();

			foreach (string[] data in strArr)
			{
				if (!stations.ContainsKey(data[0]))
					stations[data[0]] = new Station(data[0]);

				stations[data[0]].AddStationCode(data[1]);
			}

			return new List<Station>(stations.Values);
		}

		public static Dictionary<String, List<String[]>> ToStationLineAsKey(List<string[]> records) // maps linecode to list of {stationName, stationCode} in the line
		{
			Dictionary<String, List<String[]>> l = new Dictionary<String, List<String[]>>();
			string lineCode;
			string[] record;
			for (int i = 0; i < records.Count; i++)
			{
				record = records[i];
				lineCode = record[1].Substring(0, 2);
				if (!l.ContainsKey(lineCode))
				{
					l.Add(lineCode, new List<String[]>());
				}
				l[lineCode].Add(record);

			}
			return l;
		}

		// StationName -> List<AdjStationName>
		public static Dictionary<String, List<String>> AdjStations(Dictionary<String, List<String[]>> l)
		{
			Dictionary<String, List<String>> adj = new Dictionary<String, List<String>>();
			List<String[]> stations;
			foreach (string lineCode in l.Keys)
			{
				stations = l[lineCode];
				string[] station;
				for (int i = 0; i < stations.Count; i++)
				{
					station = stations[i];
					if (!adj.ContainsKey(station[0]))
					{
						adj.Add(station[0], new List<String>());
					}

					if (i - 1 >= 0) { adj[station[0]].Add(stations[i - 1][0]); }
					if (i + 1 < stations.Count)
					{
						adj[station[0]].Add(stations[i + 1][0]);
					}
				}
			}
			return adj;
		}

		public static bool SameStation(this Station station, string search)
		{
			foreach(string line in station.GetLines())
			{
				if (line.Contains(search.Substring(0, 2)))
				{
					return true;
				}
			}
			return false;
		}

		public static Path[] Find1TransferMax(Graph<Station> graph, Station start, Station dest)
		{
			List<Station> stations = graph.GetAllVertices();

			List<Station> intersections = new List<Station>();


			for (int i = 0; i < stations.Count; i++)
			{
				if (stations[i] != start)
				{
					if (stations[i].GetLines().FirstOrDefault(search => start.SameStation(search)) != null && stations[i].GetLines().FirstOrDefault(search => dest.SameStation(search)) != null)
					{
						intersections.Add(stations[i]);
						//MessageBox.Show(stations[i].Name);
					}
				}
			}

			if (intersections.Count > 0)
			{
				Path[] pathArr = new Path[intersections.Count];

				for (int i = 0; i < intersections.Count; i++)
				{
					Path path = new Path();
					path.Insert(0, start);
					path.Insert(1, intersections[i]);
					path.Insert(2, dest);

					pathArr[i] = path;
				}

				return pathArr;
			}
			throw new Exception("Route not found");
		}

		//public static void printRoute(List<Station> stations)
		//{
		//	foreach (Station station in stations)
		//	{
		//		Console.Write(station.Name);
		//		Console.Write(": ");
		//		Console.WriteLine(station.StationCodes);
		//	}
		//}
	}
}
