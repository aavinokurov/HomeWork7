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
        private Note[] notes;

        /// <summary>
        /// Номер записи
        /// </summary>
        private int indexNote;

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;

        /// <summary>
        /// Заголовок таблицы
        /// </summary>
        private string[] titles;

        #endregion

        #region Свойства

        /// <summary>
        /// Кол-во записей
        /// </summary>
        public int Count { get { return indexNote; } }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создать ежедневник
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public NoteBook(string path)
        {
            this.path = path;
            indexNote = 0;
            notes = new Note[2];
            titles = new string[5];
        }

        #endregion

        #region Методы

        /// <summary>
        /// Увеличивает массив в 2 раза
        /// </summary>
        /// <param name="Flag">Условие выполнения</param>
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref notes, notes.Length * 2);
            }
        }

        /// <summary>
        /// Добавляет новую запись в ежедневник
        /// </summary>
        /// <param name="newNote">Новая запись</param>
        public void Add(Note newNote)
        {
            Resize(indexNote >= notes.Length);
            notes[indexNote] = newNote;
            indexNote++;
        }

        /// <summary>
        /// Загрузить данные из файла
        /// </summary>
        public void Load()
        {
            if (File.Exists(path))
            {
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

                        Add(new Note(firstName, lastName, age, phoneNum, date));
                    }
                }
            }
            else
            {
                Console.WriteLine("Данного файла не существует!");
            }
        }

        /// <summary>
        /// Выводит в консоль записи ежедневника
        /// </summary>
        public void PrintToConsole()
        {
            Console.WriteLine($"{titles[0],15} {titles[1],15} {titles[2],15} {titles[3],15} {titles[4],15}");

            for (int i = 0; i < indexNote; i++)
            {
                Console.WriteLine(notes[i].Print());
            }
        }

        #endregion
    }
}
