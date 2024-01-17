using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterToLogEvent;

public class LogEvent
{
    public DateTime Timestamp { get; }
    public int Id { get; set; }
    public string Message { get; }
    
    public LogEvent(DateTime timestamp, int id, string message)
    {
        Timestamp = timestamp;
        Id = id;
        Message = message;
    }



}
