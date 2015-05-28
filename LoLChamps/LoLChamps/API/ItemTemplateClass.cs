namespace LoLChamps.API
{
    public class Champion
    {
        public int id { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public Image image { get; set; }
        public string lore { get; set; }
    }

    public class Image
    {
        public string full { get; set; }
    }


    public class Champions
    {
        public ChampionId[] champions { get; set; }
    }

    public class ChampionId
    {
        public int id { get; set; }
    }

}
