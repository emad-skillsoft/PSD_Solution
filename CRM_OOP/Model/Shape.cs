using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_OOP.Model
{
    public enum Color { red,blue,green,orange}
    public abstract class Shape
    {
        //Data Members
        public Color Color;

        //Methods
        public abstract void Draw();

    }


    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("I'm a Circle");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("I'm a Rectangle");
        }
    }

}
