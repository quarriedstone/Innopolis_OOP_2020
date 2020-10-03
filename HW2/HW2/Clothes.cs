using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    // Clothes object. Has additional field `size`
    public enum Size{ S, M, L, XL }
    class Clothes : Inventory
    {
        public Size Size { set; get; }
        public Clothes(String name, DateTime createDate, double price, Size size) : base(name, createDate, price)
        {
            Size = size;
            Category = Category.Clothes;
        }
    }
}
