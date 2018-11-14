using System;
using System.Collections.Generic;
namespace APPD_Assignment_1
{
    public interface IVertex
    {
		string Key { get; } // returns station name
		Boolean Equals(IVertex o);
    }
}
