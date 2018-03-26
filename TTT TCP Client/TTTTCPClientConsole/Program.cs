using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace TTTTCPClientConsole
{
    class Program
    {
        static TcpClient client = new TcpClient();
        static Board board;

        static void Send(string str)
        {
            client.GetStream().Write(Encoding.ASCII.GetBytes(str), 0, str.Length);
        }

        static string Get()
        {
            byte[] buf = new byte[256];
            int l = client.GetStream().Read(buf, 0, 256);

            return new string(Encoding.ASCII.GetChars(buf)).Substring(0, l);
        }

        static void RunConnect()
        {
            while (client.Connected == false)
            {
                Console.Write("Welcome to the TCP TicTacToe client!\nWhat server would you like to connect to? (blank for localhost): ");
                string svr = Console.ReadLine();
                if (svr.Trim().Length == 0)
                    svr = "localhost";

                Console.Write("Port (blank for 11000): ");
                string sport = Console.ReadLine();
                int port;

                while (!(int.TryParse(sport, out port) || sport.Trim().Length == 0))
                {
                    Console.Write("Port must be an integer or blank. Port (blank for 11000): ");
                    sport = Console.ReadLine();
                }

                if (sport.Trim().Length == 0)
                    port = 11000;

                try
                {
                    client.Connect(svr, port);
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("\nError connecting.\n");
                }
            }
        }

        static void Main(string[] args)
        {
            RunConnect();



            Console.Clear();
            Send("N");
            board = new Board();

            string svrd;
            while (true)
            {
                svrd = Get();
                string[] lines = svrd.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string svrl1 in lines)
                {
                    string svrl = svrl1.Trim();

                    if (svrl.Length != 0)
                    {
                        Console.Clear();


                        Console.WriteLine(svrl);

                        if (svrl[0] == 'T')
                        {
                            Console.WriteLine(board.Render());
                            Console.WriteLine("Your turn.");

                            int r;
                            int c;

                            while (true)
                            {
                                Console.Write("Location: ");

                                string input = Console.ReadLine().Trim();
                                bool proper = true;

                                if (input.Length != 2)
                                    proper = false;

                                if (!int.TryParse(input.Substring(0, 1), out r))
                                    proper = false;
                                if (!int.TryParse(input.Substring(1, 1), out c))
                                    proper = false;

                                if (r < 0 || r > 2)
                                    proper = false;
                                if (c < 0 || c > 2)
                                    proper = false;

                                if (!proper)
                                {
                                    Console.WriteLine("Invalid input.");
                                }
                                else
                                {
                                    if (board.segs[r, c] != ' ')
                                        Console.WriteLine("Space taken.");
                                    else
                                        break;
                                }
                            }

                            board.segs[r, c] = 'X';

                            Send("M " + r.ToString() + c.ToString());
                        }
                        else if (svrl[0] == 'M')
                        {
                            board.segs[int.Parse(svrl.Substring(2, 1)), int.Parse(svrl.Substring(3, 1))] = 'O';
                            Console.WriteLine(board.Render());
                        }
                        else if (svrl[0] == 'O')
                        {
                            if (svrl[2] == 'C')
                                Console.WriteLine("You won!");
                            else
                                Console.WriteLine("You lost :(");

                            Console.WriteLine("Press enter to play a new game.");
                            Console.ReadLine();

                            board = new Board();
                            Send("N");
                        }
                    }
                }
            }


            string ln;
            while ((ln = Console.ReadLine()) != "exit")
            {

            }
        }
    }
}
