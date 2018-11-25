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
        private GraphSearchStation pathFinder = new GraphSearchStation();

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

				if (this.graph.GetVertex(startStation).FirstCommonLine(this.graph.GetVertex(endStation)) != null)
				{
					Path path = new Path();

					path.Insert(0, this.graph.GetVertex(startStation));
					path.Insert(1, this.graph.GetVertex(endStation));

					RouteBox.Text = path.ToString();
					return;
				}

				if (BestRoute.Checked)
				{
					RouteBox.Text = pathFinder.FindPathByKey(this.graph, startStation, endStation).ToString();
				}
				else if (Max1.Checked)
				{
					string res = "";
					string append = "\n\n OR \n\n";

					foreach (Path listStation in Util.Find1TransferMax(this.graph, this.graph.GetVertex(startStation), this.graph.GetVertex(endStation)))
					{
						res += listStation.ToString() + "\n\n OR \n\n";
					}

					RouteBox.Text = res.Substring(0, res.Length - append.Length);
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
