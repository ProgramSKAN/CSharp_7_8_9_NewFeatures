using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_7_8_9.New_in_7
{
    public class Shape
    {

    }
    public class Rectangle:Shape
    {
        public int Width, Height;
    }

    public class Circle:Shape
    {

    }
    public class Pattern_Matching
    {
        public static void DisplayShape(Shape shape)
        {
            if(shape is Rectangle)
            {
                var rc = (Rectangle)shape;
                var width=rc.Width;
            }

            var rect = shape as Rectangle;
            if (rect != null)
            {
                var rc = (Rectangle)shape;
            }


            //C#-7
            if(shape is Rectangle r)
            {
                var width = r.Width;
            }

            if(!(shape is Circle notCircle))
            {
                
            }

            switch (shape)
            {
                case Circle c:
                    break;

                case Rectangle sq when (sq.Height == sq.Width):
                    break;

            }
        }
    }
}
