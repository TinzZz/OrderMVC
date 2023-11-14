using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest_Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public string SenderCity { get; set; }
        public string SenderAdress { get; set; }
        public string DeliveryCity { get; set; }
        public string DeliveryAdress { get; set; }
        public double Weight { get; set; }
        public DateTime PickUpDate { get; set; }
    }
}
