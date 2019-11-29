using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
   public class Subscriber
    {
        public string PhoneNumber { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Rate { get; set; }
        public Subscriber(string phoneNumber, string type, string name, string adress, string rate)
        {
            PhoneNumber = phoneNumber;
            Type = type;
            Name = name;
            Adress = adress;
            Rate = rate;
        }
    }
}
