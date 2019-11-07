using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaBagare
{
    /// <summary>
    /// Tillbehör dryck/sallad/mm
    /// </summary>
    class Extra
    {
        public Extra(string item, string size = "")
        {
            this.Item = item;
            this.Size = size;
        }

        public string Item { get; set; }
        public string Size { get; set; }
    }
}
