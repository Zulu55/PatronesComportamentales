using Observer;

internal class Program
{
    static void Main(string[] args)
    {
        MusicLibrary library = new();
        List<Playlist> playlists = [];

        User user1 = new User("Usuario 1");
        User user2 = new User("Usuario 2");

        library.Attach(user1);
        library.Attach(user2);

        while (true)
        {
            Console.WriteLine("\nGestión de Biblioteca de Música:");
            library.ShowLibrary();
            Console.WriteLine("\nListas de Reproducción:");
            foreach (var playlist in playlists)
            {
                playlist.ShowPlaylist();
            }
            Console.WriteLine("\nIngrese un comando (añadir [canción], eliminar [canción], crear_lista [nombre], añadir_lista [nombre_lista] [canción], eliminar_lista [nombre_lista] [canción], suscribir [nombre], desuscribir [nombre], salir):");
            string input = Console.ReadLine()!;
            string[] parts = input.Split(' ');

            if (parts[0] == "añadir")
            {
                string song = input.Substring(7);
                library.AddSong(song);
            }
            else if (parts[0] == "eliminar")
            {
                string song = input.Substring(9); 
                library.RemoveSong(song);
            }
            else if (parts[0] == "crear_lista")
            {
                string name = input.Substring(12); 
                Playlist newPlaylist = new Playlist(name);
                playlists.Add(newPlaylist);
                newPlaylist.Attach(user1);
                newPlaylist.Attach(user2);
                Console.WriteLine($"Lista de reproducción {name} creada.");
            }
            else if (parts[0] == "añadir_lista")
            {
                string playlistName = parts[1];
                string song = input.Substring(14 + playlistName.Length); 
                Playlist playlist = playlists.Find(p => p.Name == playlistName);
                if (playlist != null)
                {
                    playlist.AddSong(song);
                }
                else
                {
                    Console.WriteLine($"La lista de reproducción {playlistName} no existe.");
                }
            }
            else if (parts[0] == "eliminar_lista")
            {
                string playlistName = parts[1];
                string song = input.Substring(16 + playlistName.Length); 
                Playlist playlist = playlists.Find(p => p.Name == playlistName);
                if (playlist != null)
                {
                    playlist.RemoveSong(song);
                }
                else
                {
                    Console.WriteLine($"La lista de reproducción {playlistName} no existe.");
                }
            }
            else if (parts[0] == "suscribir")
            {
                string name = input.Substring(10);
                User newUser = new User(name);
                library.Attach(newUser);
                foreach (var playlist in playlists)
                {
                    playlist.Attach(newUser);
                }
                Console.WriteLine($"{name} se ha suscrito a las notificaciones.");
            }
            else if (parts[0] == "desuscribir")
            {
                string name = input.Substring(12);
                User userToRemove = null;
                foreach (var observer in library.GetType().GetField("_observers", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(library) as List<IObserver>)
                {
                    if ((observer as User).Name == name)
                    {
                        userToRemove = observer as User;
                        break;
                    }
                }

                if (userToRemove != null)
                {
                    library.Detach(userToRemove);
                    foreach (var playlist in playlists)
                    {
                        playlist.Detach(userToRemove);
                    }
                    Console.WriteLine($"{name} se ha desuscrito de las notificaciones.");
                }
                else
                {
                    Console.WriteLine($"El usuario {name} no está suscrito.");
                }
            }
            else if (parts[0] == "salir")
            {
                break;
            }
            else
            {
                Console.WriteLine("Comando no reconocido.");
            }
        }
    }
}