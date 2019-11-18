using System;
using System.Collections.Generic;
using System.Text;

namespace UtlamningsTerminal
{
    class Pizza
    {
        public int state, ordernumber;
        public string name, extra;
        public Pizza()
        {
            state = 0;
            ordernumber = 0;
            name = "";
            extra = "";

        }
        public Pizza(string pizza, string extras)
        {
            state = 0;
            ordernumber = 0;
            name = pizza;
            extra = extras;

        }
        public Pizza(string pizza, string extras, int ordernumberin)
        {
            state = 0;
            ordernumber = ordernumberin;
            name = pizza;
            extra = extras;

        }
        public void MoveToNextState()
        {
            state++;

        }
    }
}
