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

            writer.WriteLine("*** Hello From C# client ***");
            writer.Flush();
            Console.WriteLine(reader.ReadLine());

            Console.WriteLine("Press enter to exit");
            while (true)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input)) break;
            }
        }
    }
}
