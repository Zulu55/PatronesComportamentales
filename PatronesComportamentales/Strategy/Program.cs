using Strategy;

internal class Program
{
    static void Main(string[] args)
    {
        MusicLibrary library = new MusicLibrary();
        List<Playlist> playlists = new List<Playlist>();

        while (true)
        {
            Console.WriteLine("\nGestión de Biblioteca de Música:");
            library.ShowLibrary();
            Console.WriteLine("\nListas de Reproducción:");
            foreach (var playlist in playlists)
            {
                playlist.ShowPlaylist();
            }
            Console.WriteLine("\nIngrese un comando (añadir [título] [duración] [artista], eliminar [título], crear_lista [nombre], añadir_lista [nombre_lista] [título], eliminar_lista [nombre_lista] [título], ordenar_biblioteca [titulo|duracion|artista], ordenar_lista [nombre_lista] [titulo|duracion|artista], salir):");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ');

            if (parts[0] == "añadir")
            {
                string title = parts[1];
                int duration;
                if (int.TryParse(parts[2], out duration))
                {
                    string artist = input.Substring(11 + parts[1].Length + parts[2].Length);
                    Song song = new Song(title, duration, artist);
                    library.AddSong(song);
                }
                else
                {
                    Console.WriteLine("Duración no válida.");
                }
            }
            else if (parts[0] == "eliminar")
            {
                string title = input.Substring(9); // Obtener el título después del comando 'eliminar '
                library.RemoveSong(title);
            }
            else if (parts[0] == "crear_lista")
            {
                string name = input.Substring(12); // Obtener el nombre de la lista de reproducción después del comando 'crear_lista '
                Playlist newPlaylist = new Playlist(name);
                playlists.Add(newPlaylist);
                Console.WriteLine($"Lista de reproducción {name} creada.");
            }
            else if (parts[0] == "añadir_lista")
            {
                string playlistName = parts[1];
                string title = input.Substring(14 + playlistName.Length); // Obtener el título después del comando 'añadir_lista [nombre_lista] '
                var song = library.Songs.Find(s => s.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                if (song != null)
                {
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
                else
                {
                    Console.WriteLine($"La canción {title} no está en la biblioteca.");
                }
            }
            else if (parts[0] == "eliminar_lista")
            {
                string playlistName = parts[1];
                string title = input.Substring(16 + playlistName.Length); // Obtener el título después del comando 'eliminar_lista [nombre_lista] '
                Playlist playlist = playlists.Find(p => p.Name == playlistName);
                if (playlist != null)
                {
                    playlist.RemoveSong(title);
                }
                else
                {
                    Console.WriteLine($"La lista de reproducción {playlistName} no existe.");
                }
            }
            else if (parts[0] == "ordenar_biblioteca")
            {
                string criteria = parts[1];
                ISortStrategy strategy = criteria switch
                {
                    "titulo" => new SortByTitle(),
                    "duracion" => new SortByDuration(),
                    "artista" => new SortByArtist(),
                    _ => null
                };
                if (strategy != null)
                {
                    library.SetSortStrategy(strategy);
                    library.SortSongs();
                }
                else
                {
                    Console.WriteLine("Criterio de ordenamiento no válido.");
                }
            }
            else if (parts[0] == "ordenar_lista")
            {
                string playlistName = parts[1];
                string criteria = parts[2];
                ISortStrategy strategy = criteria switch
                {
                    "titulo" => new SortByTitle(),
                    "duracion" => new SortByDuration(),
                    "artista" => new SortByArtist(),
                    _ => null
                };
                if (strategy != null)
                {
                    Playlist playlist = playlists.Find(p => p.Name == playlistName);
                    if (playlist != null)
                    {
                        playlist.SetSortStrategy(strategy);
                        playlist.SortSongs();
                    }
                    else
                    {
                        Console.WriteLine($"La lista de reproducción {playlistName} no existe.");
                    }
                }
                else
                {
                    Console.WriteLine("Criterio de ordenamiento no válido.");
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