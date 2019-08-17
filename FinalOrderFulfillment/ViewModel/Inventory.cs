using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalOrderFulfillment.ViewModel
{
   public class Inventory
   {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int WarehouseLocationID { get; set; }
        public int QuantityInLocation { get; set; }
    }

}
