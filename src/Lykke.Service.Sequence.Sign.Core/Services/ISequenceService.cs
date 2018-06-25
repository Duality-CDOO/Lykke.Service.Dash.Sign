using NBitcoin;

namespace Lykke.Service.Sequence.Sign.Core.Services
{
    public interface ISequenceService
    {
        bool IsValidPrivateKey(string privateKey);
        string GetPrivateKey();
        string GetPublicAddress(string privateKey);
        string SignTransaction(Transaction tx, ICoin[] coins, Key[] keys);
    }
}
