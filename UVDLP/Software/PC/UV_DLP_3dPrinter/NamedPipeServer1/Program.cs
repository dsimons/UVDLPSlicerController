using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://stackoverflow.com/questions/13806153/example-of-named-pipes
namespace NamedPipeServerCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new NamedPipeServerStream("3dPrinter");
            server.WaitForConnection();
            StreamReader reader = new StreamReader(server);
            StreamWriter writer = new StreamWriter(server);

            Console.WriteLine(reader.ReadLine());

            writer.WriteLine("*** Hello From C# server ***");
            writer.Flush();

            Console.WriteLine("Press enter to exit");
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) break;
            }
        }
    }
}
