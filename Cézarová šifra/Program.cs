using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cézarová_šifra
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "Hello World!"; /*"ABCDEFGHIJKLMNOPQRSTUVWXYZ";"AÁÄBCČDĎDZDŽEÉFGHCHIÍJKLĹĽMNŇOÓÔPQRŔSŠTŤUÚVWXYÝZŽ"*/
            int key = 25;

            string encrypted = CesaroveKodovanie(test, key);
            string decrypted = CesaroveDekodovanie(encrypted, key);

            //Console.WriteLine("Hello World!");
            Console.WriteLine("Original: {0}"+Environment.NewLine+
                              "Kľúč: {1}"+ Environment.NewLine +
                              "Zakódované: {2}"+Environment.NewLine +
                              "Odkódované: {3}" , test.ToUpper(), key,encrypted,decrypted);

        }


        static string CesaroveKodovanie(string text, int key)
        {
            if (key > 25 || key < -25)
            {
                throw new ArgumentOutOfRangeException("key");
            }

            text = text.ToUpper();
            string newText = "";
            char[] abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach(char c in text)
            {
                if (abeceda.Contains(c))
                {
                    int newPosition = Array.IndexOf(abeceda, c) + key;

                    if (newPosition >= abeceda.Count())
                        newPosition = newPosition - abeceda.Count();
                    if (newPosition <= -1)
                        newPosition = abeceda.Count() + newPosition;

                    newText += abeceda[newPosition];
                }
                else
                {
                    newText += c;
                }
            }

            return newText;
        }

        static string CesaroveDekodovanie(string text, int key)
        {
            if (key >25 || key < -25)
            {
                throw new ArgumentOutOfRangeException("key");
            }

            text = text.ToUpper();
            string newText = "";
            char[] abeceda = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            foreach (char c in text)
            {
                if (abeceda.Contains(c))
                {
                    int newPosition = Array.IndexOf(abeceda, c) - key;

                    if (newPosition >= abeceda.Count())
                        newPosition = newPosition - abeceda.Count();
                    if (newPosition <= -1)
                        newPosition = abeceda.Count() + newPosition;

                    newText += abeceda[newPosition];
                }
                else
                {
                    newText += c;
                }
            }

            return newText;
        }


    }
}
