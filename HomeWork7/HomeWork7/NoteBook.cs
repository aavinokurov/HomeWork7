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
        /// <param name="index">Индекс по которому следует вставить запись</param>
        public void Add(int index)
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

            notes.Insert(index, new Note(firstName, lastName, age, phoneNum, date));
        }

        /// <summary>
        /// Ноходит все индаксы записей по номеру телефона
        /// </summary>
        /// <returns></returns>
        private int[] FindPhoneNum()
        {
            ulong phoneNum;

            do
            {
                Console.WriteLine("Введите номер:");
            } while (!UInt64.TryParse(Console.ReadLine(), out phoneNum));

            List<int> result = new List<int>();
            
            for (int i = 0; i < notes.Count; i++)
            {
                if (notes[i].PhoneNumber == phoneNum)
                {
                    result.Add(i);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// Редактировать запись
        /// </summary>
        public void CorrectNote()
        {
            int[] indexNotes = FindPhoneNum();

            if (indexNotes.Length > 0)
            {
                int index;

                if (indexNotes.Length > 1)
                {
                    PrintToConsole(indexNotes);

                    do
                    {
                        do
                        {
                            Console.WriteLine("Введите индекс записи:");
                        } while (!Int32.TryParse(Console.ReadLine(), out index));
                    } while (index <= 0 || index > indexNotes.Length);

                    index--;

                    index = indexNotes[index];
                }
                else
                {
                    index = indexNotes[0];
                }

                notes.RemoveAt(index);

                Add(index);
            }
            else
            {
                Console.WriteLine("Записи с таким номером нет!");
            }
        }

        /// <summary>
        /// Удаляет все записи по номеру телефона
        /// </summary>
        public void Remove()
        {
            int[] indexPhoneNum = FindPhoneNum();

            for (int i = indexPhoneNum.Length - 1; i > -1; i--)
            {
                notes.RemoveAt(indexPhoneNum[i]);
            }

            Console.WriteLine($"Удалено записей: {indexPhoneNum.Length}");
        }

        /// <summary>
        /// Сортирока по возросту
        /// </summary>
        public void SortByAge()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                for (int j = i + 1; j < notes.Count; j++)
                {
                    if (notes[i].Age > notes[j].Age)
                    {
                        Note temp = notes[i];
                        notes[i] = notes[j];
                        notes[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка по номеру телефона
        /// </summary>
        public void SortByPhoneNum()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                for (int j = i + 1; j < notes.Count; j++)
                {
                    if (notes[i].PhoneNumber > notes[j].PhoneNumber)
                    {
                        Note temp = notes[i];
                        notes[i] = notes[j];
                        notes[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Сортировка по дате
        /// </summary>
        public void SortByDate()
        {
            for (int i = 0; i < notes.Count; i++)
            {
                for (int j = i + 1; j < notes.Count; j++)
                {
                    if (notes[i].Date > notes[j].Date)
                    {
                        Note temp = notes[i];
                        notes[i] = notes[j];
                        notes[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Загрузить данные из файла. Влзращает True - если получилось загрузить
        /// </summary>
        /// <returns></returns>
        public bool Load()
        {
            if (File.Exists(path))
            {
                notes = new List<Note>();

                using (StreamReader sr = new StreamReader(path))
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

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Загрузить записи в выбранном диапазоне дат. Влзращает True - если получилось загрузить
        /// </summary>
        /// <param name="date1">Начальная дата</param>
        /// <param name="date2">Конечная дата</param>
        /// <returns></returns>
        public bool Load(DateTime date1, DateTime date2)
        {
            if (File.Exists(path) && date1 < date2)
            {
                notes = new List<Note>();

                using (StreamReader sr = new StreamReader(path))
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

                        if (date >= date1 && date <= date2)
                        {
                            notes.Add(new Note(firstName, lastName, age, phoneNum, date));
                        }
                    }
                }

                return true;
            }
            else
            {
                if (date1 >= date2)
                {
                    Console.WriteLine("Дата начальная не может быть больше или равна конечной даты!");
                }

                return false;
            }
        }

        /// <summary>
        /// Сохраняет записи на диск
        /// </summary>
        public void Save()
        {
            using (FileStream fs = new FileStream(path,FileMode.Create))
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

        /// <summary>
        /// Выводит записи в консоль по заданным индексам
        /// </summary>
        /// <param name="index"></param>
        public void PrintToConsole(params int[] index)
        {
            Console.WriteLine($"{"Индекс",15} {titles[0],15} {titles[1],15} {titles[2],15} {titles[3],15} {titles[4],15}");

            for (int i = 0; i < index.Length; i++)
            {
                Console.Write($"{i + 1, 15} ");
                Console.WriteLine(notes[index[i]].Print());
            }
        }

        #endregion
    }
}
