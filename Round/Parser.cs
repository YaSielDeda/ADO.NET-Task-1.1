using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Round
{
    class Parser
    {
        double[] Res = new double[3];
        string[] Raw = new string[3];
        public double[] ParseRawData(string line)
        {           
            try
            {
                Regex reg = new Regex(@"(?<=\=)(.*?)(?=\\)");
                MatchCollection matches = reg.Matches(line);
                if (matches.Count > 0)
                {
                    for (int i = 0; i < Res.Length; i++)
                    {
                        Res[i] = double.Parse(matches[i].Value);
                    }
                    radiusCheck(Res[2]);
                }
                return Res;
            }
            catch (FormatException)
            {
                throw new FormatException("Data contains invalid symbols!");
            }
        }
        public void radiusCheck(double radius)
        {
            if (radius < 0)
                throw new LessThanZero("The radius can only be positive");
        }
    }
}
