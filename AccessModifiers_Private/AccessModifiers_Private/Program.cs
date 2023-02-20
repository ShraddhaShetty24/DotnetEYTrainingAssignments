using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers_Private
{
    class ValuesOfVariables
    {
        private int x;
        private int y;
    }

    class Program
    {
        static void Main()
        {
            ValuesOfVariables p = new ValuesOfVariables();
            // Direct access to public members.
           // p.x = 10; //error- as it is private
            //p.y = 15; // error -as it is private
           
        }
    }
}
