using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Dto
{
    public class Respons
    {
        public string state { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public dynamic custom { get; set; }
    }
}
