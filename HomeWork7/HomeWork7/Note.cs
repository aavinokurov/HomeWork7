using System;

namespace HomeWork7
{
    /// <summary>
    /// Создание новой записи
    /// </summary>
    public struct Note
    {
        #region Поля

        /// <summary>
        /// Имя
        /// </summary>
        private string firstName;

        /// <summary>
        /// Фамилия
        /// </summary>
        private string lastName;

        /// <summary>
        /// Возраст
        /// </summary>
        private uint age;

        /// <summary>
        /// Номер телефона
        /// </summary>
        private ulong phoneNumber;

        /// <summary>
        /// Дата добавления записи
        /// </summary>
        private DateTime date;

        #endregion

        #region Свойства

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return firstName; } }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return lastName; } }

        /// <summary>
        /// Возраст
        /// </summary>
        public uint Age { get { return age; } }

        /// <summary>
        /// Номер телефона
        /// </summary>
        public ulong PhoneNumber { get { return phoneNumber; } }

        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public DateTime Date { get { return date; } }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Создание новой записи
        /// </summary>
        /// <param name="firstName">Имя</param>
        /// <param name="lastName">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="phoneNumber">Номер телефона</param>
        /// <param name="date">Дата добавления записи</param>
        public Note(string firstName, string lastName, uint age, ulong phoneNumber, DateTime date)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.phoneNumber = phoneNumber;
            this.date = date;
        }

        #endregion

        #region Методы

        /// <summary>
        /// Выводит в консоль запись
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{firstName, 15} {lastName, 15} {age, 15} {phoneNumber, 15} {date.ToShortDateString(), 15}";
        }

        #endregion
    }
}
