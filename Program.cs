using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Diagnostics.CodeAnalysis;
using static cgozenity;

public class Program
{



    public static void Main()
    {
        string? gift = null;
        string? address = null;
        string? party = null;
        string? sender = null;

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
        bool? save = null;
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
            reciever = cgozenity.zenEntry("Who are you writing to?", "tymaker");
            //Asks what gift was recieved
            if (gift != null)
            {
                Console.Write("Imported gift \"" + gift + "\" from tymaker-config\nSkipping\n", "tymaker");
            }
            else
            {
                //Reads answer to varible "gift"
                gift = cgozenity.zenEntry("What gift did you get from " + reciever + "?", "tymaker");
            }
            Console.Write('\n');
            //Asks what type party the person went to
            if (party != null)
            {
                Console.Write("Imported party \"" + party + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                //Reads answer to "party"
                cgozenity.zenEntry("What party did you invite " + reciever + " to? (Just write the noun with no connectors)", "tymaker");
            }
            //Prints part 1 of the letter
            bool? continue1 = cgozenity.zenQuestion("Here is your letter so far:" + '\n' + "Dear " + reciever + "," + '\n' + '\n' + "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + "." + "\n\nWould you like to move on to part 2?", "tymaker");
            //Asks the user if they like the letter so far
            Console.Write("Do you like it so far? Type in \"yes\" or \"no\". \nTyping in \"no\" will restart this part of the creation process, and typing in \"yes\" will move you on to the next part of the creation process. \n");
            Console.Write('\n');
            //checks the user's response
            switch (continue1)
            {
                case true:
                    //stops the restart loop
                    done = true;
                    break;
                case false:
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
        }
        //Tells the user that they are in Section 2
        cgozenity.zenInfo("You have started section 2.", "tymaker");
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
            title = zenEntry("What do you recognize " + reciever + " as? (e.g: \"aunt\", \"friend\", \"grandfather\")", "tymaker");
            recognize = zenEntry("How do you describe " + reciever + " as? (Context: 'answer' " + title + ")", "tymaker");
            article = zenList("an,a,my", "What article do you want to use? (Context: You are 'answer' " + recognize + " " + title + ".)", "tymaker");
            if (address != null)
            {
                Console.Write("Imported closing \"" + address + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                address = zenEntry("How would you like to address " + reciever + "? (e.g: Love, From, Regards)", "tymaker");
            }
            Console.Write('\n');
            Console.Write("What is your name?\n");
            if (sender != null)
            {
                Console.Write("Imported sender \"" + sender + "\" from tymaker-config\nSkipping\n");
            }
            else
            {
                zenEntry("How would you like to address " + reciever + "? (e.g: Love, From, Regards)", "tymaker");
            }
            bool? continue2 = zenQuestion("Here is your letter so far:\n\n" + "Dear " + reciever + "," + '\n' + '\n' + "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + ". You are " + article + " " + recognize + " " + title + ".\n\n" + address + ", " + sender + ".\n\n" + "Do you like it so far? Cancelling will restart this part of the creation process, and the OK button will move you on to outputting your letter to a file. \n", "tymaker");
            //checks the user's response
            switch (continue2)
            {
                case true:
                    //stops the restart loop
                    done1 = true;
                    break;
                case false:
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
            }           //restarts the program
        }
        bool done2 = false;
        while (!done2)
        {
            save = zenQuestion("Would you like to save your letter to a text file for later use?", "tymaker");
            switch (save)
            {
                case true:
                    done2 = true;
                    break;
                case false:
                    done2 = true;
                    zenNotify("Exiting program...\n", "tymaker");
                    Environment.Exit(0);
                    break;
                default:
                    done2 = false;
                    break;
            }
            string? path = zenSelectFileSaveWithFilter("", "", "Letter.txt");
            Console.Write('\n');
            string[] lines = { "Dear " + reciever + ",", "", "Thank you so much for coming to my " + party + ". Thank you so much for the " + gift + ". You are " + article + " " + recognize + " " + title + ".", "", address + ", " + sender + "." };
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(path))
            {
                foreach (string line in lines)
                    outputFile.WriteLine(line);
            }
            bool? openFile = zenQuestion(path + " is saved!\nDo you want to open it now?", "tymaker");
            
            switch (openFile)
            {
                case true:
                    Process p = new Process();
                    ProcessStartInfo pi = new ProcessStartInfo();
                    pi.UseShellExecute = true;
                    pi.FileName = @path;
                    p.StartInfo = pi;

                    try
                    {
                        p.Start();
                    }
                    catch (Exception)
                    {

                    }



                    break;
                case false:
                    Environment.Exit(0);
                    break;
                default:
                    Environment.Exit(0);
                    break;

            }
        }
    }
}