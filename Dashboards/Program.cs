using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Firestore;

namespace Dashboards
{
    class Program
    {
        static void Main(string[] args)
        {


            ///////


           // Console.WriteLine("Start to server....");
            //Connection con = new Connection("mongodb://CAMPONOTUS:kG15AKnpT2puME@cluster0.miyoa.mongodb.net/DashBoards");
            //con.AcessDataBaseServer();
           // con.ConDataBase();
           // Console.WriteLine("Connect!");
           // Console.WriteLine("Tentando adicionar dados");
           // con.DashboardController();
            //Console.ReadLine();
        }
    }
    class Connection
    {
        public Connection(string con)
        {
            Client = new MongoClient(con);
            Str_con = con;
        }

        private string Str_con;
        private MongoClient _Client;
        private MongoClient Client { get => _Client; set => _Client = value; }
        private IMongoDatabase MongoDatabaseBase;
        private IMongoCollection<DashBoard> _DashboardCollection;

        public void ListDataBases()
        {
            Console.WriteLine("Lista de banco de dados");
            ////foreach (var item in dbList)
          //  {
          //      Console.WriteLine(item);
          //  }
        }
        public  void ConDataBase()
        {
            var settings = MongoClientSettings.FromUrl(new MongoUrl(Str_con));
            var client = new MongoClient(settings);
            MongoDatabaseBase = client.GetDatabase("DashBoards");
        }
        public void AcessDataBaseServer()
        {
            Client.GetDatabase("DashBoards");
        }
        public void CreateDocuments(string title)
        {
            var database = Client.GetDatabase("DashBoards.Board");
            var DashCollection = database.GetCollection<DashBoard>("DashBoards.Board");
        }
        [HttpPost]
        public string  DashboardController()
        {
            var SetDB = MongoClientSettings.FromConnectionString("mongodb+srv://API:qmEW7qQuLB09i7u7@cluster0.miyoa.mongodb.net/myFirstDatabase?retryWrites=true&w=majority?connect=replicaSet");
            Client = new MongoClient(SetDB);
            var database = Client.GetDatabase("DashBoards");
            
            _DashboardCollection = database.GetCollection<DashBoard>("dash");
            DashBoard dash = new DashBoard("Primeiro valor",34,"Data de teste");
            _DashboardCollection.InsertOne(dash);
            return "Adicionado com Sucesso";
        }
    }
    class DashBoard
    {

        [BsonElement("NameField")]
        public string NameField;
        public int Key;
        public string ValueField;
        public DashBoard(string name,int key,string value)
        {
            NameField = name;
            Key = key;
            ValueField = value;
        }
    }
    class FireBaseSolution
    {
       
    }
}
