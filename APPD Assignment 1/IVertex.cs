using System;
using System.Collections.Generic;
namespace APPD_Assignment_1
{
    public interface IVertex
    {
        string GetKey();
        Boolean Equals(IVertex o);
    }
}
