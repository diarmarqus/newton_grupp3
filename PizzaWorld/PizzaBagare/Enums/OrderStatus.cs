using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PizzaBagare
{
    /// <summary>
    /// Enum för status uppdatering av Order
    /// </summary>
    public enum OrderStatus 
    { 
        [Description("Ny")]
        New,
        [Description("Ugn")]
        InOven,
        [Description("Klar")]
        Done 
    }
}
