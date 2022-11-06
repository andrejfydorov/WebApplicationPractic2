namespace WebApplicationPractic2.Models
{
    public static class MemoryDb
    {
        public static List<Band> Bands { get; set; } = new()
         {
         new Band { Id = 1, Name = "Beatles", Year = 1960, Country = "England" },
         new Band { Id = 2, Name = "Genesis", Country = "England" },
         new Band { Id = 3, Name = "ABBA", Year = 1974, Country = "Sweden" },
         new Band { Id = 4, Name = "Sonic Youth", Year = 1990, Country = "USA" },
         };

    }
}
