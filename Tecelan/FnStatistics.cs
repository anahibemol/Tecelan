namespace Tecelan
{
    public static class Statistics
    {
            public static void Open()
            {
                Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");    
                string Text = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(@"./Input.txt");

                foreach (var item in lines) { Text += item; }

                if (Text == "ERROR") {Console.WriteLine("Please Write a Valid Text");}
                else
                {              
                 Console.WriteLine($"For the text:");
                 Console.WriteLine(Text);
                 int tLength = Text.Length;
                 int tLengthSpaceless = Text.Count(c => !Char.IsWhiteSpace(c));             
                 Console.WriteLine($"The text has {tLength} characters ({tLengthSpaceless} without spaces)"); 
                 var results = Text.Split(' ').Where(x => x.Length > 3)
                 /**/              .GroupBy(x => x)
                 /**/              .Select(x => new { Count = x.Count(), Word = x.Key })
                 /**/              .OrderByDescending(x => x.Count);  
                 foreach (var item in results)
                     { Console.WriteLine(String.Format($"the word {item.Word} occured {item.Count} times")); }
                }

            }  
    
    }
}