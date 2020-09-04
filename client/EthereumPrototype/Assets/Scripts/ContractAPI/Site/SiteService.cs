using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using EthereumPrototype.ContractAPI.Site.ContractDefinition;

namespace EthereumPrototype.ContractAPI.Site
{
    public partial class SiteService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SiteDeployment siteDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SiteDeployment>().SendRequestAndWaitForReceiptAsync(siteDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SiteDeployment siteDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SiteDeployment>().SendRequestAsync(siteDeployment);
        }

        public static async Task<SiteService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SiteDeployment siteDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, siteDeployment, cancellationTokenSource);
            return new SiteService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SiteService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
