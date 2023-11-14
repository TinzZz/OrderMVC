using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OrderTest_Model
{
    public class OrderVM
    {
        [Required(ErrorMessage = "Введите город отправителя!")]
        public string SenderCity { get; set; }
        
        [Required(ErrorMessage = "Введите адрес отправителя!")]
        public string SenderAdress { get; set; }
        
        [Required(ErrorMessage = "Введите город получателя!")]
        public string DeliveryCity { get; set; }
        
        [Required(ErrorMessage = "Введите адрес получателя!")]
        public string DeliveryAdress { get; set; }
        
        [Required(ErrorMessage = "Введите вес посылки (кг)!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Вес должен быть больше 0")]
        public double Weight { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Введите дату забора груза!")]
        public DateTime PickUpDate { get; set; }
    }
}
