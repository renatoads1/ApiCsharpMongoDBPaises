using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace consomeapi
{
    class Program
    {
        static MongoClient cliente = new MongoClient();
        static IMongoDatabase db = cliente.GetDatabase("apiendereco");
        static IMongoCollection<Pais> paisesl = db.GetCollection<Pais>("pais");

        static void Main(string[] args)
        {
            Console.WriteLine("rodando");
            var repository = new PaisRepositorio();
            var PaisesTask = repository.GetPaisAsync();
            PaisesTask.ContinueWith(task => {
                var paises = task.Result;
                foreach (var item in paises)
                {
                    Pais p = new Pais(item.code,item.name);
                    paisesl.InsertOne(p);
                    Console.WriteLine(item.code);
                    Console.WriteLine(item.name);
                }

                Environment.Exit(0);
            },
            TaskContinuationOptions.OnlyOnRanToCompletion
            );
            Console.ReadLine();
        }

    }
}
