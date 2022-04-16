// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;
using System.Text;
public class UdpWorker
{
    public static int port = 5000;
    public static string address = "127.0.0.1";
    public static int counter=0;
    public static string message = "Hello world";
    public static void Main(string[] args)
    {
        Thread clientThread=new Thread(client);
        Thread serverThread=new Thread(server);
        clientThread.Start();
        serverThread.Start();

    }

    public static void client()
    {
        UdpClient sender = new UdpClient();
        byte[] data=Encoding.UTF8.GetBytes(message);
        while (true) {Console.Clear(); 
            if (counter == 100)
                break;
            sender.Send(data,data.Length,address,port);
            counter++;
               
            Thread.Sleep(1000);
        }
        sender.Close();
    }

    public static void server()
    {
        UdpClient receiver = new UdpClient(port);
        string data;
        IPEndPoint ip = null;
        while (true)
        {   
            if (counter == 100)
              break;
            data=Encoding.UTF8.GetString(receiver.Receive(ref ip));
            Console.WriteLine("Получено сообщение {0}, с текстом: {1}", counter,data);
            
            
        }
        receiver.Close();
    }
}
