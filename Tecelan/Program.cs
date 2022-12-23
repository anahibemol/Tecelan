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
            public static void Statistics()
            {
                Console.WriteLine("Write the text on the file 'Input.txt' on the Tecelan Folder");    
                string Text = string.Empty;
                string[] lines = System.IO.File.ReadAllLines(@"./Input.txt");

                foreach (var item in lines)
                    {
                        Text += item;
                    }

                if (Text == "ERROR") {Console.WriteLine("Please Write a Valid Text");}
                else
                {              
                 Console.WriteLine($"For the text:");
                 Console.WriteLine(Text);
                 int tLength = Text.Length;
                 int tLengthSpaceless = Text.Count(c => !Char.IsWhiteSpace(c));             
                 Console.WriteLine($"The text has {tLength} characters ({tLengthSpaceless} if you dont count the spaces)"); 
                 var results = Text.Split(' ').Where(x => x.Length > 3)
                 /**/              .GroupBy(x => x)
                 /**/              .Select(x => new { Count = x.Count(), Word = x.Key })
                 /**/              .OrderByDescending(x => x.Count);  
                 foreach (var item in results)
                     { Console.WriteLine(String.Format($"the word {item.Word} occured {item.Count} times")); }
                }

            }  

            public static void Identity() 
            {
                Console.WriteLine("This program checks if two texts of any length are the same, please write your first"); 
                string Text1 = Console.ReadLine() ?? "ERROR";  
                Console.WriteLine("Then the second");  
                string Text2 = Console.ReadLine() ?? "ERROR";

                if (Text1 != "ERROR" && Text2 != "ERROR")
                { 

                    //compares if the two lines are the same, if they are, Identity == 0  
                    int Identity = String.Compare(Text1, Text2); 
                    if (Identity == 0) 
                    { Console.WriteLine("The Two Texts are Equal"); }  
                    else 
                    { Console.WriteLine("The Two Texts are Different"); }

                }
                else if (Text1 == "ERROR" && Text2 != "ERROR") { Console.WriteLine("Invalid 1st Text"); }
                else if (Text1 != "ERROR" && Text2 == "ERROR") { Console.WriteLine("Invalid 2nd Text"); }
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
                    Extra.ClearLine(1); //the number here says how many lines are cleared
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

            public static void Encoding()
            {

                Console.WriteLine();
                Console.WriteLine(@"
                Write what you want to do:

                |1 or ENCODE    - Encodes regular text to other encodings.
                |2 or DECODE    - Decodes encoded text. (Still in Development)
                |_________________________________________________________");

                string EncodeSwitch = Console.ReadLine() ?? "1";
                
                EncodeSwitch = EncodeSwitch.ToUpper();

                Console.WriteLine("Write your Text");
                string Text = Console.ReadLine() ?? "ERROR";

                void S_Encoder()
                {

                Console.WriteLine(@"
                Your text is in UTF-16 by Default
                
                Write the format you want your text to be encoded into:

                |1 or ASCII    - Encodes your Text to ASCII.
                |2 or UTF-8    - Encodes your Text to UTF-8.
                |3 or UTF-16   - Encodes your Text to UTF-16.
                |4 or NORMAL   - Removes Accents/Diacritics from the text.
                |_______________________________________________________");

                string Format = Console.ReadLine() ?? "UTF-16";
                Format.ToUpper();
                
                string NormalizedText = Extra.Normalizer(Text);

                if (Text != "ERROR" && (Format.ToUpper() == "ASCII" ^ Format == "1"))
                {

                    Extra.ANSIIEncoder(Text, false);
                    Extra.ANSIIEncoder(NormalizedText, true);

                }


                if (Text != "ERROR" && (Format.ToUpper() == "UTF-8" ^ Format == "2"))
                {
                    Extra.UTF8Encoder(Text, true);
                }         

                if (Text != "ERROR" && (Format.ToUpper() == "UTF-16" ^ Format == "3"))
                {
                    Console.WriteLine("Your text is already in UTF-16");

                    Console.WriteLine(@$"Your Text:
                    {Text}");
                } 
                else {Console.WriteLine("Write a Valid Text/Format"); }

                if (Text != "ERROR" && (Format == "NORMAL" ^ Format == "4"))
                {
                    Console.WriteLine("Regular Text:");

                    Console.WriteLine(Text);

                    Console.WriteLine("Normalized Tex:");

                    Console.WriteLine(NormalizedText);
                }
                else {Console.WriteLine("Write a Valid Text/Format"); }
                }

                void S_Decoder()
                {

                Console.WriteLine(@"
                Your text is in UTF-16 by Default
                
                Write the format you want your text to be encoded into:

                |1 or ASCII    - Encodes your Text to ASCII.
                |2 or UTF-8    - Encodes your Text to UTF-8.
                |3 or UTF-16   - Encodes your Text to UTF-16.
                |4 or NORMAL   - Removes Accents/Diacritics from the text.
                |_______________________________________________________");

                string Format = Console.ReadLine() ?? "UTF-16";
                Format.ToUpper();
                
                string NormalizedText = Extra.Normalizer(Text);
                if (Text != "ERROR" && (Format.ToUpper() == "ASCII" ^ Format == "2"))
                {
                    Extra.UTF8Decoder(Text, true);
                }
                }

            switch(EncodeSwitch)
            {
                case "1":
                S_Encoder();
                break;
                case "2":
                S_Decoder();
                break;
                case "ENCODE":
                S_Encoder();
                break;
                case "DECODE":
                S_Decoder();
                break;             
            }
            
            }
    
        }  

        public static void Main(string[] args)
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
                |5 or EXIT     - Exits the Program.
                |_______________________________________________________");
                string OpeningMenu = Console.ReadLine() ?? "1";
                OpeningMenu = OpeningMenu.ToUpper();
                //If you want to change the name of a command, you need to change both in the If and the Switch
                if (OpeningMenu == "1") { OpeningMenu = "STATS";    } 
                if (OpeningMenu == "2") { OpeningMenu = "IDENTITY"; }
                if (OpeningMenu == "3") { OpeningMenu = "SORT";     }
                if (OpeningMenu == "4") { OpeningMenu = "ENCODE";  }
                if (OpeningMenu == "5") { OpeningMenu = "EXIT";     }
                switch (OpeningMenu)
                {
                case "STATS":
                    SoisTask.Statistics();
                break;
                case "IDENTITY":
                    SoisTask.Identity();
                break;
                case "SORT":
                    SoisTask.Sorter();
                break;
                case "ENCODE":
                    SoisTask.Encoding();
                break;
                case "EXIT":
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

            public static void ANSIIEncoder(string Text, bool Normalized)
            {

                    string unicodeString = $"This string contains the unicode character {Text}";

                     // Create two different encodings.
                    Encoding Ascii   = Encoding.ASCII;
                    Encoding Unicode = Encoding.Unicode;

                    

                    // Convert the string into a byte array.
                    byte[] unicodeBytes = Unicode.GetBytes(unicodeString);

                    // Perform the conversion from one encoding to the other.
                    byte[] asciiBytes = Encoding.Convert(Unicode, Ascii, unicodeBytes);

                    // Convert the new byte[] into a char[] and then into a string.
                    char[] asciiChars = new char[Ascii.GetCharCount(asciiBytes, 0, asciiBytes.Length)];
                    Ascii.GetChars(asciiBytes, 0, asciiBytes.Length, asciiChars, 0);
                    string asciiString = new string(asciiChars);

                    if (Normalized == false)
                    {
                    Console.WriteLine($"|UTF-8 string:              {unicodeString}");
                    Console.WriteLine($"|ASCII string:              {asciiString}");
                    }
                    Console.WriteLine("|");
                    if (Normalized == true)
                    {
                    Console.WriteLine($"|UTF-8 string (normalized): {unicodeString}");
                    Console.WriteLine($"|ASCII string (normalized): {asciiString}");
                    }




            }

            public static void UTF8Encoder(string Text, bool Normalized)
            {
                // Create a UTF-8 encoding.
                UTF8Encoding utf8 = new UTF8Encoding();
                
                // A Unicode string with two characters outside an 8-bit code range.
                String unicodeString = Text;
                Console.WriteLine("Original string:");
                Console.WriteLine(unicodeString);

                // Encode the string.
                Byte[] encodedBytes = utf8.GetBytes(unicodeString);
                Console.WriteLine();
                Console.WriteLine("Encoded bytes:");
                for (int ctr = 0; ctr < encodedBytes.Length; ctr++) {
                    Console.Write(@"\x{0:X2} ", encodedBytes[ctr]);
                    if ((ctr + 1) %  25 == 0)
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Encoded bytes (no spaces):");
                for (int ctr = 0; ctr < encodedBytes.Length; ctr++) {
                    Console.Write(@"\x{0:X2}", encodedBytes[ctr]);
                    if ((ctr + 1) %  25 == 0)
                    Console.WriteLine();
                }                
                Console.WriteLine();
                
                // Decode bytes back to string.
                String decodedString = utf8.GetString(encodedBytes);
                Console.WriteLine();
                Console.WriteLine("Decoded bytes:");
                Console.WriteLine(decodedString);
            }

            public static void UTF8Decoder(string Text, bool Normalized)
            {
                Encoding utf8 = new UTF8Encoding();
                byte[] bytes = Text.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

                { Console.WriteLine("Mama Mia:"); Console.WriteLine(bytes[0]); }
                String decodedString = utf8.GetString(bytes);
                Console.WriteLine();
                Console.WriteLine("Decoded Text:");
                Console.WriteLine(decodedString);}
            
            public static void UTF8DecoderE(string Text, bool Normalized)
            {
             

                Encoding utf8 = new UTF8Encoding();
             
                Console.WriteLine($"Encoded Text = {Text}");

                Text = Text.Replace(@"\"," ");
                Text = Text.Replace(@"x","°");


                List<char> charsToRemove = new List<char>() {'°'};
                

                  string Filter(string str, List<char> charsToRemove)
                {
                    return String.Concat(Text.Split(charsToRemove.ToArray()));
                }

                 Text = Filter(Text, charsToRemove);

                Console.WriteLine(Text);

                try{byte[] bytes = Text.Split(' ').Select(s => Convert.ToByte(s, 16)).ToArray();

                { Console.WriteLine("Mama Mia:"); Console.WriteLine(bytes[1]); }
                String decodedString = utf8.GetString(bytes);
                Console.WriteLine();
                Console.WriteLine("Decoded Text:");
                Console.WriteLine(decodedString);}
                catch{Console.WriteLine("Faio"); }    
                           
            }

            public static string Normalizer(string Text)
            {

                var normalizedString = Text.Normalize(NormalizationForm.FormD);
                var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

                for (int i = 0; i < normalizedString.Length; i++)
                {
                    char c = normalizedString[i];
                    var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                    if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    {
                        stringBuilder.Append(c);
                    }
                }

                return stringBuilder
                    .ToString()
                    .Normalize(NormalizationForm.FormC);

                        }
        
        }
     
 }

}

