using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSP
{
    public class Path
    {
        public int Id { get; set; }
        public int firstNodeId { get; set; }
        public int secondNodeId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int weight { get; set; }
    }
}
