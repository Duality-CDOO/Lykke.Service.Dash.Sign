using Lykke.Service.Sequence.Sign.Core.Services;
using Lykke.Service.Sequence.Sign.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lykke.Service.Sequence.Sign.Controllers
{
    [Route("api/wallets")]
    public class WalletsController : Controller
    {
        private readonly ISequenceService _sequenceService;

        public WalletsController(ISequenceService sequenceService)
        {
            _sequenceService = sequenceService;
        }

        [HttpPost]
        public WalletResponse Post()
        {
            var privateKey = _sequenceService.GetPrivateKey();
            var publicAddress = _sequenceService.GetPublicAddress(privateKey);

            return new WalletResponse()
            {
                PrivateKey = privateKey,
                PublicAddress = publicAddress
            };
        }
    }
}
