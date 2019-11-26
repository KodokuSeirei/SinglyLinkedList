using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp3
{
    public class Node
    {
        public void SetNextNode(Node _nextNode)
        {
            next = _nextNode;
        }
        public Phonebook Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }

        public Node Next
        {
            get
            {
                return next;
            }
        }

        private Node next;
        private Phonebook element;
    }
}
