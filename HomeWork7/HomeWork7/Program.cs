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
            noteBook.Load();
            noteBook.PrintToConsole();
        }
    }
}
