using System.Text;
using System.Globalization;

using static System.Int32;

namespace Tecelan
{
    public class Encoder
    {
            public static void Open()
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
                
                string NormalizedText = Normalizer(Text);

                if (Text != "ERROR" && (Format.ToUpper() == "ASCII" ^ Format == "1"))
                {

                    ANSIIEncoder(Text, false);
                    ANSIIEncoder(NormalizedText, true);

                }


                if (Text != "ERROR" && (Format.ToUpper() == "UTF-8" ^ Format == "2"))
                {
                    UTF8Encoder(Text, true);
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
                
                string NormalizedText = Normalizer(Text);
                if (Text != "ERROR" && (Format.ToUpper() == "ASCII" ^ Format == "2"))
                {
                    UTF8Decoder(Text, true);
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