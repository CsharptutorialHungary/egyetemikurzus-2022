namespace Commands
{
    internal interface ICommand
    {
        bool Execute(params object[] args);
    }
}
