using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Api.Models;
using Api.Repository.Helper;
using Dapper;

namespace Api.Repository
{
    public class ClientRepository : IClientRepository
    {
        private const string DbFilePath = "./ClientsDb.sqlite";

        private SQLiteConnection _db;

        public ClientRepository()
        {
            CreateAndOpenDb();
            EnsureTableExistence();
        }

        public void AddClient(Client client) => _db.ExecuteQuery("INSERT INTO Clients(Name, Age, Description) VALUES (@Name, @Age, @Description)", client);

        public List<Client> GetAllClients() => _db.Query<Client>("SELECT * FROM Clients").ToList();

        public Client GetClient(int id) => _db.Query<Client>($"SELECT * FROM Clients WHERE id={id}").FirstOrDefault();

        public void UpdateClient(int id, Client client) => _db.ExecuteQuery($"UPDATE Clients SET Name = @Name, Age = @Age, Description = @Description WHERE id={id}", client);

        public void DeleteClient(int id) => _db.ExecuteQuery($"DELETE FROM Clients WHERE id={id}");

        private void EnsureTableExistence() =>
            _db.ExecuteQuery(@"
            CREATE TABLE IF NOT EXISTS [Clients] (
            [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
            [Name] NVARCHAR(100) NOT NULL,
            [Age] INT NOT NULL,
            [Description] NVARCHAR(128) NOT NULL)");

        private void CreateAndOpenDb()
        {
            if (!File.Exists(DbFilePath))
                SQLiteConnection.CreateFile(DbFilePath);

            _db = new SQLiteConnection($"Data Source={DbFilePath};Version=3;");
            _db.Open();
        }
    }
}