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
                bool canLoad;

                switch (answer)
                {
                    case 1:
                        noteBook.Add(noteBook.notes.Count);
                        Console.WriteLine("Запись добавлена!");
                        break;
                    case 2:
                        noteBook.Remove();
                        break;
                    case 3:
                        noteBook.CorrectNote();
                        break;
                    case 4:
                        noteBook.PrintToConsole();
                        break;
                    case 5:
                        string sort;

                        do
                        {
                            Console.WriteLine("Сортировать по:\n" +
                                              "1 - Возрасту\n" +
                                              "2 - Номеру телефона\n" +
                                              "3 - Дате");
                            sort = Console.ReadLine();
                        } while (sort != "1" && sort != "2" && sort != "3");

                        switch (sort)
                        {
                            case "1":
                                noteBook.SortByAge();
                                break;
                            case "2":
                                noteBook.SortByPhoneNum();
                                break;
                            case "3":
                                noteBook.SortByDate();
                                break;
                        }

                        break;
                    case 6:
                        canLoad = noteBook.Load();
                        Console.WriteLine(canLoad ? "Данные загружены!" : "Файла еще не существует.");
                        break;
                    case 7:
                        DateTime date1;
                        DateTime date2;

                        do
                        {
                            Console.WriteLine("Введите начальную дату:");
                        } while (!DateTime.TryParse(Console.ReadLine(), out date1));

                        do
                        {
                            Console.WriteLine("Введите начальную конечную:");
                        } while (!DateTime.TryParse(Console.ReadLine(), out date2));

                        canLoad = noteBook.Load(date1, date2);
                        Console.WriteLine(canLoad ? "Данные загружены!" : "Данные не загружены!");
                        break;
                    case 8:
                        noteBook.Save();
                        Console.WriteLine("Данные сохранены.");
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
