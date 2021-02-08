using Microsoft.AspNetCore.Hosting;
using RedPlus.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RedPlus.Services
{
    public class PortfolioServiceJsonFile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PortfolioServiceJsonFile(IWebHostEnvironment webHostEnvironment)
        {
            this._webHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName 
        {
            get
            {
                //return _webHostEnvironment.WebRootPath + "\\Portfolios" + "\\portfolios.json";
                return Path.Combine(_webHostEnvironment.WebRootPath, "Portfolios", "portfolios.json");
            }
        }

        public IEnumerable<Portfolio> GetPortfolios()
        {
            //var jsonFileName = @"C:\Razor\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return portfolios;
            }
        }

        public void AddRating(int portfolioId, int rating)
        {
            var portfolios = GetPortfolios();

            if (portfolios.First(p => p.Id == portfolioId).Ratings == null)
            {
                portfolios.First(p => p.Id == portfolioId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = portfolios.First(p => p.Id == portfolioId).Ratings.ToList();
                ratings.Add(rating);
                portfolios.First(p => p.Id == portfolioId).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);
            JsonSerializer.Serialize<IEnumerable<Portfolio>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions 
                { 
                    SkipValidation = true, Indented = true  
                }), portfolios);
        }
    }
}
