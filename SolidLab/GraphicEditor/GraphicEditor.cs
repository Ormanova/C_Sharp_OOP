﻿using System;

namespace P02.Graphic_Editor
{
    public class GraphicEditor : IShape
    {
        
        public GraphicEditor()
        {
            Shapes = new List<IShape>();
        }
        public List<IShape> Shapes { get; set; }
        //public void DrawShape(IShape shape)
        //{
        //    if (shape is Circle)
        //    {
        //        Console.WriteLine("I'm Circle");
        //    }
        //    else if (shape is Rectangle)
        //    {
        //        Console.WriteLine("I'm Recangle");
        //    }
        //    else if (shape is Square)
        //    {
        //        Console.WriteLine("I'm Square");
        //    }
        //}

        public void DrawShape()
        {
            Console.WriteLine($"I'm {this.GetType().Name}");
        }
    }
}
