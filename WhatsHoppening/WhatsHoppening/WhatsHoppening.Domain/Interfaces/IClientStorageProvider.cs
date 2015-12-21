using WhatsHoppening.Domain.ClientStorage;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IClientStorageProvider
    {
        ReadClientStorageResposne Read(ReadClientStorageRequest readClientStorageRequest);
        void Write(WriteClientStorageRequest writeClientStorageRequest);
        void Clear(ClearClientStorageRequest clearClientStorageRequest);
    }
}
