using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly
{
    public class ConvertType
    {
        public int StringToInt(string input)
        {
            int output;
            if (int.TryParse(input,out output))
            {
                return output;
            } throw new Exception("Invalid");
        }
    }
}
