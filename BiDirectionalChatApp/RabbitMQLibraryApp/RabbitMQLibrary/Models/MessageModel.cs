using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class MessageModel
    {
        public string MessageString { get; set; }
        public string UserName { get; set; }  

      

        public string MessageDisplayValue => $"{UserName} says: {MessageString}";
    }
}
