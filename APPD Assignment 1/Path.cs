using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APPD_Assignment_1
{

	public static class ArrPathExt
	{
		public static string ToString(this Path[] stations)
		{
			MessageBox.Show("thing");

			string res = "";
			string append = "\n\n OR \n\n";

			foreach (Path listStation in stations)
			{
				res += listStation.ToString() + "\n\n OR \n\n";
			}

			return res.Substring(0, res.Length - append.Length);
		}
	}

	public class Path : List<Station>
	{

		public Path() : base() { }

		public new void Insert(int index, Station station)
		{
			if (index > -1)
				base.Insert(index, station);
			else
				throw new Exception("Attempted to insert an invalid station while calculating the path");
		}

		public override string ToString()
		{

			if (this.Count <= 1)
			{
				return "Already at destination station.";
			}
			StringBuilder pathSB = new StringBuilder();
			int index = 0;
			List<int> indices = new List<int>();
			indices.Add(index);
			while (indices[indices.Count - 1] != (this.Count - 1))
			{
				index = CalcNextStationIndex(index);
				indices.Add(index);
			}

			Station station = this[0];
			Station nextStation = this[indices[1]];
			string commonLine = station.FirstCommonLine(nextStation);
			pathSB.AppendLine(String.Format("Aboard at {0} ({1}).", station.Name, station.GetStationCode(commonLine)));
			pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.Name, nextStation.GetStationCode(commonLine)));
			for (int i = 1; i < indices.Count - 1; i++)
			{
				int j = indices[i];
				station = this[j];
				nextStation = this[indices[i + 1]];
				commonLine = station.FirstCommonLine(nextStation);

				pathSB.AppendLine(String.Format("Change to {0} line", commonLine));
				pathSB.AppendLine(String.Format("Take to {0} ({1}).", nextStation.Name, nextStation.GetStationCode(commonLine)));
			}
			pathSB.AppendLine(String.Format("Alight at destination {0}.", nextStation.Name));
			return pathSB.ToString();
		}

		private int CalcNextStationIndex(int index)
		{
			string currLine = this[index].FirstCommonLine(this[index + 1]);
			for (int i = index + 1; i < this.Count - 1; i++) // loops from current station
			{
				if (!currLine.Equals(this[i].FirstCommonLine(this[i + 1])))
				{
					return i;
				}

			}

			return this.Count - 1;
		}
	}
}
