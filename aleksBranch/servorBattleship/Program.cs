using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

class MyTcpListener
{


    public static void Main()
    {
        // Entrez dans la boucle d'écoute.
        while (true)
        {
            TcpListener? server = null;
            try
            {
                // Configurer le TcpListener sur le port 13000.
                Int32 port = 50000;
                IPAddress localAddr = IPAddress.Parse("192.168.1.78");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);
                // Commencez à écouter les demandes des clients..
                server.Start();
                // Tampon pour la lecture des données
                Byte[] bytes = new Byte[256];
                String? data = null;



                Console.Write("Waiting for a connection... ");

                // Effectuer un appel bloquant pour accepter les demandes.
                // Vous pouvez également utiliser server.AcceptSocket() ici.
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine("Connected!");

                data = "response";

                // Obtenir un objet de flux pour la lecture et l'écriture
                NetworkStream stream = client.GetStream();
                StreamReader sr = new StreamReader(client.GetStream());
                StreamWriter sw = new StreamWriter(client.GetStream());

                Console.WriteLine("Bienvenue sur le serveur , le client est connecté");

                int i;

                // Boucle pour recevoir toutes les données envoyées par le client.

                /*i = stream.Read(bytes, 0, bytes.Length);
                Console.WriteLine("Received: {0}", sr.ReadLine());*/


                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine("Received: {0}", data);

                    // Process the data sent by the client.
                    data = Console.ReadLine();

                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                    // Send back a response.
                    stream.Write(msg, 0, msg.Length);
                    Console.WriteLine("Sent: {0}", data);
                }

                Console.WriteLine("ici on test " + data);
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(data);
                Console.WriteLine("test");
                stream.Write(msg2, 0, msg2.Length);
                Console.WriteLine(msg2);
                // Arrêt et fin de connexion
                client.Close();
                Console.WriteLine("console fermé");

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

        } // while
    }
}

//serveur diponible