using MessageParser.MessageParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.LogEventStructure;

public class LogEventBuilder
{
    private const string DATEFORMAT = "yyyy-MM-dd HH:mm:ss:ffff";
    MessageParser_ parser = new();
    public LogEvent GetLogEvent(string log)
    {
        var logParts = log.Split("|");

        var logDate = logParts[0];
        var logMessage = logParts[3];

        var date = DateParse(logDate);
        var message = MessageParse(logMessage);
        var id = 1;
        LogEvent logEvent = new(id, message, date);
        return logEvent;

    }

    private string DateParse(string logDate)
    {
        var dateTime = logDate.Trim();
        DateTime result = DateTime.ParseExact(dateTime, DATEFORMAT, null);
        var stringDate = result.ToString();
        return stringDate;

    }

    public string MessageParse(string logMessage)
    {
        var message = logMessage.Trim();

        return parser.MainMessageParser(message);
    }
}
