namespace Strategy
{
    public class SortByArtist : ISortStrategy
    {
        public void Sort(List<Song> songs)
        {
            songs.Sort((x, y) => x.Artist.CompareTo(y.Artist));
            Console.WriteLine("Canciones ordenadas por artista.");
        }
    }
}