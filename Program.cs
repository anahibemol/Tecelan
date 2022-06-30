// See https://aka.ms/new-console-template for more information
using static System.Int32;

namespace Tecelan
{
    public static class Programa
    {

        public static void Main(string[] args)
        {
            Console.WriteLine(@"WHICH FUNCTION OF THE ANALYZER DO YOU WANT TO USE
            1-Get statistics of a given text (e.g. Length)
            2-Verify if two texts are the same
            3-Sort several texts in alphabetical order");  
            string OpeningMenu = Console.ReadLine() ?? "1";    
            switch (OpeningMenu)
            {
            case "1":
            SoisTask.Statistics();
            break;
            case "2":
            SoisTask.Identity();
            break;
            case "3":
            SoisTask.Sorter();
            break;
            } 
        }

        public static class SoisTask
        {
            public static void Statistics()
            {
                Console.WriteLine("Write the text to be analyzed");    
                string? Text = @"";
                Text = Console.ReadLine();
                if (Text is not null)
            {
                Console.WriteLine($"For the text:");
                Console.WriteLine(Text);
                int tLength = Text.Length;
                int tLengthSpaceless = Text.Count(c => !Char.IsWhiteSpace(c)); 
                Console.WriteLine($"The text has {tLength} characters ({tLengthSpaceless} if you dont count the spaces)"); 
                var results = Text.Split(' ').Where(x => x.Length > 3)
                                        .GroupBy(x => x)
                                        .Select(x => new { Count = x.Count(), Word = x.Key })
                                        .OrderByDescending(x => x.Count);  
            foreach (var item in results)
                Console.WriteLine(String.Format("the word {0} occured {1} times", item.Word, item.Count));
            }
            }  
            public static void Identity() 
            {
                Console.WriteLine("This program checks if two texts of any length are the same, please write your first"); 
                string? Text1 = "";
                Text1 = Console.ReadLine();    
                Console.WriteLine("Then the second");  
                string? Text2 = "";
                Text2 = Console.ReadLine();    
                int Identity = String.Compare(Text1, Text2); //compares if the two lines are the same, if they are, Identity == 0  
                if (Identity == 0) 
                Console.WriteLine("The Two Texts are Equal");  
                else 
                Console.WriteLine("The Two Texts are Different");
            }  
            public static void Sorter()
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
                    bool unused = TryParse(Console.ReadLine(), out numTexts); // TryParse to make sure we don't get an exception
                }
                // Keep on reading until we get a valid text, at which point it is added to the list
                // numTexts is only decremented if we were able to successfully add the text to the list
                do
                {
                    Console.Write($"({numTexts} texts remaining) Enter a text: ");
                    text = Console.ReadLine() ?? string.Empty;
                    ClearLine(1); //the number here says how many lines are cleared
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
         //Below are some utility functions used in various programs to shorten code.
         public static void ClearLine(int pedro)
         {
             Console.SetCursorPosition(0, Console.CursorTop - pedro);
             Console.Write(new string(' ', Console.WindowWidth));
             Console.SetCursorPosition(0, Console.CursorTop);
         }        
         
    }

}

