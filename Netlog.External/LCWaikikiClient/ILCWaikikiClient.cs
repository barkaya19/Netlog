using System.Net.Http.Json;
using System.Text.Json;

namespace Netlog.External.LCWaikikiClient
{
    public interface ILcWaikikiClient
    {
        Task<List<LcWaikikiOrderResponse>?> GetLcWaikikiOrders();
    }
    
    
    public class LcWaikikiClient:ILcWaikikiClient
    {
        private readonly HttpClient _httpClient;
        public LcWaikikiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        
        public async Task<List<LcWaikikiOrderResponse>?> GetLcWaikikiOrders()
        {
            const string query = "api/Order";

            var lcWaikikiResponse = await _httpClient.GetAsync(query);
            if (!lcWaikikiResponse.IsSuccessStatusCode)
            {
                throw new Exception("Failed getting lc waikiki response");
            }
            // var json = await lcWaikikiResponse.Content.ReadAsStringAsync();
            // var response =  JsonSerializer.Deserialize<List<LcWaikikiOrderResponse>>(json);
            return  await lcWaikikiResponse.Content.ReadFromJsonAsync<List<LcWaikikiOrderResponse>>();
            
        }
    }
    
    public class LcWaikikiOrderResponse
    {
        public int Id { get; set; }
        public string DispatchPoint { get; set; }
        public string Receiver { get; set; }
        public string ContactPhone { get; set; }
        public string DeliveryPerson { get; set; }
        public List<LcWaikikiOrderProduct>? Products { get; set; }
        public DateTime OrderDate { get; set; }
    }
    
    public class  LcWaikikiOrderProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
