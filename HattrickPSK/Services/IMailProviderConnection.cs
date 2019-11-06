namespace HattrickPSK.Services
{
    public interface IMailProviderConnection
    {
        bool TryConnect();
    }
}