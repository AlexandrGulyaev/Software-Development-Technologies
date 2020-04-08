using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Gulyaev_AG_2
{
    class Program
    {
        /// <summary>
        /// Создание ограниченного (по числу элементов) списка фигур
        /// </summary>
        /// <param name="n">Максимальная длина списка</param>
        /// <returns>Список фигур</returns>
        static List<Figure> CreateList(int n)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                sr.ReadLine();
                List<Figure> figures = new List<Figure>();

                Trace.WriteLine("Начало трассировки");

                for (int k = 0; k < n; k++)
                {
                    // Считывание строки с параметрами фигуры
                    string line = sr.ReadLine();
                    // Определение формы фигуры
                    string form = line.Split()[0];
                    // Добавление в список информации о соответствующей фигуре
                    try
                    {
                        Trace.WriteLine("Объявление фигуры " + (k + 1));
                        Trace.Indent();
                        switch (form.ToLower())
                        {
                            case "rectangle":
                                Rectangle rectangle = new Rectangle(double.Parse(line.Split()[1]), double.Parse(line.Split()[2]));
                                figures.Add(rectangle);
                                break;

                            case "triangle":
                                Triangle triangle = new Triangle(double.Parse(line.Split()[1]), double.Parse(line.Split()[2]), double.Parse(line.Split()[2]));
                                figures.Add(triangle);
                                break;

                            case "circle":
                                Circle circle = new Circle(double.Parse(line.Split()[1]));
                                figures.Add(circle);
                                break;
                        }
                        Trace.Unindent();
                    }
                    catch (System.FormatException)
                    {
                        Console.WriteLine("Данные об одной из фигур некорректны.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                return figures;
            }
        }

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line = sr.ReadLine();

                try
                {
                    int n = Int32.Parse(line.Trim());
                    
                    // Создание списка фигур
                    List<Figure> figures = CreateList(n);

                    // Вывод информации о фигурах, если список полный
                    if (figures.Count != n)
                    {
                        Console.WriteLine("Данные об одной из фигур не найдены, или название фигуры некорректно.");
                    }
                    else
                    {
                        Trace.Indent();
                        TextWriter serialWriter = new StreamWriter("figures.xml");
                        XmlSerializer ser = new XmlSerializer(typeof(Figure));
                        for (int k = 0; k < n; k++)
                        {
                            Trace.WriteLine("");
                            figures[k].ShowInfo();
                            ser.Serialize(serialWriter, figures[k]);
                        }
                        Trace.Unindent();
                    }
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Введенное количество фигур некорректно.");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
            }
            Console.ReadKey();
        }
    }
}
