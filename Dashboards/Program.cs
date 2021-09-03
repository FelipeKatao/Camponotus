using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Dashboards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start to server....");
            Connection con = new Connection("mongodb+srv://API:kG15AKehnpT2puME@cluster0.miyoa.mongodb.net/DashBoards?retryWrites=true&w=majority");
            con.AcessDataBaseServer();
            Console.WriteLine("Connect!");
            Console.ReadLine();
        }
    }
    class Connection
    {
        public Connection(string con)
        {
            Client = new MongoClient(con);
        }

        private MongoClient _Client;

        private MongoClient Client { get => _Client; set => _Client = value; }

        public void ListDataBases()
        {
            Console.WriteLine("Lista de banco de dados");
            ////foreach (var item in dbList)
          //  {
          //      Console.WriteLine(item);
          //  }
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
    }
    class DashBoard
    {
        public string NameField;
        public int Key;
        public string ValueField;
    }
}
