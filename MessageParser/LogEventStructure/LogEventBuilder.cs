using LogEventBuilder.LogEventStructure;
using Parser.MessageParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LogEventStructur.LogEventBuilder;

public class LogEventBuilder
{
    private const string DATEFORMAT = "yyyy-MM-dd HH:mm:ss:ffff";
    readonly MessageParser parser = new();
    public LogEvent GetLogEvent(string log)
    {
        var logParts = log.Split("|");

        var logDate = logParts[0];
        var logMessage = logParts[3];

        DateTime date = DateParse(logDate);
        var message = MessageParse(logMessage);
        var id = 1;
        LogEvent logEvent = new(id, date, message);
        return logEvent;
    }

    private static DateTime DateParse(string logDate)
    {
        //var dateTime = logDate.Trim();
        //DateTime result = DateTime.ParseExact(dateTime, DATEFORMAT, null);
        //var stringDate = result.ToString();
        //return stringDate; Було


        return DateTime.ParseExact(logDate.Trim(), DATEFORMAT, null);   //стало
    }

    public string MessageParse(string logMessage)
     {
        Console.OutputEncoding = Encoding.Unicode;
          logMessage = logMessage.Trim();
          return parser.MainMessageParser(logMessage);
    }
}
