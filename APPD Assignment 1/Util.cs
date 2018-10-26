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

		public static string pathToString(List<Station> stations) // input station path
		{

			if (stations.Count <= 1)
			{
				return "Already at destination station.";
			}
			StringBuilder pathSB = new StringBuilder();
			int index = 0;
			List<int> indices = new List<int>();
			indices.Add(index);
			while (indices[indices.Count - 1] != (stations.Count - 1)) // gets index of station, insert into indices
			{
				index = calcNextStationIndex(stations, index);
				indices.Add(index);
			}

			Station station = stations[0];
			Station nextStation = stations[indices[1]];
			string commonLine = station.firstCommonLine(nextStation);
			pathSB.AppendLine(String.Format("Board at {0} ({1}).", station.GetName(), station.GetStationCode(commonLine)));

			//if (2 < indices.Count - 1)
			//{
			//	Station futureStation = stations[indices[2]];
			//	//MessageBox.Show(station.firstCommonLine(futureStation));

			//	if (station.firstCommonLine(futureStation) != null)
			//	{
			//		flag = false;
			//	}
			//}
			
			if (commonLine != null)
				pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.GetName(), nextStation.GetStationCode(commonLine)));

			for (int i = 1; i < indices.Count - 1; i++)
			{
				int j = indices[i];
				station = stations[j];
				nextStation = stations[indices[i + 1]];
				commonLine = station.firstCommonLine(nextStation);

				bool flag = true;


				// test cases that broke before, chinatown to admiralty, raffles to dhoby ghaut. should work fine now
				if ((i + 2) <= (indices.Count - 1))
				{
					Station futureStation = stations[indices[i + 1]];

					//MessageBox.Show(stations[indices[i + 1]].GetKey());

					if (station.firstCommonLine(futureStation) != null)
						flag = false;
					
				}

				if (flag)
				{
					pathSB.AppendLine(String.Format("Change to {0} line", commonLine));
					pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.GetName(), nextStation.GetStationCode(commonLine)));
				}
			}
			pathSB.AppendLine(String.Format("Alight at destination {0}.", nextStation.GetName()));
			return pathSB.ToString();
		}

		public static int calcNextStationIndex(List<Station> stations, int index)
		{
			string currLine = stations[index].firstCommonLine(stations[index + 1]);
			for (int i = index + 1; i < stations.Count - 1; i++) // loops from current station
			{
				if (!currLine.Equals(stations[i].firstCommonLine(stations[i + 1])))
				{
					return i;
				}

			}

			return stations.Count - 1;
		}

		public static List<string[]> parseMRTFile() // returns the mrt file in format {stationName, stationCode}
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
		public static Dictionary<String, List<String[]>> toStationLineAsKey(List<string[]> records)
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
		public static Dictionary<String, List<String>> adjStations(Dictionary<String, List<String[]>> l)
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

		//public static void printRoute(List<Station> stations)
		//{
		//	foreach (Station station in stations)
		//	{
		//		Console.Write(station.GetName());
		//		Console.Write(": ");
		//		Console.WriteLine(station.GetStationCodes());
		//	}
		//}
	}
}
