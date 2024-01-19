using System.Text.RegularExpressions;

 string ipAdressPattern = @"(\d+\.\d+\.\d+\.\d+)";


string logMessager = "Un-banning ip address 193.34.213.119, ban expired";
                                                
Console.WriteLine(UnBanIPParser(logMessager));
 string UnBanIPParser(string message)
{
    var addressPattern = @"(\d+\.\d+\.\d+\.\d+)";

    string address = GetMatchValue(message, addressPattern);

    var result = $"Розблоковано IP адресу: {address}";
    return result;
}
static string GetMatchValue(string input, string pattern)
{
    Match match = Regex.Match(input, pattern);

    return match.Groups[1].Value;
}
