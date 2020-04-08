using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Gulyaev_AG_2
{
    [Serializable]
    [XmlIncludeAttribute(typeof(Circle)), XmlIncludeAttribute(typeof(Triangle)), XmlIncludeAttribute(typeof(Rectangle))]
    public abstract class Figure
    {
        public abstract string Type();
        public abstract double Perimeter();
        public abstract double Area();

        /// <summary>
        /// Вывод информации (тип, площадь, периметр) о фигуре
        /// </summary>
        public void ShowInfo()
        {
            Trace.WriteLine("Вывод информации о фигуре");
            Trace.Indent();
            Console.WriteLine(
                $"Тип фигуры: {Type()}\n" +
                $"Площадь: {Area()}\n" +
                $"Периметр: {Perimeter()}"
            );
            Trace.Unindent();
            Console.WriteLine();
        }
    }

    [Serializable]
    public class Rectangle : Figure
    {
        private double l; // Длина прямоугольника
        private double h; // Высота прямоугольника

        public override string Type()
        {
            Trace.WriteLine("Идентификация типа фигуры - прямоугольник");
            return ("Rectangle");
        }

        public Rectangle()
        {  }

        /// <summary>
        /// Объявление прямоугольника
        /// </summary>
        /// <param name="recLength">Длина прямоугольника</param>
        /// <param name="recHeight">Высота прямоугольника</param>
        public Rectangle(double recLength, double recHeight)
        {
            l = recLength < 0 ? -recLength : recLength;
            h = recHeight < 0 ? -recHeight : recHeight;
            Trace.WriteLine("Создание прямоугольника с длиной " + l + " и высотой " + h);
        }

        /// <summary>
        /// Вычисление площади прямоугольника
        /// </summary>
        public override double Area()
        {
            Trace.WriteLine("Вычисление площади прямоугольника");
            return (l * h);
        }

        /// <summary>
        /// Вычисление периметра прямоугольника
        /// </summary>
        public override double Perimeter()
        {
            Trace.WriteLine("Вычисление периметра прямоугольника");
            return (2 * (l + h));
        }
    }

    [Serializable]
    public class Circle : Figure
    {
        private double r; // Радиус окружности

        public override string Type()
        {
            Trace.WriteLine("Идентификация типа фигуры - окружность");
            return ("Circle");
        }

        public Circle()
        {  }

        /// <summary>
        /// Объявление окружности
        /// <param name="cirRadius">Радиус окружности</param>
        /// </summary>
        public Circle(double cirRadius)
        {
            r = cirRadius < 0 ? -cirRadius : cirRadius;
            Trace.WriteLine("Создание окружности радиуса " + r);
        }

        /// <summary>
        /// Вычисление площади окружности
        /// </summary>
        public override double Area()
        {
            Trace.WriteLine("Вычисление площади окружности");
            return (Math.PI * r * r);
        }

        /// <summary>
        /// Вычисление периметра окружности
        /// </summary>
        public override double Perimeter()
        {
            Trace.WriteLine("Вычисление периметра окружности");
            return (2 * Math.PI * r);
        }
    }

    [Serializable]
    public class Triangle : Figure
    {
        private double a, b, c; // Стороны треугольника

        public override string Type()
        {
            Trace.WriteLine("Идентификация типа фигуры - треугольник");
            return ("Triangle");
        }

        public Triangle()
        {  }

        /// <summary>
        /// Объявление треугольника по трем сторонам
        /// <param name="trA">Первая сторона треугольника</param>
        /// <param name="trB">Вторая сторона треугольника</param>
        /// <param name="trC">Третья сторона треугольника</param>
        /// </summary>
        public Triangle(double trA, double trB, double trC)
        {
            a = trA < 0 ? -trA : trA;
            b = trB < 0 ? -trB : trB;
            c = trC < 0 ? -trC : trC;
            Trace.WriteLine("Создание треугольника со сторонами " + a + ", " + b + ", " + c);
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double Area()
        {
            Trace.WriteLine("Вычисление площади треугольника");
            double p = (a + b + c) / 2; // Полупериметр
            return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }

        /// <summary>
        /// Вычисление периметра треугольника
        /// </summary>
        public override double Perimeter()
        {
            Trace.WriteLine("Вычисление периметра треугольника");
            return (a + b + c);
        }
    }
}
