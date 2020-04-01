using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gulyaev_AG_2
{
    abstract class Figure
    {
        public abstract string Type();
        public abstract double Perimeter();
        public abstract double Area();

        /// <summary>
        /// Вывод информации (тип, площадь, периметр) о фигуре
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine(
                $"Тип фигуры: {Type()}\n" +
                $"Площадь: {Area()}\n" +
                $"Периметр: {Perimeter()}"
            );
            Console.WriteLine();
        }
    }

    class Rectangle : Figure
    {
        private double l; // Длина прямоугольника
        private double h; // Высота прямоугольника

        /// <summary>
        /// Объявление прямоугольника
        /// </summary>
        /// <param name="recLength">Длина прямоугольника</param>
        /// <param name="recHeight">Высота прямоугольника</param>
        public Rectangle(double recLength, double recHeight)
        {
            l = recLength < 0 ? -recLength : recLength;
            h = recHeight < 0 ? -recHeight : recHeight;
        }

        /// <summary>
        /// Вычисление площади прямоугольника
        /// </summary>
        public override double Area()
        {
            return (l * h);
        }

        /// <summary>
        /// Вычисление периметра прямоугольника
        /// </summary>
        public override double Perimeter()
        {
            return (2 * (l + h));
        }

        public override string Type()
        {
            return ("Rectangle");
        }
    }

    class Circle : Figure
    {
        private double r; // Радиус окружности

        /// <summary>
        /// Объявление окружности
        /// <param name="cirRadius">Радиус окружности</param>
        /// </summary>
        public Circle(double cirRadius)
        {
            r = cirRadius < 0 ? -cirRadius : cirRadius;
        }

        /// <summary>
        /// Вычисление площади окружности
        /// </summary>
        public override double Area()
        {
            return (Math.PI * r * r);
        }

        /// <summary>
        /// Вычисление периметра окружности
        /// </summary>
        public override double Perimeter()
        {
            return (2 * Math.PI * r);
        }

        public override string Type()
        {
            return ("Circle");
        }
    }

    class Triangle : Figure
    {
        private double a, b, c; // Стороны треугольника

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
        }

        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        public override double Area()
        {
            double p = (a + b + c) / 2; // Полупериметр
            return (Math.Sqrt(p * (p - a) * (p - b) * (p - c)));
        }

        /// <summary>
        /// Вычисление периметра треугольника
        /// </summary>
        public override double Perimeter()
        {
            return (a + b + c);
        }

        public override string Type()
        {
            return ("Triangle");
        }
    }
}
