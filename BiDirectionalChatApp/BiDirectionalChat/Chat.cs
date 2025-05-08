using Newtonsoft.Json;
using RabbitMQLibrary;
using RabbitMQLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BiDirectionalChat
{
    public partial class Chat : Form
    {
        RabbitMQSender publisher = new RabbitMQSender();
        RabbitMQReceiver subscriber = new RabbitMQReceiver();
        BindingList<MessageModel> messages = new BindingList<MessageModel>();

        public Chat()
        {
            InitializeComponent();
            List<UserModel> users = new List<UserModel>
            {
                new UserModel { UserName = "UserOne" },
                new UserModel { UserName = "UserTwo" }
            }; 
            
            usersComboBox.DataSource = users;
            usersComboBox.DisplayMember = nameof(MessageModel.UserName);

            messagesListBox.DataSource = messages;
            messagesListBox.DisplayMember = nameof(MessageModel.MessageDisplayValue);

            // start listing
            subscriber.StartConsuming((msg) =>
            {
                var model = JsonConvert.DeserializeObject<MessageModel>(msg);
                if (model != null)
                {
                    Invoke(new MethodInvoker(() => messages.Add(model)));
                }
            });


        }
        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (usersComboBox.SelectedItem is UserModel user && !string.IsNullOrWhiteSpace(messageTextBox.Text))
            {
                var message = new MessageModel
                {
                    UserName = user.UserName,
                    MessageString = messageTextBox.Text
                };

                string serialized = JsonConvert.SerializeObject(message); 
                publisher.SendMessage(serialized);

                messageTextBox.Clear();
            }
        }

    }
}
