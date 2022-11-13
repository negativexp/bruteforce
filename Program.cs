using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace bruteforce
{
    internal class Program
    {
        static int maximumLenght = 8;
        static int minimumLenght = 0;
        //95
        static int[] allCharNumbers = new int[200];
        static string[] settings = { "Maximum Lenght : " + maximumLenght,
                                  "Minimum Lenght : " + minimumLenght,
                                  "Change Characters", "START"};


        static void Main(string[] args)
        {
            GetAllCharNumbers();
            DisplayMainMenu();
            DisplaySettingsMenu();
        }

        private static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            CenterText("[ BrutelyOPENED - negativexp] ");
            Console.WriteLine("");
            Console.WriteLine("");
            CenterTextLine(" - READ - ");
            Console.WriteLine("");
            CenterText("I'm simply not responsible for anything :)");
            CenterText("Use at your own risk, thanks");
            Console.WriteLine("");
            CenterText("You move by using arrows and enter to change");
        }

        private static void DisplaySettingsMenu()
        {
            int position = 0;
            while (true)
            {
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                CenterTextLine(" - Settings - ");
                Console.WriteLine("");

                for (int i = 0; i < settings.Length; i++)
                {
                    if (position == i)
                    {
                        TextBlankEnd("     [x] " + settings[i]);
                        //Console.WriteLine("     [x] " + settings[i] + new String(' ', 5));
                    }
                    else
                    {
                        TextBlankEnd("     [ ] " + settings[i]);
                        //Console.WriteLine("     [ ] " + settings[i] + new String(' ', 5));
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    if(position != settings.Length - 2 && position != settings.Length - 1)
                    {
                        Console.CursorTop -= settings.Length - position;
                        Console.CursorLeft +=  9 + settings[position].Length - 1;
                        string newValue = Console.ReadLine();
                        if(newValue != "")
                        {
                            if (position == 0)
                                maximumLenght = int.Parse(newValue);
                            if (position == 1)
                                minimumLenght = int.Parse(newValue);
                        }
                    }

                    if (position == settings.Length - 1)
                    {
                        Start(x, y);
                    }
                    if (position == settings.Length - 2)
                    {
                        ChangeCharacters(x, y);
                        Console.SetCursorPosition(x, y+settings.Length+2);
                        for(int i = 0; i < allCharNumbers.Length; i++)
                        {
                            Console.WriteLine(new String(' ', Console.WindowWidth));
                        }

                    }
                }

                if (key.Key == ConsoleKey.DownArrow && position != settings.Length-1)
                {
                    position++;
                }
                if (key.Key == ConsoleKey.UpArrow && position != 0)
                {
                    position--;
                }
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(x, y);
            }
        }

        private static void Start(int x, int y)
        {

            Console.SetCursorPosition(x, y);
            CenterTextLine(" - STARTING - ");
            int x2 = Console.CursorLeft;
            int y2 = Console.CursorTop;
            for(int i = 0; i < settings.Length + 1; i++)
            {
                TextBlankEnd("");
            }
            Console.SetCursorPosition(x2, y2);
            Console.WriteLine("");    
            
            Console.ReadKey();
        }

        private static void ChangeCharacters(int x, int y)
        {

            while (true)
            {
                int amountOfBlanks = 0;

                Console.SetCursorPosition(x, y);
                CenterTextLine(" - Characters - ");
                Console.WriteLine("");

                foreach (int i in allCharNumbers)
                {
                    if (i != 0)
                    {
                        if (i < 100)
                        {
                            TextBlankEnd("     " + "[" + i + "  -> " + (char)i +" ]");
                            //Console.WriteLine("     " + "[" + i + "  -> " + (char)i +" ]" + new String(' ', 20));
                        }
                        else
                        {
                            TextBlankEnd("     " + "[" + i + " -> " + (char)i + " ]");
                            //Console.WriteLine("     " + "[" + i + " -> " + (char)i + " ]" + new String(' ', 20));
                        }
                    }
                    else
                    {
                        amountOfBlanks++;
                    }
                }

                Console.WriteLine("");

                CenterTextLine(" - info - ");
                Console.WriteLine("");
                CenterText("To add type 'add (number of character)'");
                CenterText("To remove a character type 'remove (number of character)'");
                CenterText("To reset the character set type 'reset'");
                Console.WriteLine("");
                CenterText("Press enter to go back");
                Console.WriteLine("");
                CenterTextLine("");
                Console.WriteLine("");
                Console.Write("input: ");
                string commandInput = Console.ReadLine();
                if (commandInput == "")
                {
                    break;
                }
                if (commandInput.Contains("add"))
                {
                    int charNumber = int.Parse(Regex.Match(commandInput, @"\d+").Value);
                    allCharNumbers[allCharNumbers.Length - 1 - amountOfBlanks + 1] = charNumber;

                }
                if(commandInput.Contains("remove"))
                {
                    int charNumber = int.Parse(Regex.Match(commandInput, @"\d+").Value);
                    allCharNumbers = allCharNumbers.Where(e => e != charNumber).ToArray();
                }
                if(commandInput == "reset")
                {
                    GetAllCharNumbers();
                }
                Console.SetCursorPosition(x, y);
            }

        }

        private static void TextWithTime(string s)
        {
            Console.WriteLine("     " + "[" + DateTime.Now.ToString("h:mm:ss") + "] " + s);
        }

        private static void TextBlankEnd(string s)
        {
            Console.WriteLine(s + new string(' ', Console.WindowWidth - s.Length));
        }

        private static void CenterText(string s)
        {
            int number2;
            int number = Console.WindowWidth - s.Length;
            number = number / 2;
            number2 = number;

            if (number + number2 != s.Length)
            {
                number2++;
            }

            Console.WriteLine(new String(' ', number) + s + new String(' ', number2));
        }

        private static void CenterTextLine(string s)
        {
            int number2;
            int number = Console.WindowWidth - s.Length;
            number = number / 2;
            number2 = number;

            number -= 5;
            number2 -= 5;

            if (number + number2 != s.Length)
            {
                number2++;
            }

            Console.WriteLine(" =>  " + new String('+', number) + s + new String('+', number) + "  <= ");
        }

        private static void GetAllCharNumbers()
        {
            Array.Clear(allCharNumbers, 0, allCharNumbers.Length);
            for(int i = 32, x = 0; i <= 126; i++, x++)
            {
                allCharNumbers[x] = i;
            }
        }
    }
}
