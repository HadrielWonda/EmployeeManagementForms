namespace Baumax.ServerState
{
    public interface IServerStateService
    {
        bool CanInteract
        { get;}

        bool ServerReady
        { get; set;}

        ServerStateData GetState();
    }
}
