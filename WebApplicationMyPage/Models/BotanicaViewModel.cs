using System.Text.Json;
using WebApplicationMyPage.Data;

namespace WebApplicationMyPage.Models
{
    public class BotanicaViewModel
    {
        private const string fileNamePlants = "plants.json";
        private const string fileNamePages = "pagesOfPlants.json";

        public List<PageOfPlants> PagesOfPlants { get; set; } = new List<PageOfPlants>();
        public List<Plant> Plants { get; set; } = new List<Plant>();
        
        public BotanicaViewModel() 
        {
            if (Plants.Count > 0) return; //Заплатка. Этот код вызывается регулярно
            FileStream openStream = File.OpenRead(fileNamePages);
            PagesOfPlants=JsonSerializer.Deserialize<List<PageOfPlants>>(openStream);
            openStream = File.OpenRead(fileNamePlants);
            Plants = JsonSerializer.Deserialize<List<Plant>>(openStream);

            Plants.ForEach(p => { PagesOfPlants?.Find(page => page.Page == p.Page)?.Plants.Add(p); });
        }

    }
}
