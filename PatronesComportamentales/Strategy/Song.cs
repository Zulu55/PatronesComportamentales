namespace Strategy
{
    public class Song
    {
        public string Title { get; }
        public int Duration { get; }
        public string Artist { get; }

        public Song(string title, int duration, string artist)
        {
            Title = title;
            Duration = duration;
            Artist = artist;
        }

        public override string ToString()
        {
            return $"{Title} por {Artist} ({Duration} segundos)";
        }
    }
}