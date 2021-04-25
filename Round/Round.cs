using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    public class Round
    {
        [JsonIgnore]
        public double Length => 2 * Math.PI * Radius;
        [JsonIgnore]
        public double Square => Math.PI * Math.Pow(Radius, 2);
        public double Radius { get; set; }
        public Point Center { get; set; }
        public Round()
        {
            Center = new Point();
        }
        public Round(Point Center, double Radius)
        {
            this.Center = Center;
            this.Radius = Radius;
        }
        public override string ToString()
        {
            return $"Round with center in points x: {Center.X}, y: {Center.Y} and radius: {Radius}";
        }
    }
}
