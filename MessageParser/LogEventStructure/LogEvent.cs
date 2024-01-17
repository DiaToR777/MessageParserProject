using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageParser.LogEventStructure;

public class LogEvent
{

    public int Id { get; }
    public string Date { get; }
    public string Messsage { get; }

    public LogEvent(int id, string date, string messsage)
    {
        Id = id;
        Date = date;
        Messsage = messsage;
    }
}
