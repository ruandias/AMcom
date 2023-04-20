public partial class Program
{
    public class Data
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<MatchData> data { get; set; }
    }

}