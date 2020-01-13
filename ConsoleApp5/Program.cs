using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args) 
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames().Where(r => r.EndsWith(".msg"));

            Console.WriteLine("I see the following resources:");
            Console.WriteLine(string.Join(Environment.NewLine, resources));
            Console.WriteLine();

            foreach (var resource in resources)
            {
                using (var stream = assembly.GetManifestResourceStream(resource))
                using (var reader = new StreamReader(stream))
                {
                    Console.WriteLine($"Contents of {resource}:");
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
        }
    }
}
