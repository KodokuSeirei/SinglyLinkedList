using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    class PhonebookList
    {
        public PhonebookList()
        {
            // создание пустого списка
            headNode = null;
            tailNode = headNode;
            Length = 0;
        }
        public void Push(Phonebook _element)
        {
            if (headNode == null)
            {
                // создать узел, сделать его головным
                headNode = new Node
                {
                    Element = _element
                };
                // этот же узел и является хвостовым
                tailNode = headNode;
                // следующего узла нет
                headNode.SetNextNode(null);
            }
            else
            {
                // создать временный узел
                Node newNode = new Node();
                // следующий за предыдущим хвостовым узлом - это наш временный новый узел
                tailNode.SetNextNode(newNode);
                // сделать его же новым хвостовым
                tailNode = newNode;
                tailNode.Element = _element;
                // следующего узла пока нет
                tailNode.SetNextNode(null);
            }

            ++Length;
        }


        public Phonebook this[int _position]
        {
            get
            {
                // дабы не загромождать пример, 
                // опустим проверку на валидность переданного параметра '_position'
                Node tempNode = headNode;
                for (int i = 0; i < _position; ++i)
                    // переходим к следующему узлу списка
                    tempNode = tempNode.Next;
                return tempNode.Element;
            }
        }

        public int Length { get; private set; }
        private Node headNode;
        private Node tailNode;

    }
    }

       

