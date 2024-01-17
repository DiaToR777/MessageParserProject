using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterToLogEvent;

public class IdGenerator
{
    private int currentId = 0;
    private const int maxId = 999999;

    public int Id()
    {
        
            if (currentId < maxId)
            {
                currentId++;
            }
            else
            {
                currentId = 1;
            }

            return currentId;
    }

}