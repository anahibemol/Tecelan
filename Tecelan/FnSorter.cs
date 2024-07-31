using System.Text;
using System.Globalization;

namespace Tecelan
{
    class Sorter
    {
        public static void Open()
            {
            List<string> ListSorter()
            {
                int          numTexts = 0;
                string       text     = string.Empty;
                List<string> texts    = new();
                // Keep on reading until we get a valid number
                while (numTexts < 1)
                {
                    Console.Write("How many texts would you like to enter? ");
                    bool unused = Int32.TryParse(Console.ReadLine(), out numTexts); // TryParse to make sure we don't get an exception
                }
                // Keep on reading until we get a valid text, at which point it is added to the list
                // numTexts is only decremented if we were able to successfully add the text to the list
                do
                {
                    Console.Write($"({numTexts} texts remaining) Enter a text: ");
                    text = Console.ReadLine() ?? string.Empty;
                    Programa.Extra.ClearLine(1); //the number here says how many lines are cleared
                    if (text == string.Empty) continue;
                    texts.Add(text);
                    numTexts--;
                } while (numTexts > 0 && text != string.Empty);
                texts.Sort();
                return texts;
            }
                List<string> texts = ListSorter();
                Console.WriteLine(string.Join(" \n", texts));
                Console.ReadKey();    
            }

    }
}