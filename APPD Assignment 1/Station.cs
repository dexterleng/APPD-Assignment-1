using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APPD_Assignment_1
{
    public class Station:IVertex
    {
        private List<string> stationCodes = new List<string>();
        private string stationName;

		public List<string> StationCodes { get => stationCodes; }
		public string Name { get => stationName; }

		public Station(string stationName)
        {
            this.stationName = stationName;
        }

        public void AddStationCode(string stationCode)
        {
            stationCodes.Add(stationCode);
        }

        public Boolean Equals(IVertex o)
        {
            return Name.Equals(o.Name);
        }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();
            foreach (string code in StationCodes)
            {
                lines.Add(code.Substring(0, 2));
            }
            return lines;
        }

        public string FirstCommonLine(Station other)
        {
			IEnumerable<string> search = GetLines().Intersect(other.GetLines()); // error is thrown is .first of empty ienumerable

			if (search.Count() > 1)
			{
				Dictionary<string, int> lineToLengthDiff = new Dictionary<string, int>();
				foreach (string line in search)
				{
					int selfCodeNum = -1;
					foreach (string code in StationCodes)
					{
						if (code.Substring(0, 2).Equals(line))
						{
							selfCodeNum = int.Parse(code.Substring(2, code.Length - 2));
							break;
						}
					}

					int otherCodeNum = -1;
					foreach (string code in other.StationCodes)
					{
						if (code.Substring(0, 2).Equals(line))
						{
							otherCodeNum = int.Parse(code.Substring(2, code.Length - 2));
							break;
						}
					}

					lineToLengthDiff[line] = Math.Abs(selfCodeNum - otherCodeNum);
				}

				return lineToLengthDiff.Where(e => e.Value == lineToLengthDiff.Min(e2 => e2.Value)).First().Key;
			}

			return search == null || !search.Any() ? null : search.First(); //if search.any() == true, ienumerable is not empty
        }

		public string GetStationCode(string line)
		{
			foreach (string stationCode in stationCodes)
			{
				if (stationCode.Substring(0, 2).Equals(line))
				{
					return stationCode;
				}
			}
			return null;
		}

	}
}
