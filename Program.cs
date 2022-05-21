using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Diagnostics.CodeAnalysis;

public class Program
{



    public static void Main(string[] args)
    {
        string? gift = null;
        string? address = null;
        string? party = null;
        string? sender = null;
        string? extrasentences = null;
        if (Array.Exists(args, element => element == "-h") || Array.Exists(args, element => element == "--help"))
        {
        Console.Write("Thank-you note bot");
        Console.Write('\n');
        Console.Write("Version 1.0.0");
        Console.Write('\n');
        Console.Write("\n -h, --help    Displays this message");
        Console.Write("\n -c, --custom-sentences    Adds a prompt at the end to add your own custom sentences to the letter");
        Environment.Exit(0);
        }

        if (File.Exists((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"))) == true)
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"));
            JsonNode? letterNode = JsonNode.Parse(json)!;
            if (letterNode["gift"] != null)
            {
                gift = letterNode["gift"]!.ToString();
            }
            if (letterNode["party"] != null)
            {
                party = letterNode["party"]!.ToString();
            }
            if (letterNode["sender"] != null)
            {
                sender = letterNode["sender"]!.ToString();
            }
            if (letterNode["address"] != null)
            {
                address = letterNode["address"]!.ToString();
            }
        }



        //Prints version and title into console
        Console.Write("Thank-you note bot");
        Console.Write('\n');
        Console.Write("Version 1.0.0");
        Console.Write('\n');
        //sets up restart counter
        int attempts = 0;
        int attempts1 = 0;
        bool done = false;
        //Sets up restart loop
        string? reciever = "placeholder";
        string? title = "placeholder";
        string? recognize = "placeholder";
        string? article = "placeholder";
        string? save = "placeholder";
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
            reciever = Console.ReadLine();
            Console.Write('\n');
            //Asks what gift was recieved
            Console.Write("What gift did you get from " + reciever + "?");
            Console.Write('\n');
            if (gift != null)
            {
                Console.Write("Imported gift \"" + gift + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                //Reads answer to varible "gift"
                gift = Console.ReadLine();
            }
            Console.Write('\n');
            //Asks what type party the person went to
            Console.Write("What party did you invite " + reciever + " to? (Just write the noun with no connectors)");
            Console.Write('\n');
            if (party != null)
            {
                Console.Write("Imported party \"" + party + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                //Reads answer to "party"
                party = Console.ReadLine();
                Console.Write('\n');
            }
            //Prints part 1 of the letter
            Console.Write("Here is your letter so far:");
            Console.Write('\n');
            Console.Write("Dear " + reciever + "," + '\n' + '\n' + "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + ".");
            Console.Write('\n');
            Console.Write('\n');
            //Asks the user if they like the letter so far
            Console.Write("Do you like it so far? Type in \"yes\" or \"no\". \nTyping in \"no\" will restart this part of the creation process, and typing in \"yes\" will move you on to the next part of the creation process. \n");
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
                    gift = null;
                    address = null;
                    party = null;
                    sender = null;

                    if (File.Exists((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"))) == true)
                    {
                        string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"));
                        JsonNode? letterNode = JsonNode.Parse(json)!;
                        if (letterNode["gift"] != null)
                        {
                            gift = letterNode["gift"]!.ToString();
                        }
                        if (letterNode["party"] != null)
                        {
                            party = letterNode["party"]!.ToString();
                        }
                        if (letterNode["sender"] != null)
                        {
                            sender = letterNode["sender"]!.ToString();
                        }
                        if (letterNode["address"] != null)
                        {
                            address = letterNode["address"]!.ToString();
                        }

                    }
                    break;
                    //restarts the program
            }
            //Tells the user that they are in Section 2
            Console.Write("Section 2 \n\n");
            bool done1 = false;
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
                Console.Write("What do you recognize " + reciever + " as? (e.g: \"aunt\", \"friend\", \"grandfather\") \n");
                title = Console.ReadLine();
                Console.Write('\n');
                Console.Write('\n');
                Console.Write("How do you describe " + reciever + " as? (Context: 'answer' " + title + ")\n");
                recognize = Console.ReadLine();
                Console.Write('\n');
                Console.Write('\n');
                Console.Write("What article do you want to use? (Context: You are 'answer' " + recognize + " " + title + ".)\n");
                article = Console.ReadLine();
                Console.Write('\n');
                Console.Write('\n');
                if (Array.Exists(args, element => element == "-c") || Array.Exists(args, element => element == "--custom-sentences"))
                {
                    Console.Write("Are there any other sentences that you want to direct to " + reciever + "? (Comes after \"" + "You are " + article + " " + recognize + " " + title + "\")\n");
                    extrasentences = Console.ReadLine();
                }
                Console.Write("How would you like to address " + reciever + "? (e.g: Love, From, Regards)\n");
                if (address != null)
                {
                    Console.Write("Imported closing \"" + address + "\" from tymaker-config\nSkipping\n");
                }
                else
                {
                    address = Console.ReadLine();
                    Console.Write('\n');
                }
                Console.Write('\n');
                Console.Write("What is your name?\n");
                sender = Console.ReadLine();
                Console.Write('\n');
                Console.Write('\n');
                Console.Write("Here is your letter so far:");
                Console.Write('\n');
                Console.Write("Dear " + reciever + "," + '\n' + '\n' + "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + ". You are " + article + " " + recognize + " " + title + ".\n\n" + address + ", " + sender + ".");
                Console.Write('\n');
                Console.Write('\n');
                Console.Write("Do you like it so far? Type in \"yes\" or \"no\". \nTyping in \"no\" will restart this part of the creation process, and typing in \"yes\" will move you on to outputting your letter to a file. \n");
                string? continue2 = Console.ReadLine();
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
                        gift = null;
                        address = null;
                        party = null;
                        sender = null;

                        if (File.Exists((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"))) == true)
                        {
                            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "tymaker.json"));
                            JsonNode? letterNode = JsonNode.Parse(json)!;
                            if (letterNode["gift"] != null)
                            {
                                gift = letterNode["gift"]!.ToString();
                            }
                            if (letterNode["party"] != null)
                            {
                                party = letterNode["party"]!.ToString();
                            }
                            if (letterNode["sender"] != null)
                            {
                                sender = letterNode["sender"]!.ToString();
                            }
                            if (letterNode["address"] != null)
                            {
                                address = letterNode["address"]!.ToString();
                            }

                        }
                        break;
                        //restarts the program
                }
                bool done2 = false;
                while (!done2)
                {
                    Console.Write("Would you like to save your letter to a text file for later use?\nType in \"yes\" or \"no\". This will overwrite any text file with the same name.\n");
                    save = Console.ReadLine();
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
                    Console.Write("What do you want the name of the text file to be?\n");
                    string? fileName = Console.ReadLine();
                    Console.Write('\n');
                    string[] lines = { "Dear " + reciever + ",", "", "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + ". You are " + article + " " + recognize + " " + title + ".", "", address + ", " + sender + "." };
                    string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fileName + ".txt"), false))
                    {
                        foreach (string line in lines)
                            outputFile.WriteLine(line);
                    }
                    Console.Write(fileName + ".txt is now saved in " + docPath + "\nDo you want to open it now?\n");
                    string? openFile = Console.ReadLine();
                    switch (openFile)
                    {
                        case "yes":
                            Process p = new Process();
                            ProcessStartInfo pi = new ProcessStartInfo();
                            pi.UseShellExecute = true;
                            pi.FileName = @Path.Combine(docPath, fileName + ".txt");
                            p.StartInfo = pi;

                            try
                            {
                                p.Start();
                            }
                            catch (Exception)
                            {

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
        }
    }
}
