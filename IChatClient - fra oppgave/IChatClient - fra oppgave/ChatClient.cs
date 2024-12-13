using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatClient.Server;

namespace IChatClient___fra_oppgave
{
    internal class ChatClient : IChatClient
    {
        private readonly string _name;
        private readonly ChatServer _server;
        public ChatClient(string name, ChatServer server) {
        _server = server;
            _name = name;
            _server.Register(this);
                }
        public void Say(string message) {
            _server.Broadcast(this, $"{_name} sier: {message} ");
        }
        public void Receive(string message) {

            Console.WriteLine($"{_name} mottok: {message}");
        }
    }
}
