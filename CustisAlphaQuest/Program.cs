using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustisAlphaQuest
{
    class Program
    {
        /// <summary>
        /// Словарь для связи символа и массива значений
        /// </summary>
        static Dictionary<char, int> ConvertDict = new Dictionary<char, int>();

        /// <summary>
        /// Количество уникальных символов в выражении
        /// </summary>
        static int UnicCharCount = 0;

        /// <summary>
        /// Список всех слагаемых
        /// </summary>
        static List<string> AllIntegers = new List<string>();

        static int[] AllCharsValue;

        static void Main(string[] args)
        {
            // Входная строка
            string InputString = "ABCDE+FGHIJ-KLMNO+PQRST-VWXYZ=0";

            // Текущий символ
            string CurString ="" + InputString[0];

            AddCharToDict(InputString[0]); // добавление первого символа в словарь

            // Смотрим строку и заполняем словарь уникальных символов и список слагаемых
            for (int i=1; i<InputString.Length; i++)
            {
                if(IsSign(InputString[i]))
                {
                    AllIntegers.Add(CurString);
                    CurString = "" + InputString[i];
                }
                else
                {
                    AddCharToDict(InputString[i]);
                    CurString += InputString[i];
                }
            }
            //AllIntegers.Add(CurString); // добавление последнего слагаемого в список

            AllCharsValue = new int[UnicCharCount]; // создние списка значений для всех символов


            Random Rnd = new Random();
            for (int i=0; i<UnicCharCount; i++)
            {
                AllCharsValue[i] = Rnd.Next(0, 10);
            }

            foreach (string CurInt in AllIntegers)
            {
                Console.WriteLine("{0} - {1}", CurInt, ConvertStringToInteger(CurInt));
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Определение, является ли  символ знаком...
        /// </summary>
        /// <param name="Char">Символ</param>
        /// <returns></returns>
        static bool IsSign(char Char)
        {
            if ( Char=='-' || Char=='+' || Char == '=') { return true; }
            else { return false; }
        }

        static void AddCharToDict(char Simbol)
        {
            if (!IsSign( Simbol))
            {
                if (!ConvertDict.ContainsKey(Simbol))
                {
                    ConvertDict.Add(Simbol, UnicCharCount);
                    UnicCharCount++;
                }
            }
        }
        
        static int ConvertStringToInteger(string Number)
        {
            string ConvertString = "";
            foreach (char CurChar in Number)
            {
                if(IsSign(CurChar)) { ConvertString += CurChar; }
                else { ConvertString += AllCharsValue[ConvertDict[CurChar]]; }
            }
            return Convert.ToInt32(ConvertString);
        }
    }
}
