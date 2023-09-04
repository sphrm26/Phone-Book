using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Response
    {
        public List<Object> objects { get; set; }
        public bool isSuccess { get; set; }
        public string message { get; set; }
    }
}
