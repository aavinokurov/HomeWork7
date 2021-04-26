using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    public struct NoteBook
    {
        #region Поля

        /// <summary>
        /// Записи в телефоной книжке
        /// </summary>
        public List<Note> notes;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        private string[] titles;

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создать ежедневник
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public NoteBook(string path)
        {
            this.path = path;
            notes = new List<Note>();
            titles = "Имя,Фамилия,Возраст,Номер,Дата".Split(',');
        }

        #endregion

        #region Методы

        /// <summary>
        /// Добавляет новую учетную запись
        /// </summary>
        public void Add()
        {
            string firstName;
            string lastName;
            uint age;
            ulong phoneNum;
            DateTime date;

            do
            {
                Console.WriteLine("Введите имя:");
                firstName = Console.ReadLine();
            } while (string.IsNullOrEmpty(firstName));

            do
            {
                Console.WriteLine("Введите фамилию:");
                lastName = Console.ReadLine();
            } while (string.IsNullOrEmpty(lastName));

            do
            {
                do
                {
                    Console.WriteLine("Введите возраст:");
                } while (!UInt32.TryParse(Console.ReadLine(), out age));
            } while (age == 0 || age > 110);

            do
            {
                Console.WriteLine("Введите номер телефона");
            } while (!UInt64.TryParse(Console.ReadLine(),out phoneNum));

            do
            {
                Console.WriteLine("Введите дату:");
            } while (!DateTime.TryParse(Console.ReadLine(), out date));

            notes.Add(new Note(firstName,lastName,age,phoneNum,date));
        }

        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        public void Load()
        {
            if (File.Exists(path))
            {
                notes = new List<Note>();

                using(StreamReader sr = new StreamReader(path))
                {
                    titles = sr.ReadLine().Split(',');

                    while (!sr.EndOfStream)
                    {
                        string[] temp = sr.ReadLine().Split(',');

                        string firstName = temp[0];
                        string lastName = temp[1];
                        uint age = UInt32.Parse(temp[2]);
                        ulong phoneNum = UInt64.Parse(temp[3]);
                        DateTime date = Convert.ToDateTime(temp[4]);

                        notes.Add(new Note(firstName, lastName, age, phoneNum, date));
                    }
                }
            }
            else
            {
                Console.WriteLine("Данного файла не существует!");
            }
        }

        /// <summary>
        /// Сохраняет записи на диск
        /// </summary>
        public void Save()
        {
            if (notes.Count > 0)
            {
                using (FileStream fs = new FileStream(path,FileMode.OpenOrCreate))
                {
                    using (StreamWriter sw = new StreamWriter(fs,Encoding.UTF8))
                    {
                        sw.WriteLine($"Имя,Фамилия,Возраст,Номер,Дата");

                        for (int i = 0; i < notes.Count; i++)
                        {
                            sw.WriteLine($"{notes[i].FirstName},{notes[i].LastName},{notes[i].Age},{notes[i].PhoneNumber},{notes[i].Date.ToShortDateString()}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Записей еще нет!");
            }
        }

        /// <summary>
        /// Выводит в консоль записи ежедневника
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{titles[0],15} {titles[1],15} {titles[2],15} {titles[3],15} {titles[4],15}");

            for (int i = 0; i < notes.Count; i++)
            {
                Console.WriteLine(notes[i].Print());
            }
        }

        #endregion
    }
}
