using System.Text.Json.Nodes;
using static tymaker.Program;

namespace tymaker;

public static class ReadFromJson
{
    public static void ReadJson(LetterData letterData, bool overwriteAll, bool overwriteSection2)
    {
        if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "tymaker.json")))
        {
            if (overwriteAll)
            {
                letterData.Gift = null;
                letterData.Address = null;
                letterData.Party = null;
                letterData.Sender = null;
            }

            if (overwriteSection2)
            {
                letterData.Address = null;
                letterData.Sender = null;
            }

            var json =
                File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "tymaker.json"));
            var letterNode = JsonNode.Parse(json)!;
            if (letterNode["gift"] != null) letterData.Gift = letterNode["gift"]!.ToString();

            if (letterNode["party"] != null) letterData.Party = letterNode["party"]!.ToString();

            if (letterNode["sender"] != null) letterData.Sender = letterNode["sender"]!.ToString();

            if (letterNode["address"] != null) letterData.Address = letterNode["address"]!.ToString();
        }
    }
}