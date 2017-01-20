using COM_Laba;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Laba_Interface.Providers
{
	public class IDB_webAPI : IDB, IDisposable
	{
		private HttpClient client = new HttpClient();

		public IDB_webAPI()
		{
			client.BaseAddress = new Uri("http://localhost:6666");
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}

		public string CreateDatabase(string name) { return client.PostAsync("api/Database", new StringContent(JsonConvert.SerializeObject(new { Name = name }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public string CreateTable(string database, string name) { return client.PostAsync("api/Database/" + database + "/Table", new StringContent(JsonConvert.SerializeObject(new { Name = name }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public string CreateTableDistinct(string database, string table, string name) { return client.PostAsync("api/Database/" + database + "/Table/" + table + "/Distinct", new StringContent(JsonConvert.SerializeObject(new { Name = name }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public string CreateColumn(string database, string table, string name, string type) { return client.PostAsync("api/Database/" + database + "/Table/" + table + "/Column", new StringContent(JsonConvert.SerializeObject(new { Name = name, Type = type }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public void CreateRow(string database, string table) { var result = client.PostAsync("api/Database/" + database + "/Table/" + table, null).Result.Content.ReadAsStringAsync().Result; }
		public void RenameDatabase(string database, string name) { var result = client.PutAsync("api/Database/" + database, new StringContent(JsonConvert.SerializeObject(new { Name = name }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public void RenameTable(string database, string table, string name) { var result = client.PutAsync("api/Database/" + database + "/Table/" + table, new StringContent(JsonConvert.SerializeObject(new { Name = name }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public void SetValue(string database, string table, string column, int row, string value) { var result = client.PutAsync("api/Database/" + database + "/Table/" + table + "/Column/" + column + "/Row/" + row, new StringContent(JsonConvert.SerializeObject(new { Value = value }), Encoding.UTF8, "application/json")).Result.Content.ReadAsStringAsync().Result; }
		public Dictionary<string, DatabaseData> GetDatabases() { return JsonConvert.DeserializeObject<Dictionary<string, DatabaseData>>(client.GetAsync("api/Database").Result.Content.ReadAsStringAsync().Result); }
		public Dictionary<string, TableData> GetTables(string database) { return JsonConvert.DeserializeObject<Dictionary<string, TableData>>(client.GetAsync("api/Database/" + database + "/Table").Result.Content.ReadAsStringAsync().Result); }
		public Dictionary<string, Column> GetColumns(string database, string table) { return JsonConvert.DeserializeObject<Dictionary<string, Column>>(client.GetAsync("api/Database/" + database + "/Table/" + table + "/Column").Result.Content.ReadAsStringAsync().Result); }
		public void DeleteDatabase(string database) { var result = client.DeleteAsync("api/Database/" + database).Result.Content.ReadAsStringAsync().Result; }
		public void DeleteTable(string database, string table) { var result = client.DeleteAsync("api/Database/" + database + "/Table/" + table).Result.Content.ReadAsStringAsync().Result; }
		public void DeleteColumn(string database, string table, string column) { var result = client.DeleteAsync("api/Database/" + database + "/Table/" + table + "/Column/" + column).Result.Content.ReadAsStringAsync().Result; }
		public void DeleteRow(string database, string table, int row) { var result = client.DeleteAsync("api/Database/" + database + "/Table/" + table + "/Row/" + row).Result.Content.ReadAsStringAsync().Result; }

		public void Dispose()
		{
			client.Dispose();
		}
	}
}
