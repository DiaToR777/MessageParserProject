using System.Text.RegularExpressions;

 string ipAdressPattern = @"(\d+\.\d+\.\d+\.\d+)";
                          

string logMessager = "Login failure: 149.50.98.117, , RDP, 2, 14";


Console.WriteLine(LoginFailureParser(logMessager));
string LoginFailureParser(string logMessager)
{
    string addressPattern = @"(\d+\.\d+\.\d+\.\d+)";
    string ipAdress = GetMatchValue(logMessager, addressPattern);
    var message = $"Невдала спроба входу: {ipAdress}";
    return message;
}
static string GetMatchValue(string input, string pattern)
{
    Match match = Regex.Match(input, pattern);

    return match.Groups[1].Value;
}