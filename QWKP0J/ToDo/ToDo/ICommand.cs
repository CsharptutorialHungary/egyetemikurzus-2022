namespace ToDo
{
    internal interface ICommand
    {
        void Execute(IConsole console, string text);
    }
}
