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
	public partial class RouteDisplay : Form
	{
		private Graph<Station> graph;
		private string startStation, endStation;

		public RouteDisplay(Graph<Station> graph, string startStation, string endStation)
		{

			InitializeComponent();

			this.graph = graph;
			this.startStation = startStation;
			this.endStation = endStation;
		}

		private void RouteDisplay_Load(object sender, EventArgs e)
		{
			this.Text = string.Format("Routes between {0} and {1}", startStation, endStation);
			SelectionChanged(sender, e);
		}

		private void SelectionChanged(object sender, EventArgs e)
		{
			// execute the routing function and showing shit here

			//implement
			try
			{
				GraphSearchStation search = new GraphSearchStation();


				if (graph.GetVertex(startStation).FirstCommonLine(graph.GetVertex(endStation)) != null)
				{
					List<Station> path = new List<Station>();

					path.Insert(0, graph.GetVertex(startStation));
					path.Insert(1, graph.GetVertex(endStation));

					RouteBox.Text = Util.PathToString(path);
					return;
				}

				if (BestRoute.Checked)
				{
					RouteBox.Text = Util.PathToString(search.FindPathByKey(graph, startStation, endStation));
				}
				else if (Max1.Checked)
				{
					RouteBox.Text = Util.PathToString(Util.Find1TransferMax(graph, graph.GetVertex(startStation), graph.GetVertex(endStation)));
				}
				else
				{
					throw new Exception("Route not found");
				}

			}
			catch (Exception exception)
			{
				if (exception.Message == "Route not found")
				{
					RouteBox.Text = "Route not possible";
					return;
				}

				MessageBox.Show(exception.Message);
			}
		}
	}
}
