using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        string sign = "";


        if ( percent >= 90)
        {
            letter = "A";
        }

        else if (percent >=80)
        {
            letter = "B";
        }
        else if (percent >=70)
        {
            letter = "C";
        }
        else if (percent >=60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"Your grade is: {letter}");
        
        if (percent >=70)
        {
            Console.WriteLine("You passed!");
        }

        else
        {
            Console.WriteLine("Better luck next time!");
     
        }
        if (letter !="F")
        {
            int lastDigit = percent % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }

            else if (lastDigit < 3)
            {
                sign = "-";
            }

            if (letter == "A" && sign == "+")
            {
                sign = "";
            }

            else 
            {
                sign = "";
            }

            Console.WriteLine($"Your final grade is: {letter}{sign}");


        }
    }
}