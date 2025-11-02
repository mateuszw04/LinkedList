using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class Element
    {
        public int wartosc;
        public Element next;
        public Element prev;

        public Element(int wartosc)
        {
            this.wartosc = wartosc;
        }
    }
}
