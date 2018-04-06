using System;

namespace ConsumeWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            API a = new API();
            RandoDog i = new RandoDog();
            a.DogAPI();
            i.Rando();
            Console.ReadLine();
        }
    }
}
