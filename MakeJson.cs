// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json.Serialization.Metadata;

namespace tymaker;

    
    public class LetterInfo
    {
        public string? gift { get; set; }
        public string? party { get; set; }
        public string? sender { get; set; }
        public string? address { get; set; }
    }



    public class MakeJson
    {
        public static void makeJson()
        {
            JsonTypeInfo<LetterInfo> typeInfo = SourceGenerationContext.Default.LetterInfo;
            Console.Write("Thank-you note bot JSON generator");
            Console.Write('\n');
            Console.Write("Version 1.0.0");
            Console.Write("\n\n");
            var letterInfo = new LetterInfo { };
            Console.Write("What gift are you getting?\nThis gift will be used until changed.\nIf you want to skip this, type \"skip\"\n\n");
            letterInfo.gift = Console.ReadLine();
            if (letterInfo.gift == "skip")
            {
                letterInfo.gift = null;
            }
            Console.Write("\n\n");
            Console.Write("What party are the thank-you notes for?\nThis party will be used until changed.\nIf you want to skip this, type \"skip\"\n\n");
            letterInfo.party = Console.ReadLine();
            if (letterInfo.party == "skip")
            {
                letterInfo.party = null;
            }
            Console.Write("\n\n");
            Console.Write("What is your name?\nThis sender will be used until changed.\nIf you want to skip this, type \"skip\"\n\n");
            letterInfo.sender = Console.ReadLine();
            if (letterInfo.sender == "skip")
            {
                letterInfo.sender = null;
            }
            Console.Write("\n\n");
            if (letterInfo.sender == null)
            {
                Console.Write("What do you want your closing word(s) to be? (e.g: {answer}, Joe)\nThis closing word will be used until changed.\nIf you want to skip this, type \"skip\"\n\n");
            } else
            {
                Console.Write("What do you want your closing word(s) to be? (e.g: {answer}, " + letterInfo.sender + ")\nThis closing word will be used until changed.\nIf you want to skip this, type \"skip\"\n\n");
            }
            letterInfo.address = Console.ReadLine();
            if (letterInfo.address == "skip")
            {
                letterInfo.address = null;
            }
            Console.Write("\n\n");
            string jsonString = JsonSerializer.Serialize(letterInfo, typeInfo);

            string savePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            File.WriteAllText(Path.Combine(savePath, "tymaker.json"), jsonString);
            Console.Write("Configuration file (tymaker.json) is saved at " + savePath + "\n\n");
        }

    }

    [JsonSerializable(typeof(LetterInfo))]
    internal partial class SourceGenerationContext : JsonSerializerContext { }

