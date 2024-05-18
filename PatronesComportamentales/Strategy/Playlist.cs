namespace Strategy
{
    public class Playlist
    {
        public string Name { get; }
        private List<Song> _songs = [];
        private ISortStrategy _sortStrategy;

        public Playlist(string name)
        {
            Name = name;
        }

        public void AddSong(Song song)
        {
            _songs.Add(song);
            Console.WriteLine($"Añadido a {Name}: {song}");
        }

        public void RemoveSong(string title)
        {
            var song = _songs.Find(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (song != null)
            {
                _songs.Remove(song);
                Console.WriteLine($"Eliminado de {Name}: {song}");
            }
            else
            {
                Console.WriteLine($"La canción {title} no está en la lista de reproducción {Name}.");
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

        public void ShowPlaylist()
        {
            Console.WriteLine($"\nLista de Reproducción: {Name}");
            foreach (var song in _songs)
            {
                Console.WriteLine($"- {song}");
            }
        }
    }
}