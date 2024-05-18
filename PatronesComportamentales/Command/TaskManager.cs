namespace Command
{
    public class TaskManager
    {
        private List<string> _tasks = [];
        private List<string> _completedTasks = [];

        public void AddTask(string task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(string task)
        {
            _tasks.Remove(task);
        }

        public void CompleteTask(string task)
        {
            if (_tasks.Contains(task))
            {
                _tasks.Remove(task);
                _completedTasks.Add(task);
            }
        }

        public void UndoCompleteTask(string task)
        {
            if (_completedTasks.Contains(task))
            {
                _completedTasks.Remove(task);
                _tasks.Add(task);
            }
        }

        public void ShowTasks()
        {
            Console.WriteLine("Tareas Pendientes:");
            foreach (var task in _tasks)
            {
                Console.WriteLine($"- {task}");
            }

            Console.WriteLine("\nTareas Completadas:");
            foreach (var task in _completedTasks)
            {
                Console.WriteLine($"- {task}");
            }
        }
    }
}