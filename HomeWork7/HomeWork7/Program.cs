using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    class Program
    {
        static void Main(string[] args)
        {
            NoteBook noteBook = new NoteBook("NoteBook.csv");

            bool isRun = true;

            while (isRun)
            {
                Console.WriteLine("Ежедневник");

                int answer;

                do
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Выберите команду:\n" +
                        "1 - Добавить новую запись\n" +
                        "2 - Удалить запись\n" +
                        "3 - Редактировать запись\n" +
                        "4 - Вывести все записи на экран\n" +
                        "5 - Отсортировать записи\n" +
                        "6 - Загрузить записи из файла\n" +
                        "7 - Загрузить записи в выбранном диапазоне дат\n" +
                        "8 - Сохранить записи в файл\n" +
                        "9 - Выход");
                    } while (!Int32.TryParse(Console.ReadLine(), out answer));
                } while (answer < 1 || answer > 9);

                Console.Clear();

                switch (answer)
                {
                    case 1:
                        noteBook.Add();
                        break;
                    case 2:
                        Console.WriteLine("Скоро будет!");
                        break;
                    case 3:
                        Console.WriteLine("Скоро будет!");
                        break;
                    case 4:
                        noteBook.PrintToConsole();
                        break;
                    case 5:
                        Console.WriteLine("Скоро будет!");
                        break;
                    case 6:
                        noteBook.Load();
                        break;
                    case 7:
                        Console.WriteLine("Скоро будет!");
                        break;
                    case 8:
                        noteBook.Save();
                        break;
                    case 9:
                        isRun = false;
                        break;
                }

                if (answer != 9)
                {
                    Console.WriteLine("Нажмите клавишу, чтобы продолжить:");
                    Console.ReadKey();
                }
            }
        }
    }
}
