// See https://aka.ms/new-console-template for more information
using System;


//Class för att hantera svårighetsgrader via switch-case
class Difficulty
{
    //konsruktor för att skapa olika svårighetsgrader
    public int Min { get; set; }
    public int Max { get; set; }
    public int Attempts { get; set; }

    public Difficulty(int min, int max, int attempts)
    {
        Min = min;
        Max = max;
        Attempts = attempts;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Välj svårighetsgrad: 1 = Lätt, 2 = Medium, 3 = Svår");
        string choice = Console.ReadLine();


        //variabel av klassen Difficulty
        Difficulty difficulty;


        //difficuly sätts beroende på användarens val i detta switch-case
        switch (choice)
        {
            case "1":
                difficulty = new Difficulty(1, 20, 5);
                break;
            case "2":
                difficulty = new Difficulty(1, 50, 5);
                break;
            case "3":
                difficulty = new Difficulty(1, 100, 5);
                break;
            default:
                difficulty = new Difficulty(1, 20, 5);
                break;
        }

        //Startar spelet med vald svårighetsgrad
        PlayGame(difficulty);
    }

    static void PlayAgain()
    {
        Console.WriteLine("Vill du spela igen? (j/n)");
        string playAgain = Console.ReadLine().ToLower();
        if (playAgain == "j")
        {
            Main();
        }
        else
        {
            Console.WriteLine("Tack för att du spelade!");
        }
    }

    static void PlayGame(Difficulty difficulty)
    {
        //tar fram ett slumpmässigt nummer inom vald svårighetsgrad
        Random random = new Random();
        int numberToGuess = random.Next(difficulty.Min, difficulty.Max + 1);
        bool guessedRight = false;

        //write line som visar användaren intervallet och antal försök
        Console.WriteLine($"Jag tänker på ett nummer mellan {difficulty.Min} och {difficulty.Max}. Du har {difficulty.Attempts} försök!");

        //loopar genom antal försök
        for (int i = 1; i <= difficulty.Attempts; i++)
        {
            Console.Write($"Försök {i}: ");
            //parsar användarens gissning till int för att kunna jämföra med numberToGuess och beräkna diff
            int guess = int.Parse(Console.ReadLine());

            int diff = Math.Abs(guess - numberToGuess);

            if (diff <= 5)
            {
                Console.WriteLine("Varmt!");
            }
            else if (diff >= 10)
            {
                Console.WriteLine("Kallt!");
            }

            if (guess < numberToGuess)
                Console.WriteLine("För lågt!");
            else if (guess > numberToGuess)
                Console.WriteLine("För högt!");
            else
            {
                Console.WriteLine("Grattis! Du gissade rätt!");
                guessedRight = true;
                PlayAgain();

                break;
            }
        }

        if (!guessedRight)
        {
            Console.WriteLine($"Tyvärr! Rätt svar var {numberToGuess}.");
            PlayAgain();
        }
    }
}
