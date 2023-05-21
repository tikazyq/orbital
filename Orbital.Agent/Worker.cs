namespace Orbital.API;

public class Worker : IDisposable
{
    public string CurrentState;

    public Worker()
    {
        CurrentState = "Idle";
    }

    public void Start()
    {
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}