using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int Num_Order { get; set; }
        public string Client { get; set; }
        public int Client_Type { get; set; }
        public int Oem { get; set; }
        public int State { get; set; }
        public int Department { get; set; }
        public string Created { get; set; }
        public string Delivery { get; set; }
        public string Reminder { get; set; }
    }
}
