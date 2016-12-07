using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Node
    {
        /// <summary>
        /// The constructor of the class Nade
        /// </summary>
        public Node()
        {
            data = null;
            next = null;
        }

        /// <summary>
        /// The constructor of the class Nade
        /// </summary>
        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }

        /// <summary>
        /// Store the data
        /// </summary>
        public Object data { get; set; } // The payload

        /// <summary>
        /// Connect to the next node.
        /// </summary>
        public Node next { get; set; } // Reference to the next Node in the chain
    }
}
