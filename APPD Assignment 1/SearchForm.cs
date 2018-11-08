using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_Assignment_1
{
	public partial class SearchForm : Form
	{
		private Graph<Station> graph;
		private List<string> stationNames;
		Dictionary<String, List<String[]>> lineStationMap;

		public SearchForm(List<string> stationNames, Graph<Station> graph, Dictionary<String, List<String[]>> lineStationMap)
		{
			this.stationNames = stationNames;
			this.graph = graph;
			this.lineStationMap = lineStationMap;

			InitializeComponent();


			SearchTab.TabPages.Clear();

			SearchStation.DataSource = stationNames;
		}

		private void SearchButton_Click(object sender, EventArgs e)
		{
			// copy of the one in the main form calculate route button
			Station stationChecked = graph.GetAllVertices().Find(station => station.GetStationCodes().Contains(SearchStation.Text.ToUpper()));

			if (stationChecked != null)
				SearchStation.Text = stationChecked.GetName();

			if (!(stationNames.Contains(SearchStation.Text)))
			{
				MessageBox.Show("Invalid station entered");
				return;
			}


			//do checks after here

			SearchTab.TabPages.Clear();

			

			if (stationChecked == null)
				stationChecked = graph.GetVertex(SearchStation.Text);

			List<string> sameLines = stationChecked.GetStationCodes();

			foreach (string line in sameLines)
			{
				string tabTitle = line.Substring(0, 2);

				TabPage tab = new TabPage(tabTitle);
				SearchTab.TabPages.Add(tab);

				RichTextBox ctrl = new RichTextBox();
				ctrl.Size = tab.Size;
				tab.Controls.Add(ctrl);

				// get everything in the same line
				List<string[]> currentLine = lineStationMap[tabTitle];

				string formattedStr = "";

				foreach (string[] info in currentLine)
					formattedStr += string.Format("{0} ({1})\n", info[0], info[1]);

				//MessageBox.Show(formattedStr);

				ctrl.Text = formattedStr; 
			}

		}
	}
}
