using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    class Orders
    {
        public int Id { get; set; }
        public int Id_Client { get; set; }
        public string Id_Product { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public bool State { get; set; }
    }
}
