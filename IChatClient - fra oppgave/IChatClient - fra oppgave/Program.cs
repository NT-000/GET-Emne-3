using ChatClient.Server;
using IChatClient___fra_oppgave;

var server = new ChatServer();

var client1 = new IChatClient___fra_oppgave.ChatClient("Per", server);
var client2 = new IChatClient___fra_oppgave.ChatClient("Pål", server);
var client3 = new IChatClient___fra_oppgave.ChatClient("Espen", server);

client1.Say("Hei");
client2.Say("Hello");
client3.Say("Eg kappåt med trollet");