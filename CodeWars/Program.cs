using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CodeWars
{
    public class Kata
    {
        public static int CountSheeps(bool[] sheeps)
        {
            return sheeps.Count(a => a);
        }

        public static int FindShort(string s)
        {
            return s.Split(' ').OrderBy(a => a.Length).FirstOrDefault().Length;
        }

        public static string playPass(string s, int n)
        {
            if (s.Length == 0)
                return "";

            char[] result = new char[s.Length];
            var counter = 0;

            foreach (var c in s)
            {
                char val = c;

                if (val >= '0' && val <= '9')
                {
                    int d = val - 48;
                    d = 9 - d;
                    val = (char)(d + 48);
                }

                if (val >= 'A' && val <= 'Z')
                {
                    val = (char)(val + n);

                    if (val > 'Z')
                    {
                        val = (char)(val - 26);
                    }

                    if ((counter % 2) != 0)
                    {
                        val = (char)(val + 32);
                    }
                }

                result[s.Length - 1 - counter] = val;

                counter++;
            }

            return new string(result);
        }

        //Sum of Digits / Digital Root
        public static int DigitalRoot(long n)
        {
            int sum = 0;

            if (n > 9)
            {
                do
                {
                    sum += (int)(n % 10);
                    n = n / 10;
                }
                while (n != 0);
            }
            else
                return (int)n;

            sum = DigitalRoot(sum);

            return sum;

        }

        public static string[] TowerBuilder(int nFloors)
        {
            string[] towers = new string[nFloors];
            var str_size = 2 * nFloors - 1;

            for (int f = 0; f < nFloors; f++)
            {
                var stars = f * 2 + 1;
                var offset = (str_size - stars) / 2;

                for (int p = 0; p < str_size; p++)
                {
                    if (p < offset || p >= (offset + stars))
                        towers[f] += ' ';
                    else
                        towers[f] += '*';
                }
            }

            return towers;
        }

        public static int[] distinct(int[] a)
        {
            return a.Distinct().ToArray();
        }

        public static string ToCamelCase(string str)
        {
            var result = str;

            var r = String.Join("", str.Split(new Char[] { '-', '_' }));

            if (char.IsUpper(str[0]))
            {
            }
            else
            {

            }

            return str;
        }

        public static string PigIt(string str)
        {
            var result = str.Split(' ');
            var str_end = "ay";

            for (int i = 0; i < result.Length; i++)
            {
                var item = result[i];
                char first = item[0];

                item = item.Remove(0, 1);
                item += first;
                item += str_end;

                result[i] = item;
            }
            return String.Join(" ", result);
        }

        public static int CountBits(int n)
        {
            int count = 0;
            while (n != 0)
            {
                if ((n & 0x01) == 1)
                    count++;
                n >>= 1;

            }
            return count;
        }

        public static int HighestRank(int[] arr)
        {
            return arr.GroupBy(x => x).Select(x => new { value = x.Key, count = x.Count() }).OrderByDescending(x => x.count).ThenByDescending(x => x.value).FirstOrDefault().value;
        }

        public static string GetMorseCode(string code)
        {
            if (code == "") return "";

            Dictionary<char, String> morseCode = new Dictionary<char, String>()
            {
                {'A' , ".-"},{'B' , "-..."},{'C' , "-.-."}, //alpha
                {'D' , "-.."},{'E' , "."},{'F' , "..-."},
                {'G' , "--."},{'H' , "...."},{'I' , ".."},
                {'J' , ".---"},{'K' , "-.-"},{'L' , ".-.."},
                {'M' , "--"},{'N' , "-."},{'O' , "---"},
                {'P' , ".--."},{'Q' , "--.-"},{'R' , ".-."},
                {'S' , ".-."},{'T' , "-"},{'U' , "..-"},
                {'V' , "...-"},{'W' , ".--"},{'X' , "-..-"},
                {'Y' , "-.--"},{'Z' , "--.."},
                //Numbers 
                {'0' , "-----"},{'1' , ".----"},{'2' , "..----"},{'3' , "...--"},
                {'4' , "....-"},{'5' , "....."},{'6' , "-...."},{'7' , "--..."},
                {'8' , "---.."},{'9' , "----."},
            };

            return morseCode.Single(c => c.Value == code).Key.ToString();
        }

        public static string sumStrings(string a, string b)
        {
            a = String.Join("", a.Reverse().ToArray());
            b = String.Join("", b.Reverse().ToArray());

            var result = String.Empty;

            var a_len = a.Length;
            var b_len = b.Length;

            var length = a_len > b_len ? a_len : b_len;

            int a_val = 0, b_val = 0, rest = 0, sum = 0;

            for (int i = 0; i < length; i++)
            {
                if (i < a_len)
                {
                    int.TryParse(a[i].ToString(), out a_val);
                }
                else
                {
                    a_val = 0;
                }

                if (i < b_len)
                {
                    int.TryParse(b[i].ToString(), out b_val);
                }
                else
                {
                    b_val = 0;
                }

                sum = rest + a_val + b_val;

                if (sum >= 10)
                {
                    rest = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    rest = 0;
                }

                if (!(i == length - 1 && sum == 0))
                    result += sum;
            }

            if (rest > 0)
            {
                result += rest;
            }

            return string.Join("", result.Reverse().ToArray());
        }

        static void Main(string[] args)
        {
            Console.WriteLine(OkkOokOo("Ok, Ook, Ooo!"));
            Console.ReadKey();
        }

        private static string OkkOokOo(string okkOookk)
        {
            okkOookk = okkOookk.ToLower().Replace(", ", String.Empty)
                .Replace("!", String.Empty)
                .Replace("?", String.Empty)
                .Replace("k", "1")
                .Replace("o", "0");

            var value = Convert.ToInt32(okkOookk, 2);

            return new string((char)value,1);
        }
    }
}