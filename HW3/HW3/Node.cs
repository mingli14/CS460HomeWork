using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Node
    {
        public Object data; // The payload
        public Node next;   // Reference to the next Node in the chain

        public Node()
        {
            data = null;
            next = null;
        }

        public Node(Object data, Node next)
        {
            this.data = data;
            this.next = next;
        }
    }
}
