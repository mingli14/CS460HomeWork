using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class LinkedStack
    {
        //The Node is used to store the data
        private Node top;

        //The constructor of the class LinkedStack
        public LinkedStack()
        {
            top = null; // Empty stack condition
        }

        /// <summary>
        /// Get the data at the top.
        /// </summary>
        /// <param name="newItem">The data at the top</param>
        /// <returns>The data at the top</returns>
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

        /// <summary>
        /// Get the data at the top.
        /// </summary>
        /// <returns>The data at the top</returns>
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

        /// <summary>
        /// Get the data at the top.
        /// </summary>
        /// <returns>The data at the top</returns>
        public Object peek()
        {
            if (isEmpty())
            {
                return null;
            }
            return top.data;
        }

        /// <summary>
        /// Check whether the stack is empty.
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return top == null;
        }

        /// <summary>
        /// Clear the stack.
        /// </summary>
        public void clear()
        {
            top = null;
        }

    }
}
