using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
   public class Subscriber
    {
        //Объявляем свойства
        public string Телефон { get; set; }
        public string Тип { get; set; }
        public string Имя { get; set; }
        public string Адрес { get; set; }
        public string Тариф { get; set; }
        //Присваиваем свойствам значения через конструктор
        public Subscriber(string phoneNumber, string type, string name, string adress, string rate)
        {
            Телефон = phoneNumber;
            Тип = type;
            Имя = name;
            Адрес = adress;
            Тариф = rate;
        }
    }
}
