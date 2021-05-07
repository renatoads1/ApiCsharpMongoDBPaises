using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace consomeapi
{
    class Program
    {
        static MongoClient cliente = new MongoClient();
        static IMongoDatabase db = cliente.GetDatabase("apiendereco");
        static IMongoCollection<Pais> paisesl = db.GetCollection<Pais>("pais");
        static IMongoCollection<Regiao> regiaol = db.GetCollection<Regiao>("region");
        static IMongoCollection<City> cityl = db.GetCollection<City>("city");

        static void Main(string[] args)
        {
            Console.WriteLine("rodando");

            List<Regiao> reg = regiaol.AsQueryable().ToList<Regiao>();

            var regsss = from s in reg select s;
            foreach (Regiao i in regsss)
            {
                //Console.WriteLine(i.country);
                //Console.WriteLine(i.region);
                //Console.WriteLine(i.city);
                insereregiao(i.country, i.region);

                Console.WriteLine("#########################");

                //Console.WriteLine(i.name);
                //insereregiao(i.name);
                Thread.Sleep(4000);
            }


            //var repositorypais = new PaisRepositorio();
            //var PaisesTask = repositorypais.GetPaisAsync();

            //PaisesTask.ContinueWith(task => {
            //    var paises = task.Result;
            //    foreach (var item in paises)
            //    {

            //        insereregiao(item.code);
            //        Thread.Sleep(5000);

            //        //Pais p = new Pais(item.code,item.name);
            //        //paisesl.InsertOne(p);
            //        Console.WriteLine(item.code);
            //        Console.WriteLine(item.name);
            //    }

            //    Environment.Exit(0);
            //},
            //TaskContinuationOptions.OnlyOnRanToCompletion
            //);
            Console.ReadLine();
        }

        public static void insereregiao(string codigo,string region) {
            var repositorycity = new CityRepositorio();

            var CityTask = repositorycity.GetRegiaoAsync(codigo,region);

            CityTask.ContinueWith(taskc => {
                Console.WriteLine("entrou");
                var citys = taskc.Result;
                foreach (var i in citys)
                {
                    Console.WriteLine(i.country.ToString()); 
                    City a = new City(i.city, i.region,i.country,i.latitude,i.longitude);
                    cityl.InsertOne(a);
                }
                //Environment.Exit(0);

            }, TaskContinuationOptions.OnlyOnRanToCompletion);

        }

    }
}
