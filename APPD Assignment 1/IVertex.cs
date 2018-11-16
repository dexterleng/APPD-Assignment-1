using System;
using System.Collections.Generic;
namespace APPD_Assignment_1
{
    public interface IVertex
    {
		string Name { get; }
		Boolean Equals(IVertex o);
    }
}
