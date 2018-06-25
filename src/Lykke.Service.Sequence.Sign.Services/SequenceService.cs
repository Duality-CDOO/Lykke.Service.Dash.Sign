﻿using Common.Log;
using Lykke.Service.Sequence.Sign.Core.Services;
using NBitcoin;
using NBitcoin.Sequence;
using NBitcoin.Policy;
using System;
using System.Linq;

namespace Lykke.Service.Sequence.Sign.Services
{
    public class SequenceService : ISequenceService
    {
        private readonly ILog _log;
        private readonly Network _network;

        public SequenceService(ILog log,
            string network)
        {
            SequenceNetworks.Register();

            _log = log;
            _network = Network.GetNetwork(network);
        }

        public bool IsValidPrivateKey(string privateKey)
        {
            try
            {
                Key.Parse(privateKey, _network);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public string GetPrivateKey()
        {
            var key = new Key();

            return key.GetWif(_network).ToString();
        }

        public string GetPublicAddress(string privateKey)
        {
            var wallet = new BitcoinSecret(privateKey);

            return wallet.PubKey.GetAddress(_network).ToString();
        }

        public string SignTransaction(Transaction tx, ICoin[] coins, Key[] keys)
        {
            var builder = new TransactionBuilder().AddCoins(coins).AddKeys(keys);

            var signed = builder.SignTransaction(tx);

            if (!builder
                .SetTransactionPolicy(new StandardTransactionPolicy { CheckFee = false })
                .Verify(signed, out var errors))
            {
                throw new InvalidOperationException($"Invalid transaction sign: {string.Join("; ", errors.Select(e => e.ToString()))}");
            }

            return signed.ToHex();
        }
    }
}
