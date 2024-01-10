using Microsoft.AspNetCore.SignalR;

namespace RealEstate_Dapper_Api.Hubs
{

    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendKategoriSayisi()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7067/api/Categories/CategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            // ViewBag.categorySayisi = jsonData; burada ViewBag kullanılamaza
            await Clients.All.SendAsync("KategoriSayisiniGonder", jsonData);

            
        }
    }

}

// NOTLAR
/*
 * - buradaki KategoriSayisiniGonder ile yukarıdaki metot adı olan SendKategoriSayisi aynı olmak zorunda değil 
 * - Talep edilen yerde önce yukarıdaki metoda (SendKategoriSayisi) ulaşılacak, oradan jsonData2 ile getirilen verilere ulaşılacak Yani metot dağıtıcı modem gibi davranacak             
 */