using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

public class Client
{
    static void Main(string[] args)
    {
        //< Connect() >
        Connect();
    }

    static void Connect()

    {
        connection:
        try
        {
            //Utilise un point de terminaison distant pour établir une connexion par socket.
            TcpClient tcpClient = new TcpClient();
            IPAddress ipAddress = IPAddress.Parse("192.168.1.78");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 50000);


            Console.WriteLine("Hello, bienvenue sur le serveur.");
            tcpClient.Connect(ipEndPoint);
            Console.WriteLine("\nVous êtes connecté !");


            NetworkStream stream = tcpClient.GetStream();
            StreamReader sr = new StreamReader(tcpClient.GetStream());
            StreamWriter sw = new StreamWriter(tcpClient.GetStream());
            /*
             * 
             * ENVOI TEXTE VERS LE SERVEUR 
             * 
             */
            Console.WriteLine("saisir un message a envoyer");
            string messageSend = Console.ReadLine();
            int byteCount = Encoding.UTF8.GetByteCount(messageSend + 1);
            byte[] dataSend = Encoding.UTF8.GetBytes(messageSend);




            stream.Write(dataSend, 0, dataSend.Length); // methode qui envoi le message 

            //Console.WriteLine(dataSend);
            sw.WriteLine("BONJOUR");
            sw.Flush();

            sw.WriteLine("BONSOIR");
            sw.Flush();

            /*
             * 
             * RECEPTION TEXTE DEPUIS LE CLIENT 
             * 
             */
            Byte[] dataRecieve = new byte[256];
            string messageRecieve;

            Int32 nbBytes = stream.Read(dataRecieve, 0, dataRecieve.Length);
            messageRecieve = System.Text.Encoding.ASCII.GetString(dataRecieve, 0, nbBytes);
            Console.WriteLine("Ce que j'ai recu : "+ messageRecieve);


            messageSend = Console.ReadLine();
            Byte[] dataSend2 = System.Text.Encoding.ASCII.GetBytes(messageSend);
            sw.WriteLine(messageSend);
            sw.Flush();

            // sans çà pas d'envoyer ni réponse 
            stream.Close();
            tcpClient.Close();


        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Test server");
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\n Press Enter to continue...");
        Console.Read();
    }
}