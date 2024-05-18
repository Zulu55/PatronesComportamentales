namespace Command
{
    public class CompleteTaskCommand : ICommand
    {
        private TaskManager _taskManager;
        private string _task;

        public CompleteTaskCommand(TaskManager taskManager, string task)
        {
            _taskManager = taskManager;
            _task = task;
        }

        public void Execute()
        {
            _taskManager.CompleteTask(_task);
        }

        public void Unexecute()
        {
            _taskManager.UndoCompleteTask(_task);
        }
    }
}