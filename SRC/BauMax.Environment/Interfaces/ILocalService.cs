using System.IO;

namespace Baumax.Environment.Interfaces
{
    public interface ILocalService
    {
    }
    
    public interface IStreamingService
    {
        void SaveToStream(Stream stream);
        void RestoreFromStream(Stream stream);
    }
}
