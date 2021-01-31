using RedPlus.Models;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RedPlus.Services
{
    public class PortfolioServiceJsonFile
    {
        public IEnumerable<Portfolio> GetPortfolios()
        {
            var jsonFileName = @"C:\Razor\RedPlus.RazorPages\RedPlus\wwwroot\Portfolios\portfolios.json";

            using (var jsonFileReader = File.OpenText(jsonFileName))
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var portfolios = JsonSerializer.Deserialize<Portfolio[]>(jsonFileReader.ReadToEnd(), options);
                return portfolios;
            }
        }
    }
}
