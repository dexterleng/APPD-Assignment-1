﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace APPD_Assignment_1
{
    public class Station:IVertex
    {
        private List<string> stationCodes = new List<string>();
        private string stationName;

        public Station(string stationName)
        {
            this.stationName = stationName;
        }

        public void AddStationCode(string stationCode)
        {
            this.stationCodes.Add(stationCode);
        }

        public List<string> GetStationCodes()
        {
            return this.stationCodes;
        }

        public string GetName()
        {
            return this.stationName;
        }

        public string GetKey()
        {
            return this.GetName();
        }

        public Boolean Equals(IVertex o)
        {
            return this.GetKey().Equals(o.GetKey());
        }

        public List<string> GetLines()
        {
            List<string> lines = new List<string>();
            foreach (string code in this.GetStationCodes())
            {
                lines.Add(code.Substring(0, 2));
            }
            return lines;
        }

        public string firstCommonLine(Station other)
        {
            return this.GetLines().Intersect(other.GetLines()).First();
        }

		public string GetStationCode(string line)
		{
			foreach (string stationCode in this.stationCodes)
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
