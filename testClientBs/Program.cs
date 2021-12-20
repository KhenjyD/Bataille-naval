using System.Net.Sockets;
using System;
using System.IO;
using System.Net;
using System.Text;


class Program
{ 



static void Main(string[] args)
{
    Connect("127.0.0.1", "connected");
}

static void Connect(String server, String message)
{
    try
    {
        // Créer un TcpClient
        // Notez que pour que ce client fonctionne, vous devez avoir un TcpServer
        // connecté à la même adresse que celle spécifiée par le serveur, la combinaison de ports
        Int32 port = 13000;
        TcpClient client = new TcpClient(server, port);

        // Traduire le message transmis en ASCII et le stocker dans un tableau d'octets.
        Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

        // Obtenez un flux client pour la lecture et l'écriture.
        //  Stream stream = client.GetStream();

        NetworkStream stream = client.GetStream();

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
    }
    catch (ArgumentNullException e)
    {
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