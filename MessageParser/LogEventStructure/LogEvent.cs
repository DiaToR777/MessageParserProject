﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogEventBuilder.LogEventStructure;

public class LogEvent
{

    public int Id { get; }
    public DateTime Date { get; }
    public string Messsage { get; }

    public LogEvent(int id, DateTime date, string messsage)
    {
        Id = id;
        Date = date;
        Messsage = messsage;
    }
}
