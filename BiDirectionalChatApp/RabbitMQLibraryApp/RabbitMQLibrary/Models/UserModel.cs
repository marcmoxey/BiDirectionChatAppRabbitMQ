using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQLibrary.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public List<MessageModel> messages = new List<MessageModel>();
    }
}
            