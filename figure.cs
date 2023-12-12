using System;

namespace Program
{
    public abstract class Figure
    {

        private string name;
        // абстрактный метод для получения площади
        public abstract double Area();
        // абстрактное свойство для получения площади
        public double Area2 { get; set; }

        public Figure(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public virtual void Print()
        {
            Console.WriteLine($"Название фигуры: {Name}");
        }

    }

    class Triangle : Figure
    {
        private int _a;
        private int _b;
        private int _c;

        public Triangle(string name, int _a, int _b, int _c) : base(name)
        {
            a = _a;
            b = _b;
            c = _c;
        }

        public int a
        {
            get { return _a; }
            set { _a = value; }
        }

        public int b
        {
            get { return _b; }
            set { _b = value; }
        }

        public int c
        {
            get { return _c; }
            set { _c = value; }
        }

        public override double Area()
        {
            double P = 0.5 * (a + b + c);
            Area2 = Math.Sqrt(P * (P - a) * (P - b) * (P - c));
            return Area2;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"a = {a}, b = {b}, c = {c}");
        }
    }

    class TriangleColor : Triangle
    {
        private string _color;

        public TriangleColor(string name, int _a, int _b, int _c, string _color) : base(name, _a, _b, _c)
        {
            color = _color;
        }

        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        public override double Area()
        {
            return base.Area();
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Цвет фона треугольника: {color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle1 = new Triangle("Треугольник", 5, 4, 3);
            triangle1.Print();
            Console.WriteLine($"Площадь фигуры: {triangle1.Area()}");

            TriangleColor triangle2 = new TriangleColor("Треугольник", 6, 8, 10, "Зеленый");
            triangle2.Print();
            Console.WriteLine($"Площадь фигуры: {triangle2.Area()}");
        }
    }

}

