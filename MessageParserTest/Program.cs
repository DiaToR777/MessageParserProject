using System.Text.RegularExpressions;

 string ipAdressPattern = @"(\d+\.\d+\.\d+\.\d+)";
                          

string logMessager = "Firewall entries updated: 193.34.213.119,195.3.221.194";


Console.WriteLine(FirewalEntrlUpdateParser(logMessager));
 string FirewalEntrlUpdateParser(string message)
{
    var adressesPattern = @"(.+)";

    string adresses = GetMatchValue(message, adressesPattern);

    var result = $"Оновлені записи брандмауера: {adresses}";
    return result;
}
static string GetMatchValue(string input, string pattern)
{
    Match match = Regex.Match(input, pattern);

    return match.Groups[1].Value;
}