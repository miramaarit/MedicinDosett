using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace MedicinDosett.Data
{
     class DB
    {
        private static MongoClient GetClient()
        {
            string connectionString = "mongodb+srv://mira:miraadmin123@cluster0.afnxwa0.mongodb.net/?retryWrites=true&w=majority&appName=Cluster0";

            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.SslSettings = new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var mongoClient = new MongoClient(settings);

            return mongoClient;
        }

        public static IMongoCollection<Models.MammaMedicin> MedicinCollection()
        {
            var client = GetClient();

            var database = client.GetDatabase("MedicinDb");

            var medicinCollection = database.GetCollection<Models.MammaMedicin>("MammaMedicins3");

            return medicinCollection;
        }
      
    }
}
