using System;

namespace ConsumeWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            API a = new API();
            RandoDog i = new RandoDog();
            Search s = new Search();
            SearchPic sp = new SearchPic();
            a.DogAPI();
            i.Rando();
            s.DogSearch();
            sp.DogSearchPic();
            Console.ReadLine();
        }
    }
}
