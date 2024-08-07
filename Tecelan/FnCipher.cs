
namespace Tecelan
{
    public class Cipher
    {
        public static void Open()
        {
                Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");    
                string Text = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(@"./Input.txt");
                int i = 0;
                int j = 0;
                int k = 0;
                    foreach (var item in lines) { Text += item; }
                string[] characters = 
        {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", 
         "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                List<string> characterList    = new();
                
                char[] charArray = Text.ToCharArray();
                    foreach (char character in charArray)
                    {
                         characterList.Add(Convert.ToString(charArray[i]));
                         string charchar = "";
                         charchar = characterList[i];
                            foreach (string stringChar in characters)
                            {
                                if (j <55 && charchar == characters[j] && charchar != "Z") { Console.Write(characters[j+1].ToLower()); }
                                if (j <55 && charchar == characters[j] && charchar == "Z") {Console.Write($"{characters[0+k]}"); }

                                if (j <55 && charchar == " ") { Console.Write(" "); charchar = ""; }
                                j++;
                            }
                        j=0;
                        characterList[i] = charchar;
                         i++;
                    }
                /* To Fix: Find some way to make the away cyclical (so it can cycle endlessly), this is important so the program can
                use different encryption methods
                */
        }
    }
}