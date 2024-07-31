namespace Tecelan
{
    class Identity
    {
                    public static void Open() 
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

    }
}