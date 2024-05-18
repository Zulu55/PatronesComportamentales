namespace Strategy
{
    public class SortByTitle : ISortStrategy
    {
        public void Sort(List<Song> songs)
        {
            songs.Sort((x, y) => x.Title.CompareTo(y.Title));
            Console.WriteLine("Canciones ordenadas por título.");
        }
    }
}