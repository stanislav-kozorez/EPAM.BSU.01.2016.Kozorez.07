using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task3
{
    public class QueueIsEmptyException: Exception
    {
        public QueueIsEmptyException()
        {
        }

        public QueueIsEmptyException(string message)
            :base(message)
        {
        }

        public QueueIsEmptyException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
