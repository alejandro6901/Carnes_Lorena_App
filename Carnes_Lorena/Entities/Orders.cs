using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Orders
    {
        public int Id { get; set; }
        public int Id_Client { get; set; }
        public string Client { get; set; }
        public string Id_Product { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public string Notes { get; set; }
        public int State { get; set; }
        public int Department { get; set; }
        public string Created { get; set; }
        public string Delivery { get; set; }
        public string Reminder { get; set; }
    }
}
