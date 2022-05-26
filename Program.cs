using System.Diagnostics;
using static tymaker.ReadFromJson;

namespace tymaker;

public static class Program
{
    public static void Main(string[] args)
    {
        var letterData = new LetterData();
        if (Array.Exists(args, element => element == "-h") || Array.Exists(args, element => element == "--help"))
        {
            Console.Write("Thank-you note bot");
            Console.Write('\n');
            Console.Write("Version 1.0.0");
            Console.Write('\n');
            Console.Write("\n -h, --help                     Displays this message");
            Console.Write(
                "\n -c, --custom-sentences         Adds a prompt at the end to add your own custom sentences to the letter\n");
            Console.Write(
                "\n -r, --letterData.Receiver-as-file-name    Adds a prompt at the end to add your own custom sentences to the letter\n");
            Environment.Exit(0);
        }


        ReadJson(letterData, true, false);


        //Prints version and title into console
        Console.Write("Thank-you note bot");
        Console.Write('\n');
        Console.Write("Version 1.0.0");
        Console.Write('\n');
        //sets up restart counter
        var attempts = 0;
        var attempts1 = 0;
        var done = false;
        //Sets up restart loop
        string? letter = null;
        while (!done)
        {
            //sets up restart counter (attempts)
            if (attempts > 1)
            {
                Console.Write("You have redone this section " + attempts + " times.");
                Console.Write('\n');
            }

            if (attempts == 1)
            {
                Console.Write("You have redone this section " + attempts + " time.");
                Console.Write('\n');
            }

            //Asks who the letter is directed to
            Console.Write('\n');
            Console.Write("Who are you writing to?");
            Console.Write('\n');
            //Reads answer to varible "reciever"
            letterData.Receiver = Console.ReadLine();
            Console.Write('\n');
            //Asks what gift was recieved
            Console.Write("What gift did you get from " + letterData.Receiver + "?");
            Console.Write('\n');
            if (letterData.Gift != null)
                Console.Write("Imported gift \"" + letterData.Gift + "\" from tymaker-config\nSkipping\n");
            else
                //Reads answer to varible "gift"
                letterData.Gift = Console.ReadLine();
            Console.Write('\n');
            //Asks what type party the person went to
            Console.Write("What party did you invite " + letterData.Receiver +
                          " to? (Just write the noun with no connectors)");
            Console.Write('\n');
            if (letterData.Party != null)
            {
                Console.Write("Imported party \"" + letterData.Party + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                //Reads answer to "party"
                letterData.Party = Console.ReadLine();
                Console.Write('\n');
            }

            //Prints part 1 of the letter
            Console.Write("Here is your letter so far:");
            Console.Write('\n');
            Console.Write("Dear " + letterData.Receiver + "," + '\n' + '\n' + "Thank you so much for coming to my " +
                          letterData.Party + ". Thank you so much for the " + letterData.Party + ".");
            Console.Write('\n');
            Console.Write('\n');
            //Asks the user if they like the letter so far
            Console.Write(
                "Do you like it so far? Type in \"yes\" or \"no\". \nTyping in \"no\" will restart this part of the creation process, and typing in \"yes\" will move you on to the next part of the creation process. \n");
            // ReSharper disable once SuggestVarOrType_BuiltInTypes
            string? continue1 = Console.ReadLine();
            Console.Write('\n');
            //checks the user's response
            switch (continue1)
            {
                case "yes":
                    //stops the restart loop
                    done = true;
                    break;
                case "no":
                    //leaves the restart loop on
                    done = false;
                    //clears the console and adds 1 to the restart cunter
                    Console.Clear();
                    attempts++;
                    Console.Write('\n');
                    Console.Write('\n');
                    ReadJson(letterData, true, false);
                    break;
                //restarts the program
            }
        }

        //Tells the user that they are in Section 2
        Console.Write("Section 2 \n\n");
        var done1 = false;
        while (!done1)
        {
            if (attempts1 > 1)
            {
                Console.Write("You have redone this section " + attempts1 + " times.");
                Console.Write('\n');
            }

            if (attempts1 == 1)
            {
                Console.Write("You have redone this section " + attempts1 + " time.");
                Console.Write('\n');
            }

            Console.Write("What do you recognize " + letterData.Receiver +
                          " as? (e.g: \"aunt\", \"friend\", \"grandfather\") \n");
            letterData.Title = Console.ReadLine();
            Console.Write('\n');
            Console.Write('\n');
            Console.Write("How do you describe " + letterData.Receiver + " as? (Context: 'answer' " + letterData.Title +
                          ")\n");
            letterData.Recognize = Console.ReadLine();
            Console.Write('\n');
            Console.Write('\n');
            Console.Write("What article do you want to use? (Context: You are 'answer' " + letterData.Recognize + " " +
                          letterData.Title +
                          ".)\n");
            letterData.Article = Console.ReadLine();
            Console.Write('\n');
            Console.Write('\n');
            if (Array.Exists(args, element => element == "-c") ||
                Array.Exists(args, element => element == "--custom-sentences"))
            {
                Console.Write("Are there any other sentences that you want to direct to " + letterData.Receiver +
                              "? (Comes after \"" + "You are " + letterData.Article + " " + letterData.Recognize + " " +
                              letterData.Title + "\")\n");
                letterData.ExtraSentences = Console.ReadLine();
            }

            Console.Write("How would you like to address " + letterData.Receiver + "? (e.g: Love, From, Regards)\n");
            if (letterData.Address != null)
            {
                Console.Write("Imported closing \"" + letterData.Address + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                letterData.Address = Console.ReadLine();
                Console.Write('\n');
            }

            Console.Write('\n');
            Console.Write("What is your name?\n");
            if (letterData.Sender != null)
            {
                Console.Write("Imported sender \"" + letterData.Sender + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                letterData.Sender = Console.ReadLine();
                Console.Write('\n');
            }

            Console.Write('\n');
            Console.Write('\n');
            if (letterData.ExtraSentences != null)
                letter = "Dear " + letterData.Receiver + "," + '\n' + '\n' + "Thank you so much for coming to my " +
                         letterData.Party +
                         ". Thank you so much for the " + letterData.Gift + ". You are " + letterData.Article + " " +
                         letterData.Recognize + " " +
                         letterData.Title + ". " + letterData.ExtraSentences + "\n\n" + letterData.Address + ", " +
                         letterData.Sender + ".";
            else
                letter = "Dear " + letterData.Receiver + "," + '\n' + '\n' + "Thank you so much for coming to my " +
                         letterData.Party +
                         ". Thank you so much for the " + letterData.Gift + ". You are " + letterData.Article + " " +
                         letterData.Recognize + " " +
                         letterData.Title + ".\n\n" + letterData.Address + ", " + letterData.Sender + ".";
            Console.Write("Here is your letter so far:");
            Console.Write('\n');
            Console.Write(letter);
            Console.Write('\n');
            Console.Write('\n');
            Console.Write(
                "Do you like it so far? Type in \"yes\" or \"no\". \nTyping in \"no\" will restart this part of the creation process, and typing in \"yes\" will move you on to outputting your letter to a file. \n");
            var continue2 = Console.ReadLine();
            Console.Write('\n');
            //checks the user's response
            switch (continue2)
            {
                case "yes":
                    //stops the restart loop
                    done1 = true;
                    break;
                case "no":
                    //leaves the restart loop on
                    done1 = false;
                    //clears the console and adds 1 to the restart cunter
                    Console.Clear();
                    attempts1++;
                    Console.Write('\n');
                    Console.Write('\n');
                    ReadJson(letterData, false, true);
                    break;
                //restarts the program
            }
        }

        var done2 = false;
        while (!done2)
        {
            Console.Write(
                "Would you like to save your letter to a text file for later use?\nType in \"yes\" or \"no\". This will overwrite any text file with the same name.\n");
            var save = Console.ReadLine();
            switch (save)
            {
                case "yes":
                    done2 = true;
                    break;
                case "no":
                    done2 = true;
                    Console.Write("Exiting program...\n");
                    Environment.Exit(0);
                    break;
                default:
                    done2 = false;
                    break;
            }

            string? fileName = null;
            if (Array.Exists(args, element => element == "-r") ||
                Array.Exists(args, element => element == "--letterData.Receiver-as-file-name"))
            {
                fileName = letterData.Receiver;
            }
            else
            {
                Console.Write("What do you want the name of the text file to be?\n");
                fileName = Console.ReadLine();
                Console.Write('\n');
            }

            var docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var outputFile = new StreamWriter(Path.Combine(docPath, fileName + ".txt"), false))
            {
                outputFile.Write(letter);
            }

            Console.Write(fileName + ".txt is now saved in " + docPath + "\nDo you want to open it now?\n");
            var openFile = Console.ReadLine();
            switch (openFile)
            {
                case "yes":
                    var p = new Process();
                    var pi = new ProcessStartInfo();
                    pi.UseShellExecute = true;
                    pi.FileName = Path.Combine(docPath, fileName + ".txt");
                    p.StartInfo = pi;

                    try
                    {
                        p.Start();
                    }
                    catch (Exception)
                    {
                        // ignored
                    }


                    break;
                case "no":
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    public class LetterData
    {
        public string? Gift { get; set; }
        public string? Address { get; set; }
        public string? Party { get; set; }
        public string? Sender { get; set; }
        public string? ExtraSentences { get; set; }
        public string? Receiver { get; set; }
        public string? Title { get; set; }
        public string? Recognize { get; set; }
        public string? Article { get; set; }
    }
}