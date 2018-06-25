using Lykke.Service.Sequence.Sign.Core.Services;
using Lykke.Service.Sequence.Sign.Models;
using Lykke.Service.Sequence.Sign.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lykke.Service.Sequence.Sign.Controllers
{
    [Route("api/sign")]
    public class SignController : Controller
    {
        private readonly ISequenceService _sequenceService;

        public SignController(ISequenceService sequenceService)
        {
            _sequenceService = sequenceService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(SignResponse), (int)HttpStatusCode.OK)]
        public IActionResult SignTransaction([FromBody]SignTransactionRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.ToErrorResponse());
            }

            var hex = _sequenceService.SignTransaction(request.Tx, request.Coins, request.Keys);

            return Ok(new SignResponse()
            {
                SignedTransaction = hex
            });
        }        
    }
}
