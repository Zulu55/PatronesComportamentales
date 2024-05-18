namespace Strategy
{
    public class MusicLibrary
    {
        private List<Song> _songs = [];
        private ISortStrategy _sortStrategy;

        public void AddSong(Song song)
        {
            _songs.Add(song);
            Console.WriteLine($"Añadido: {song}");
        }

        public List<Song> Songs
        {
            get => _songs;
            set { _songs = value; }
        }

        public void RemoveSong(string title)
        {
            var song = _songs.Find(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                _songs.Remove(song);
                Console.WriteLine($"Eliminado: {song}");
            }
            else
            {
                Console.WriteLine($"La canción {title} no está en la biblioteca.");
            }
        }

        public void SetSortStrategy(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void SortSongs()
        {
            _sortStrategy.Sort(_songs);
        }

        public void ShowLibrary()
        {
            Console.WriteLine("\nBiblioteca de Música:");
            foreach (var song in _songs)
            {
                Console.WriteLine($"- {song}");
            }
        }
    }
}