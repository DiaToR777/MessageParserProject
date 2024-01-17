using MessageParser.LogEventStructure;

string exemple = "2024-01-12 00:00:32.8101|WARN|IpBan|USjasjajodada(mes)";

var logParts = exemple.Split("|");

var logMessage = logParts[3];
LogEventBuilder bealder = new();
//Console.WriteLine(bealder.MessageParse(logMessage));

