public class Metadata{
        public string Site { get; set; }
        public int NumLinks { get; set; }
        public int Images { get; set; }
        public DateTime LastFetch { get; set; }

        public override string ToString()
        {
            return $"site: {Site}, {Environment.NewLine}num_links: {NumLinks}, {Environment.NewLine}images: {Images}, {Environment.NewLine}last_fetch: {LastFetch.ToUniversalTime().ToString("ddd MMM dd yyyy HH:mm")} UTC";
        }
}