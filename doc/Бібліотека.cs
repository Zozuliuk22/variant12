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

            //string[] temp = Func.SplitStr(str_temp, ' ');     
 
            string str = "";                //записуємо результат чисел у десятковій системі
            for (int i = 0; i < temp.Length; i++)
            {
                str += Convert.ToInt64(temp[i], 2) + " ";   //переводимо з двійкової в десяткову
                //str += Func.BinToDecFormula(temp[i], 2) + " "; 
                count_temp+=1;                              //рахуємо кількість чисел в строці
            }
            str_temp = str.Remove(str.Length - 1);  //видаляємо зайвий пробіл в кінці строки

            //str_temp = Func.RemoveStr(str, str.Length-1);
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
            int count_temp = 0;    //кількість чисел в кожному рядку
            int count_numbers = 0;  //загальна кількість чисел
            for (int i = 0; i < countStrings; i++)  //і - індекс рядка в масиві строк
            {
                Func.BinToDec(ref arrayStrings[i], ref count_temp);  //перевоимо строку чисел у двійковій системі числення на строку з числами з десяткової системи
                if(count_temp>maxWidth)  //знаходимо найбільшу кількість чисел в рядку
                    maxWidth = count_temp;  
                count_numbers += count_temp;   //рахуємо загальну кількість чисел в рядку
                count_temp = 0;  //обнуляємо проміжну кількість чисел
            }
            
            int [,] matrix = new int [countStrings, maxWidth];  //вихідна матриця
            for (int i = 0; i < countStrings; i++)  //і - індекс рядка матриці
            {
                string[] temp = arrayStrings[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)   //j - індекс стовпчика матриці
                    matrix[i, j] = Convert.ToInt32(temp[j]);     //заповнюємо матрицю числами які дано
            }

            if (count_numbers < countStrings * maxWidth)  //якщо чисел не вистачає
            {
                Console.WriteLine("Чисел недостатньо для заповнення матрицi !!!");
                Console.Write("\nВведiть перше число з промiжку : ");
                int from = Convert.ToInt32(Console.ReadLine());  //перше число з проміжку
                Console.Write("Введiть друге число з промiжку : ");
                int to = Convert.ToInt32(Console.ReadLine());  //останнє число з проміжку

                Random rand = new Random();  //рандом

                for (int i = 0; i < countStrings; i++)  //і - індекс рядка матриці
                {
                    string[] temp = arrayStrings[i].Split(' ');
                    for (int j = temp.Length; j < maxWidth; j++)  //j - індекс стовпчика матриці
                    {
                        matrix[i, j] = rand.Next(Math.Abs(to), Math.Abs(from)) * (-1);  //генерація числа. Оскільки рандом генерує додатні числа, ми їх множимо на -1
                    }
                }
            }

            return matrix; //повертаємо сформовану матрицю
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

            while (count_true != rows - 1)  //поки не відсортуємо рядки
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

        public static string [] SplitStr(string str, char key) //розбиття рядка за символом
        {
            int count_words = 0;    //кількість слів
            for (int i = 0; i < str.Length; i++) //і - індекс в головній строці
                if (str[i] == key) //якщо ми найшли символ за яким хочемо розбити - ми знайшли слово
                    count_words += 1;
            count_words += 1;  //слово після останнього ключового символу

            string [] rezult = new string [count_words];  //масив що повернеться
            string temp = "";  //слово
            int j = 0;  //індекс масива строк
            for (int i = 0; i < str.Length; i++)  //і - індекс головної строки
            {
                if (str[i] != key)  //поки не знайдено ключовий символ формуємо слово
                    temp += str[i];
                else
                {
                    rezult[j] = temp;  //додаємо слово в масив
                    temp = "";  //очищуємо тимчасову змінну 
                    j += 1;  //зібльшуємо індекс масива
                }
            }
            rezult[j] = temp; //додаємо останнє слово
            return rezult; //повертаємо масив слів
        }

        public static string RemoveStr(string str, int key)  //видалення символів строки починаючи з вказаного і до кінця
        {
            string rezult = "";  //результат строки, яку ми отримаємо
            for (int i = 0; i < key; i++)  //і - індекс символа строки
                rezult += str[i];  //додаємо поки не дойдемо до вказаного користувачем індексом символа
            return rezult; //повертаємо результат обрізаної строки
        }

        public static int BinToDecFormula(string str, int type) //формула переведення з двійкової системи числення в десяткову
        {           
            int rezult = 0; //результат перетворення
            for (int i = str.Length - 1; i >= 0; i--) //i - степінь в формулі
                rezult += (int)Math.Pow(type, i) * Convert.ToInt32(Convert.ToString(str[str.Length - i - 1])); //формула переведення https://ru.wikihow.com/%D0%BF%D0%B5%D1%80%D0%B5%D0%B2%D0%BE%D0%B4%D0%B8%D1%82%D1%8C-%D0%B8%D0%B7-%D0%B4%D0%B2%D0%BE%D0%B8%D1%87%D0%BD%D0%BE%D0%B9-%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D1%8B-%D0%B2-%D0%B4%D0%B5%D1%81%D1%8F%D1%82%D0%B8%D1%87%D0%BD%D1%83%D1%8E

            return rezult; //повертаємо результат
        }

        public static void MatrixFullSort(ref int [,] matrix, int rows, int cols) //повне сортування елементів матриці по модулю
        {
            int [] tempArr = new int[rows*cols];  //масив в який будуть записані усі значення в одну строку
            for (int i = 0; i < rows; i++)  //і - індекс рядків матриці
            {
                for (int j = 0; j < cols; j++)  //j - індекс стовпчиків матриці
                    tempArr[i*cols + j] = matrix[i, j];  //ініціалізуємо масив temp
            }

            int count_true = 0;  //кількість правильно розставлених пар елементів
            while (count_true != rows * cols - 1)   //поки масив повністю не відсортовано
            {
                count_true = 0;  //обнулили
                for (int i = 0; i < rows * cols-1; i++)  //і - індекс одновимірного масиву
                {
                    if (Math.Abs(tempArr[i]) > Math.Abs(tempArr[i + 1]))  //перевірка правильно розставленої пари чисел
                    {
                        int temp = tempArr[i];         //через проміжну змінну міняємо значення місцями
                        tempArr[i] = tempArr[i + 1];
                        tempArr[i + 1] = temp;
                    }
                }
                for (int i = 0; i < rows * cols - 1; i++)  //і - індекс масива temp
                    if (Math.Abs(tempArr[i]) <= Math.Abs(tempArr[i + 1]))  //перевірка на правильність розставлених чисел в парі
                        count_true += 1;
            }

            for (int i = 0; i < rows; i++)   //і - індекс рядків матриці
            {
                for (int j = 0; j < cols; j++)  //j - індекс стовпчиків матриці
                    matrix[i, j] = tempArr[i * cols + j];  //заповнення матриці
            }

        }

    }
}
