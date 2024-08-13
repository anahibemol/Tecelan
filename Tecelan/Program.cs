// See https://aka.ms/new-console-template for more information
using System;
using System.Text;
using System.Globalization;

using static System.Int32;


namespace Tecelan
{
    public static class Programa
    {

        public static class SoisTask
        {

        }  

        public static void Main()
        {
            bool whiler = true;
            while (whiler == true)
            {

                Console.WriteLine(@"
                Write the following commands for what you want to do:

                |1 or STATS    - Get statistics of a given text (e.g. Length).
                |2 or IDENTITY - Verify if two texts are the same.
                |3 or SORT     - Sort several texts in alphabetical order.
                |4 or ENCODE   - Encodes and/or Decodes Text.
                |5 or CIPHER   - Encrypts and/or Decrypts Text.
                |6 or EXIT     - Exits the Program.
                |_______________________________________________________");
                string OpeningMenu = Console.ReadLine() ?? "0";
                OpeningMenu = OpeningMenu.ToUpper();
                switch (OpeningMenu)
                {
                case "STATS" or "1":
                    Statistics.Open();
                break;
                case "IDENTITY" or "2":
                    Identity.Open();
                break;
                case "SORT" or "3":
                    Sorter.Open();
                break;
                case "ENCODE" or "4":
                    Encoder.Open();
                break;
                case "CIPHER" or "5":
                    Cipher.Open();
                break;
                case "EXIT" or "6":
                    whiler = false;
                break;
                }

            }
        }

        public static class Extra
        {
                   public static void ClearLine(int pedro)
            {

                Console.SetCursorPosition(0, Console.CursorTop - pedro);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.CursorTop);

            }   
        }
     
 }

}

