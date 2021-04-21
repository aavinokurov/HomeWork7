using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork7
{
    /// <summary>
    /// Создание новой записи
    /// </summary>
    public struct Note
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string firstName;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get { return firstName; } }

        /// <summary>
        /// Фамилия
        /// </summary>
        private string lastName;

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get { return lastName; } }

        /// <summary>
        /// Возраст
        /// </summary>
        private uint age;

        /// <summary>
        /// Возраст
        /// </summary>
        public uint Age { get { return age; } }

        /// <summary>
        /// Номер телефона
        /// </summary>
        private ulong phoneNumber;

        /// <summary>
        /// Номер телефона
        /// </summary>
        public ulong PhoneNumber { get { return phoneNumber; } }

        /// <summary>
        /// Дата добавления записи
        /// </summary>
        private DateTime date;

        /// <summary>
        /// Дата добавления записи
        /// </summary>
        public DateTime Date { get { return date; } }

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
    }
}
