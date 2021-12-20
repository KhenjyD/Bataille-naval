using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{
    public static void Main()
    {
        TcpListener? server = null;
        try
        {
            // Configurer le TcpListener sur le port 13000.
            Int32 port = 13000;
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // TcpListener server = new TcpListener(port);
            server = new TcpListener(localAddr, port);

            // Commencez à écouter les demandes des clients..
            server.Start();

            // Tampon pour la lecture des données
            Byte[] bytes = new Byte[256];
            String? data = null;

            // Entrez dans la boucle d'écoute.
            while (true)
            {
                Console.Write("Waiting for a connection... ");

                // Effectuer un appel bloquant pour accepter les demandes.
                // Vous pouvez également utiliser server.AcceptSocket() ici.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = null;

                // Obtenir un objet de flux pour la lecture et l'écriture
                NetworkStream stream = client.GetStream();

                int i;

                // Boucle pour recevoir toutes les données envoyées par le client.
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Traduire les octets de données en une chaîne ASCII..
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Traiter les données envoyées par le client.
                    data = data.ToUpper();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // send back a reponse.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }

                // Arrêt et fin de connexion
                client.Close();
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }
        finally
        {
            // Stop listening for new clients.
#pragma warning disable CS8602 // Déréférencement d'une éventuelle référence null.
            server.Stop();
#pragma warning restore CS8602 // Déréférencement d'une éventuelle référence null.
        }

        Console.WriteLine("\nHit enter to continue...");
        Console.Read();
    }
}
//serveur diponible 