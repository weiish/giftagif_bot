using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GiftAGIfBot.Services
{
    public class PictureService
    {
        private readonly HttpClient _http;
        public PictureService(HttpClient http)
            => _http = http;

        public async Task<Stream> GetCatPictureAsync() {
            var resp = await _http.GetAsync("https://cataas.com/cat");
            return await resp.Content.ReadAsStreamAsync();
        }

    }
}
