using ConverterToLogEvent;
while (true)
{
    string inputText = "1999-03-17 15:13:10|Message";

    string[] parts = inputText.Split('|');

    DateTime timestamp = DateTime.Parse(parts[0]);

    IdGenerator idGenerator = new();

    int id = idGenerator.Id();
    string message = parts[1];

    LogEvent logEvent = new(timestamp, id);


    Console.WriteLine(logEvent.Id);
}
