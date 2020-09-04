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

namespace EthereumPrototype.ContractAPI.Site.ContractDefinition
{


    public partial class SiteDeployment : SiteDeploymentBase
    {
        public SiteDeployment() : base(BYTECODE) { }
        public SiteDeployment(string byteCode) : base(byteCode) { }
    }

    public class SiteDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60566023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea2646970667358221220692760fc9374e95043d22bab65b39cb3a7153ba8d5d14bddb61e3235e19db5b364736f6c63430007000033";
        public SiteDeploymentBase() : base(BYTECODE) { }
        public SiteDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
