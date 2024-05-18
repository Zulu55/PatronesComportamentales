namespace Strategy
{
    public class SortByDuration : ISortStrategy
    {
        public void Sort(List<Song> songs)
        {
            songs.Sort((x, y) => x.Duration.CompareTo(y.Duration));
            Console.WriteLine("Canciones ordenadas por duración.");
        }
    }
}