using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Data.SqlClient;
using System.Net.Http;
using WebApi;

namespace TestWebApi.Provider
{
    public class TestClientProvider : IDisposable
    {
        public TestClientProvider()
        {
            var builder = new WebHostBuilder()
                .UseStartup<Startup>()
                .UseSetting("DatabaseSettings:ConnectionString", "Data Source=DESKTOP-9R0JJCE\\SQLEXPRESS;Initial Catalog=SmartAssembly;Integrated Security=True");

            Server = new TestServer(builder);
            Client = Server.CreateClient();
        }

        public HttpClient Client { get; }

        public TestServer Server { get; }

        public void Dispose()
        {
            Server?.Dispose();
            Client?.Dispose();
        }

        private SqlConnection Connection
        {
            get
            {
                var connection = new SqlConnection(@"Data Source=DESKTOP-9R0JJCE\SQLEXPRESS;Initial Catalog=SmartAssembly;Integrated Security=True");
                connection.Open();
                return connection;
            }
        }

        public int? GetLastId(string tableName)
        {
            var command = new SqlCommand($"SELECT top(1) ID FROM [{tableName}] order by ID desc", Connection);
            var reader = command.ExecuteReader();
            int? id = null;
            if (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            return id;
        }

        public string GetLastName(string tableName, string columnName)
        {
            var command = new SqlCommand($"SELECT top(1) {columnName} FROM [{tableName}] order by ID desc", Connection);
            var reader = command.ExecuteReader();
            string name = null;
            if (reader.Read())
            {
                name = reader.GetString(0);
            }
            return name;
        }
    }
}
