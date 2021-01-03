using System; //стандартна бібліотека з набором функцій тіпа Mаth і так далі

namespace MyFunctions
{
    public class Func
    {
        public static int GetNumber(string label)  //отримання числа введенного з клавіатури
        {
            Console.Write(label + " : ");
            int number = Convert.ToInt32(Console.ReadLine());  //власне число
            Console.WriteLine();
            return number;  //повертаємо значення числа введеного з клавіатури
        } 

        public static void GetStringArray(ref string [] arrayStrings)  //отримання масиву строк, введених з клавіатури
        {
            for (int i = 0; i < arrayStrings.Length; i++)  //кількість строк
            {
                Console.Write("рядок " + (i + 1) + " : ");
                arrayStrings[i] = Console.ReadLine();  //зчитування строки з консолі
            }
        }

        public static void BinToDec(ref string str_temp, ref int count_temp)  //переведення строки з числами у двійковій системі у строку з числами у десятковій системі
        {
            string[] temp = str_temp.Split(' ');  //отримали масив двійкових чисел з поточної строки
            string str = "";                //записуємо результат чисел у десятковій системі
            for (int i = 0; i < temp.Length; i++)
            { 
                str += Convert.ToInt64(temp[i], 2) + " ";   //переводимо з двійкової в десяткову
                count_temp+=1;                              //рахуємо кількість чисел в строці
            }
            str_temp = str.Remove(str.Length - 1);  //видаляємо зайвий пробіл в кінці строки
        }

        public static void PrintMatrix(int [,] matrix, int rows, int cols)    //виведення матриці
        {
            Console.WriteLine("\nМатриця :");
            for (int i = 0; i < rows; i++)  //кількість рядків
            {
                for (int j = 0; j < cols; j++)  //кількість стовпчиків
                    Console.Write(String.Format("{0, 5}", matrix[i, j]) + " ");   //виведення комірки у відповідному форматі
                Console.WriteLine("\n");
            }
        }

        public static int [,] CreateMatrix(int countStrings, string [] arrayStrings, ref int maxWidth)  //створення матриці згідно завдання
        {
            int count_temp = 0;
            int count_numbers = 0;
            for (int i = 0; i < countStrings; i++)
            {
                Func.BinToDec(ref arrayStrings[i], ref count_temp);
                if(count_temp>maxWidth)
                    maxWidth = count_temp;
                count_numbers += count_temp;
                count_temp = 0;
            }
            
            int [,] matrix = new int [countStrings, maxWidth];
            for (int i = 0; i < countStrings; i++)
            {
                string[] temp = arrayStrings[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    matrix[i, j] = Convert.ToInt32(temp[j]);
            }

            if (count_numbers < countStrings * maxWidth)
            {
                Console.Write("\nВведiть перше число з промiжку : ");
                int from = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введiть друге число з промiжку : ");
                int to = Convert.ToInt32(Console.ReadLine());

                Random rand = new Random();

                for (int i = 0; i < countStrings; i++)
                {
                    string[] temp = arrayStrings[i].Split(' ');
                    for (int j = temp.Length; j < maxWidth; j++)
                    {
                        matrix[i, j] = rand.Next(Math.Abs(to), Math.Abs(from)) * (-1);
                    }
                }
            }

            return matrix;
        }

        public static void MatrixSort(ref int [,] matrix, int rows, int cols)  //сортування елементів матриці за зростанням
        {
            int count_true = 0; //перевірка чи всі кожен елемент менший - рівний наступного
             
            for (int i = 0; i < rows; i++)   //рухаємось по рядках
            {
                count_true = 0;    //обнулили
                while (count_true != cols - 1)  //поки не відсортовано
                {
                    count_true = 0;  //обнулили
                    for (int j = 0; j < cols-1; j++)  //рухаємось по стовчпиках
                    {
                        if (Math.Abs(matrix[i, j]) > Math.Abs(matrix[i, j + 1]))  //перевірка по модулю і заміна через тимчасову змінну
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, j + 1];
                            matrix[i, j + 1] = temp;
                        }
                    }

                    for (int k = 0; k < cols - 1; k++)  //перевірка чи повністю відсортовано рядок матриці
                    {
                        if (Math.Abs(matrix[i, k]) <= Math.Abs(matrix[i, k + 1]))  //перевірка по модулю
                            count_true += 1;
                    }
                }
            }

            count_true = 0;  //обнулили
            int[] tempArray = new int[cols];  //тимчасовий рядок 

            while (count_true != cols - 1)  //поки не відсортуємо рядки
            {
                count_true = 0; //обнулили
                for (int i = 0; i < rows-1; i++)  //рухаємось по рядках
                {
                    if (Math.Abs(matrix[i, 0]) > Math.Abs(matrix[i + 1, 0]))  //перевірка по модулю за першим елементом
                    {
                        for (int j = 0; j < cols; j++)  //заміна між собою двох рядків через тимчасовий
                        {
                            tempArray[j] = matrix[i, j];
                            matrix[i, j] = matrix[i + 1, j];
                            matrix[i + 1, j] = tempArray[j];
                        }
                    }
                }

                for (int k = 0; k < rows - 1; k++)  //перевірка чи відсортовані усі рядки матриці за зростанням
                {
                    if (Math.Abs(matrix[k, 0]) <= Math.Abs(matrix[k+1, 0]))  //перевірка по модулю за першим елементом
                        count_true += 1;
                }
            }
        }

    }
}
