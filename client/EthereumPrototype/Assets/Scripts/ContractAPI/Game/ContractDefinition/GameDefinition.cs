using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace EthereumPrototype.ContractAPI.Game.ContractDefinition
{


    public partial class GameDeployment : GameDeploymentBase
    {
        public GameDeployment() : base(BYTECODE) { }
        public GameDeployment(string byteCode) : base(byteCode) { }
    }

    public class GameDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea2646970667358221220824359d188977a97f9bae7c7e053d8344ca5e0680dc8104dbf4ed855ac7b706a64736f6c63430007000033";
        public GameDeploymentBase() : base(BYTECODE) { }
        public GameDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
