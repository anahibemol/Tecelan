
namespace Tecelan
{
    public class Cipher
    {
        public static void Open()
        {

            Console.WriteLine();
            Console.WriteLine(@"
                Write what you want to do:

                |1 or SIMPLE     - Simple replacement cipher.
                |2 or REVERSE    - Simple replacement cipher (reverse, used for decription)
                |3 or BACK       - Goes Back to Main Menu.
                |__________________________________________________________________________");

            string EncryptSwitch = Console.ReadLine() ?? "1";

            EncryptSwitch = EncryptSwitch.ToUpper();
            int repetitions = 0;
            switch (EncryptSwitch)
            {
                case "1" or "SIMPLE":
                Console.WriteLine("How many letters do you want to displace");
                repetitions = Convert.ToInt16(Console.ReadLine() ?? "1");
                    First(repetitions);
                    break;
                case "2" or "LAST":
                Console.WriteLine("How many letters do you want to displace");
                repetitions = Convert.ToInt16(Console.ReadLine() ?? "1");
                    Last(repetitions);
                    break;
                case "3" or "BACK":
                    Programa.Main();
                    break;
            }
        }
        public static void First(int k) // Fazer um método próprio para mudar a primeira e as demais vezes
        {
            Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");
            File.WriteAllText(@"./IO/OutCipherSimple.txt", string.Empty);
            string Text = string.Empty;
            string[] lines = System.IO.File.ReadAllLines(@"./IO/Input.txt");
            int i = 0;
            int j = 0;
            foreach (var item in lines) { Text += item; }
            string[] characters =
    {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
         "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            List<string> characterList = new();

            char[] charArray = Text.ToCharArray();
            foreach (char character in charArray)
            {
                characterList.Add(Convert.ToString(charArray[i]));
                string charchar = "";
                charchar = characterList[i];
                foreach (string stringChar in characters)
                {
                    if (j < 55 && charchar == characters[j])
                    {
                        if (charchar == "Z")
                        {
                            Console.Write($"a");
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", $"a");
                        }
                        else
                        {
                            Console.Write(characters[j + 1].ToLower());
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", $"{characters[j + 1].ToLower()}");
                        }
                    }

                    if (j < 55 && charchar == " ")
                    {
                        Console.Write(" "); charchar = "";
                        File.AppendAllText(@"./IO/OutCipherSimple.txt", " ");
                    }
                    j++;
                }
                j = 0;
                characterList[i] = charchar;
                i++;
            }

            if (k > 1)
            {
                File.Copy(@"./IO/OutCipherSimple.txt", @"./IO/CipherOperator.txt", true);
                Forward(k);
            }

            /* To Fix: Find some way to make the away cyclical (so it can cycle endlessly), this is important so the program can
            use different encryption methods
            */
        }

        public static void Forward(int k)
        {
            while (k > 1)
            {
                Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");
                File.WriteAllText(@"./IO/OutCipherSimple.txt", string.Empty);
                string Text = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(@"./IO/CipherOperator.txt");
                int i = 0;
                int j = 0;
                foreach (var item in lines) { Text += item; }
                string[] characters =
        {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
         "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                List<string> characterList = new();

                char[] charArray = Text.ToCharArray();
                foreach (char character in charArray)
                {
                    characterList.Add(Convert.ToString(charArray[i]));
                    string charchar = "";
                    charchar = characterList[i];
                    foreach (string stringChar in characters)
                    {
                        if (j < 55 && charchar == characters[j])
                        {
                            if (charchar == "Z")
                            {
                                Console.Write($"a");
                                File.AppendAllText(@"./IO/OutCipherSimple.txt", $"a");
                            }
                            else
                            {
                                Console.Write(characters[j + 1].ToLower());
                                File.AppendAllText(@"./IO/OutCipherSimple.txt", $"{characters[j + 1].ToLower()}");
                            }
                        }

                        if (j < 55 && charchar == " ") 
                        { 
                            Console.Write(" "); 
                            charchar = ""; 
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", " "); 
                        }
                        j++;
                    }
                    j = 0;
                    characterList[i] = charchar;
                    i++;
                    k--;
                }

            }
        }
    
        public static void Last(int k) // Fazer um método próprio para mudar a primeira e as demais vezes
        {
            Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");
            File.WriteAllText(@"./IO/OutCipherSimple.txt", string.Empty);
            string Text = string.Empty;
            string[] lines = System.IO.File.ReadAllLines(@"./IO/Input.txt");
            int i = 0;
            int j = 0;
            foreach (var item in lines) { Text += item; }
            string[] characters =
    {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
         "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            List<string> characterList = new();

            char[] charArray = Text.ToCharArray();
            foreach (char character in charArray)
            {
                characterList.Add(Convert.ToString(charArray[i]));
                string charchar = "";
                charchar = characterList[i];
                foreach (string stringChar in characters)
                {
                    if (j < 55 && charchar == characters[j])
                    {
                        if (charchar == "a")
                        {
                            Console.Write($"z");
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", $"z");
                        }
                        else
                        {
                            Console.Write(characters[j - 1].ToLower());
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", $"{characters[j - 1].ToLower()}");
                        }
                    }

                    if (j < 55 && charchar == " ")
                    {
                        Console.Write(" "); charchar = "";
                        File.AppendAllText(@"./IO/OutCipherSimple.txt", " ");
                    }
                    j++;
                }
                j = 0;
                characterList[i] = charchar;
                i++;
            }

            if (k > 1)
            {
                File.Copy(@"./IO/OutCipherSimple.txt", @"./IO/CipherOperator.txt", true);
                Backward(k);
            }

            /* To Fix: Find some way to make the away cyclical (so it can cycle endlessly), this is important so the program can
            use different encryption methods
            */
        }

        public static void Backward(int k)
        {
            while (k > 1)
            {
                Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");
                File.WriteAllText(@"./IO/OutCipherSimple.txt", string.Empty);
                string Text = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(@"./IO/CipherOperator.txt");
                int i = 0;
                int j = 0;
                foreach (var item in lines) { Text += item; }
                string[] characters =
        {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
         "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                List<string> characterList = new();

                char[] charArray = Text.ToCharArray();
                foreach (char character in charArray)
                {
                    characterList.Add(Convert.ToString(charArray[i]));
                    string charchar = "";
                    charchar = characterList[i];
                    foreach (string stringChar in characters)
                    {
                        if (j < 55 && charchar == characters[j])
                        {
                            if (charchar == "a")
                            {
                                Console.Write($"z");
                                File.AppendAllText(@"./IO/OutCipherSimple.txt", $"z");
                            }
                            else
                            {
                                Console.Write(characters[j - 1].ToLower());
                                File.AppendAllText(@"./IO/OutCipherSimple.txt", $"{characters[j - 1].ToLower()}");
                            }
                        }

                        if (j < 55 && charchar == " ") 
                        { 
                            Console.Write(" "); 
                            charchar = ""; 
                            File.AppendAllText(@"./IO/OutCipherSimple.txt", " "); 
                        }
                        j++;
                    }
                    j = 0;
                    characterList[i] = charchar;
                    i++;
                    k--;
                }

            }
        }
       
    }
}