namespace Command
{
    public class AddTaskCommand : ICommand
    {
        private TaskManager _taskManager;
        private string _task;

        public AddTaskCommand(TaskManager taskManager, string task)
        {
            _taskManager = taskManager;
            _task = task;
        }

        public void Execute()
        {
            _taskManager.AddTask(_task);
        }

        public void Unexecute()
        {
            _taskManager.RemoveTask(_task);
        }
    }
}