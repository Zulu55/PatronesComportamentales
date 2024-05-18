using Command;

internal class Program
{
    private static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        CommandManager commandManager = new CommandManager();

        while (true)
        {
            Console.WriteLine("\nGestión de Tareas:");
            taskManager.ShowTasks();
            Console.WriteLine("\nIngrese un comando (añadir [tarea], completar [tarea], deshacer, rehacer, salir):");
            string input = Console.ReadLine()!;
            string[] parts = input.Split(' ');

            if (parts[0] == "añadir")
            {
                string task = input.Substring(7);
                ICommand command = new AddTaskCommand(taskManager, task);
                commandManager.ExecuteCommand(command);
            }
            else if (parts[0] == "completar")
            {
                string task = input.Substring(10);
                ICommand command = new CompleteTaskCommand(taskManager, task);
                commandManager.ExecuteCommand(command);
            }
            else if (parts[0] == "deshacer")
            {
                commandManager.Undo();
            }
            else if (parts[0] == "rehacer")
            {
                commandManager.Redo();
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