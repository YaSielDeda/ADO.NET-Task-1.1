using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    [Serializable]
    public class LessThanZero : ArgumentException
    {
        public LessThanZero() { }
        public LessThanZero(string message) : base(message) { }
        public LessThanZero(string message, Exception inner) : base(message, inner) { }
        protected LessThanZero(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}