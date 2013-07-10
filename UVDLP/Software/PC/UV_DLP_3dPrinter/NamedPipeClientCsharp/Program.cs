using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// http://stackoverflow.com/questions/13806153/example-of-named-pipes
namespace NamedPipeClientCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new NamedPipeClientStream("3dPrinter");
            client.Connect();
            StreamReader reader = new StreamReader(client);
            StreamWriter writer = new StreamWriter(client);

            String line = reader.ReadLine();
            Console.WriteLine(line);
            writer.WriteLine("CLIENT C#debugger");
            writer.Flush();

            while (true)
            {
                line = reader.ReadLine();
                Console.WriteLine(line);
                //writer.WriteLine("Received: " + line);
                //writer.Flush();
            }
        }
    }
}
