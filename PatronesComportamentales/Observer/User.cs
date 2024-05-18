namespace Observer
{
    public class User : IObserver
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{Name} recibió la notificación: {message}");
        }
    }
}