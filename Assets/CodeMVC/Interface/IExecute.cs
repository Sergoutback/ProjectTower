namespace CodeMVC.Interface
{
    public interface IExecute : IController
    {
        void Execute(float deltaTime);
    }
}
