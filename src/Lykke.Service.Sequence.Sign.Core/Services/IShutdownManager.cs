using System.Threading.Tasks;

namespace Lykke.Service.Sequence.Sign.Core.Services
{
    public interface IShutdownManager
    {
        Task StopAsync();
    }
}