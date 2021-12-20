using System.Net.Sockets;
using System;
using System.IO;
using System.Net;
using System.Text;


class Program
{



    static void Main(string[] args)
    {
        Connect("connected");
    }

    static void Connect(String message)


    {
        try
        {


            //Uses a remote endpoint to establish a socket connection.
            TcpClient tcpClient = new TcpClient();
            IPAddress ipAddress = IPAddress.Parse("192.168.1.78");
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 50000);
            Console.WriteLine("hello");

            tcpClient.Connect(ipEndPoint);
            Console.WriteLine("teeeest");
            // Traduire le message transmis en ASCII et le stocker dans un tableau d'octets.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
            /*
            // Obtenez un flux client pour la lecture et l'écriture.
            //  Stream stream = client.GetStream();

            NetworkStream stream = client.GetStream();
            Console.WriteLine("Test Stream");
            // Envoyé un message au TcpServer connecté.
            stream.Write(data, 0, data.Length);

            Console.WriteLine("Sent: {0}", message);

            // Envoyer le message au TcpServer connecté.

            // Tampon pour stocker les octets de réponse.
            data = new Byte[256];

            // String pour stocker la représentation ASCII de la réponse.
            String responseData = String.Empty;
            // Lire le premier lot d'octets de réponse du TcpServer.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            // fermer tout
            stream.Close();
            client.Close();
      */
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
//connection impossible...