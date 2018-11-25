using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_Assignment_1
{
	public partial class Mainform : Form // There is a problem with the algo transfer limitting. direct line works 1 transfer doesnt
	{

		public Mainform()
		{
			InitializeComponent();
		}

		List<string> stationNames; // just station names
		Dictionary<String, List<String[]>> lineStationMap;
        Graph<Station> graph;

		private void Mainform_Load(object sender, EventArgs e)
		{
			//toolTip.SetToolTip(codeToName, "Converts entered station codes in format \"OOII\" where \nO is the station name and I is the station number\neg. CC2 or DT11");

			List<string[]> records = Util.ParseMRTFile();
			lineStationMap = Util.ToStationLineAsKey(records);
			Dictionary<String, List<String>> adj = Util.AdjStations(lineStationMap);
			List<Station> stations = records.ToStations();

			graph = new Graph<Station>(stations);


			foreach (string station in adj.Keys)
			{
				foreach (string adjStation in adj[station])
				{
					graph.AddEdgeByKey(station, adjStation);
				}
			}

			stationNames = graph.GetAllKeys();

			stationNames.Sort();
			stationNames = stationNames.Distinct().ToList(); // sorts and removes duplicates from station name list 

			StartStation.DataSource = stationNames;

			EndStation.BindingContext = new BindingContext();
			EndStation.DataSource = stationNames;
		}

		private void SearchStations_Click(object sender, EventArgs e)
		{
			new SearchForm(stationNames, graph, lineStationMap).Show();
		}

		private void CalcRoute_Click(object sender, EventArgs e)
		{
			Station startStationChecked = graph.GetAllVertices().Find(station => station.StationCodes.Contains(StartStation.Text.ToUpper()));
			Station endStationChecked = graph.GetAllVertices().Find(station => station.StationCodes.Contains(EndStation.Text.ToUpper()));

			if (startStationChecked != null)
			{
				StartStation.Text = startStationChecked.Name;
				//startStationChecked = graph.GetAllVertices().Find(station => station.StationCodes.Contains(startStation.Text.ToUpper()));
			}

			if (endStationChecked != null)
			{
				EndStation.Text = endStationChecked.Name;
				//endStationChecked = graph.GetAllVertices().Find(station => station.StationCodes.Contains(endStation.Text.ToUpper()));
			}

			if (!(stationNames.Contains(StartStation.Text) && stationNames.Contains(EndStation.Text)))
			{
				MessageBox.Show("Invalid station entered");
				return;
			}

			if (StartStation.Text == EndStation.Text)
			{
				MessageBox.Show("Already at destination station");
			}

			var routeDisplay = new RouteDisplay(graph, StartStation.Text, EndStation.Text); // make it pass in the station instead of the string
			routeDisplay.Show();

		}

		private void SwitchInputs_Click(object sender, EventArgs e)
		{
			string tmp = StartStation.Text;
			StartStation.Text = EndStation.Text;
			EndStation.Text = tmp;
		}

	}
}
