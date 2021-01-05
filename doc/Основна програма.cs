using System;  //стандартна бібліотека з набором функцій тіпа Mаth і так далі
using MyFunctions;  //наша бібліотека з функціями (в с# це методи)

namespace Variant12
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStrings = Func.GetNumber("Введiть кiлькiсть рядкiв"); //отримання кількості рядків у масиві рядків

            string[] arrayStrings = new string[countStrings]; //створюємо масив рядків, введених з клавіатури
            Func.GetStringArray(ref arrayStrings);  //ініціалізуємо масив рядків

            int width = 0; //ширина матриці
            int[,] matrix = Func.CreateMatrix(countStrings, arrayStrings, ref width); //створюємо матрицю

            Func.PrintMatrix(matrix, countStrings, width); //виводимо матрицю

            //Func.MatrixSort(ref matrix, countStrings, width); //сортуємо матрицю за елементами за зростанням

            //Func.PrintMatrix(matrix, countStrings, width); //виводимо матрицю

            Func.MatrixFullSort(ref matrix, countStrings, width); //повне сортування матриці

            Func.PrintMatrix(matrix, countStrings, width); //виводимо матрицю

            Console.ReadKey();  //щоб консольне вікно не закривалось зразу
        }
    }
}
