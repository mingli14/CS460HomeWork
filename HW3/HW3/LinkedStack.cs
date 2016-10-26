using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class LinkedStack
    {
        private Node top;

        public LinkedStack()
        {
            top = null; // Empty stack condition
        }

        public Object push(Object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
            top = newNode;
            return newItem;
        }

        public Object pop()
        {
            if (isEmpty())
            {
                return null;
            }
            Object topItem = top.data;
            top = top.next;
            return topItem;
        }

        public Object peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.data;
        }

        public bool isEmpty()
        {
            return top == null;
        }

        public void clear()
        {
            top = null;
        }

    }
}
