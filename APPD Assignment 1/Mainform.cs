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
		Graph<Station> graph;

		private void Mainform_Load(object sender, EventArgs e)
		{
			//toolTip.SetToolTip(codeToName, "Converts entered station codes in format \"OOII\" where \nO is the station name and I is the station number\neg. CC2 or DT11");

			List<string[]> records = Util.ParseMRTFile();
			Dictionary<String, List<String>> adj = Util.AdjStations(Util.ToStationLineAsKey(records));
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

			startStation.DataSource = stationNames;

			endStation.BindingContext = new BindingContext();
			endStation.DataSource = stationNames;
		}

		private void SearchStations_Click(object sender, EventArgs e)
		{
			MessageBox.Show("hello");
		}

		private void CalcRoute_Click(object sender, EventArgs e)
		{
			Station startStationChecked = graph.GetAllVertices().Find(station => station.GetStationCodes().Contains(startStation.Text.ToUpper()));
			Station endStationChecked = graph.GetAllVertices().Find(station => station.GetStationCodes().Contains(endStation.Text.ToUpper()));

			if (startStationChecked != null)
			{
				startStation.Text = startStationChecked.GetName();
				//startStationChecked = graph.GetAllVertices().Find(station => station.GetStationCodes().Contains(startStation.Text.ToUpper()));
			}

			if (endStationChecked != null)
			{
				endStation.Text = endStationChecked.GetName();
				//endStationChecked = graph.GetAllVertices().Find(station => station.GetStationCodes().Contains(endStation.Text.ToUpper()));
			}

			if (!(stationNames.Contains(startStation.Text) && stationNames.Contains(endStation.Text)))
			{
				MessageBox.Show("Invalid station entered");
				return;
			}

			var routeDisplay = new RouteDisplay(graph, startStation.Text, endStation.Text); // make it pass in the station instead of the string
			routeDisplay.Show();

		}

		private void SwitchInputs_Click(object sender, EventArgs e)
		{
			string tmp = startStation.Text;
			startStation.Text = endStation.Text;
			endStation.Text = tmp;
		}

	}
}
