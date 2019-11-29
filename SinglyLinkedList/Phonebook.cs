using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    public struct Phonebook
    {
       public string Name { get; set; }
       public string OwnerName { get; set; }
       public string [,]Data { get; set; }
        
        public Phonebook(string name, string ownerName,string[,]data)
        {
            Name = name;
            OwnerName = ownerName;
            Data = data;
        }

        
    }
}
