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

		public static string PathToString(List<Station> stations)
		{

			if (stations.Count <= 1)
			{
				return "Already at destination station.";
			}
			StringBuilder pathSB = new StringBuilder();
			int index = 0;
			List<int> indices = new List<int>();
			indices.Add(index);
			while (indices[indices.Count - 1] != (stations.Count - 1))
			{
				index = CalcNextStationIndex(stations, index);
				indices.Add(index);
			}

			Station station = stations[0];
			Station nextStation = stations[indices[1]];
			string commonLine = station.FirstCommonLine(nextStation);
			pathSB.AppendLine(String.Format("Aboard at {0} ({1}).", station.Name, station.GetStationCode(commonLine)));
			pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.Name, nextStation.GetStationCode(commonLine)));
			for (int i = 1; i < indices.Count - 1; i++)
			{
				int j = indices[i];
				station = stations[j];
				nextStation = stations[indices[i + 1]];
				commonLine = station.FirstCommonLine(nextStation);

				pathSB.AppendLine(String.Format("Change to {0} line", commonLine));
				pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.Name, nextStation.GetStationCode(commonLine)));
			}
			pathSB.AppendLine(String.Format("Alight at destination {0}.", nextStation.Name));
			return pathSB.ToString();
		}

		public static string PathToString(List<Station>[] stations)
		{
			string res = "";
			string append = "\n\n OR \n\n";

			foreach (List<Station> listStation in stations)
			{
				res += PathToString(listStation) + "\n\n OR \n\n";
			}

			return res.Substring(0, res.Length-append.Length);
		}

		public static int CalcNextStationIndex(List<Station> stations, int index)
		{
			string currLine = stations[index].FirstCommonLine(stations[index + 1]);
			for (int i = index + 1; i < stations.Count - 1; i++) // loops from current station
			{
				if (!currLine.Equals(stations[i].FirstCommonLine(stations[i + 1])))
				{
					return i;
				}

			}

			return stations.Count - 1;
		}

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

		// TODO: Make this use parseMRTFile
		//public static List<Station> parseMRTFileForStations()
		//{
		//	int counter = 0;
		//	string line;
		//	Boolean isStationCode = true;
		//	string stationCode = "";
		//	string stationName;
		//	Dictionary<string, Station> stations = new Dictionary<string, Station>();
		//	// Read the file and display it line by line.  
		//	System.IO.StreamReader file =
		//		new System.IO.StreamReader("MRT.txt");
		//	while ((line = file.ReadLine()) != null)
		//	{
		//		if (!line.Equals("(start)") && !line.Equals("(end)"))
		//		{
		//			if (isStationCode) { stationCode = line; }
		//			else
		//			{
		//				stationName = line;
		//				if (!stations.ContainsKey(stationName))
		//				{
		//					stations.Add(stationName, new Station(stationName));
		//				}
		//				stations[stationName].AddStationCode(stationCode);
		//			}
		//			isStationCode = !isStationCode;
		//		}
		//		counter++;
		//	}
		//	file.Close();

		//	List<Station> stationsList = new List<Station>();
		//	foreach (Station s in stations.Values)
		//	{
		//		stationsList.Add(s);
		//	}
		//	return stationsList;
		//}

		// stationLine is use as key instead
		// StationLine -> List< [stationName, stationCode] >
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

		public static List<Station>[] Find1TransferMax(Graph<Station> graph, Station start, Station dest)
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
				List<Station>[] pathArr = new List<Station>[intersections.Count];

				for (int i = 0; i < intersections.Count; i++)
				{
					List<Station> path = new List<Station>();
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
