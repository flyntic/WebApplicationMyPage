namespace WebApplicationMyPage.Data
{
    public class PageOfPlants
    {
        
        public int Id { get; set; }
        private static int _id=0;
        public string Title { get; set; }
        public string Description { get; set; }
        public string Page { get;set; }
        public List<Plant> Plants { get; set; } = new List<Plant>();

        public PageOfPlants() { Id = _id++; }
    }
}
