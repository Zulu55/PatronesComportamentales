namespace Observer
{
    public class MusicLibrary : ISubject
    {
        private List<string> _songs = [];
        private List<IObserver> _observers = [];

        public void AddSong(string song)
        {
            _songs.Add(song);
            Notify($"Añadido: {song}");
        }

        public void RemoveSong(string song)
        {
            if (_songs.Remove(song))
            {
                Notify($"Eliminado: {song}");
            }
            else
            {
                Console.WriteLine($"La canción {song} no está en la biblioteca.");
            }
        }

        public void ShowLibrary()
        {
            Console.WriteLine("\nBiblioteca de Música:");
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