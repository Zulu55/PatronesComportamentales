namespace Observer
{
    public class Playlist : ISubject
    {
        private string _name;
        private List<string> _songs = [];
        private List<IObserver> _observers = [];

        public Playlist(string name)
        {
            _name = name;
        }

        public string Name { get => _name; set { _name = value; } }

        public void AddSong(string song)
        {
            _songs.Add(song);
            Notify($"Añadido a {_name}: {song}");
        }

        public void RemoveSong(string song)
        {
            if (_songs.Remove(song))
            {
                Notify($"Eliminado de {_name}: {song}");
            }
            else
            {
                Console.WriteLine($"La canción {song} no está en la lista de reproducción {_name}.");
            }
        }

        public void ShowPlaylist()
        {
            Console.WriteLine($"\nLista de Reproducción: {_name}");
            foreach (var song in _songs)
            {
                Console.WriteLine($"- {song}");
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }
}