using System;
using System.IO;
using System.Security.Cryptography;

namespace ConsoleApp1
{
    class Program
    {
        private const string CONF_KEY = @"PwMcyc8EXF//Qkye1Vl2S6oCOo9HFS7E7vw7y9GOzJk=";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var data = File.ReadAllBytes(args.Length > 0 ? args[0] : "payload.txt");

            var key = Convert.FromBase64String(args.Length == 2 ? args[1] : CONF_KEY);

            using var hmac = new HMACSHA256(key);

            var hash = hmac.ComputeHash(data);

            var hashBase64 = Convert.ToBase64String(hash);

            Console.WriteLine("Hash is: ");
            Console.WriteLine(hashBase64);
            Console.ReadLine();
        }
    }
}
