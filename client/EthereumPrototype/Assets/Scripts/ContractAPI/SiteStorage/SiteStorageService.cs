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
using EthereumPrototype.ContractAPI.SiteStorage.ContractDefinition;

namespace EthereumPrototype.ContractAPI.SiteStorage
{
    public partial class SiteStorageService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SiteStorageDeployment siteStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SiteStorageDeployment>().SendRequestAndWaitForReceiptAsync(siteStorageDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SiteStorageDeployment siteStorageDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SiteStorageDeployment>().SendRequestAsync(siteStorageDeployment);
        }

        public static async Task<SiteStorageService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SiteStorageDeployment siteStorageDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, siteStorageDeployment, cancellationTokenSource);
            return new SiteStorageService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SiteStorageService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> AddSiteRequestAsync(AddSiteFunction addSiteFunction)
        {
             return ContractHandler.SendRequestAsync(addSiteFunction);
        }

        public Task<TransactionReceipt> AddSiteRequestAndWaitForReceiptAsync(AddSiteFunction addSiteFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiteFunction, cancellationToken);
        }

        public Task<string> AddSiteRequestAsync(int posX, int posY, int sizeX, int sizeY)
        {
            var addSiteFunction = new AddSiteFunction();
                addSiteFunction.PosX = posX;
                addSiteFunction.PosY = posY;
                addSiteFunction.SizeX = sizeX;
                addSiteFunction.SizeY = sizeY;
            
             return ContractHandler.SendRequestAsync(addSiteFunction);
        }

        public Task<TransactionReceipt> AddSiteRequestAndWaitForReceiptAsync(int posX, int posY, int sizeX, int sizeY, CancellationTokenSource cancellationToken = null)
        {
            var addSiteFunction = new AddSiteFunction();
                addSiteFunction.PosX = posX;
                addSiteFunction.PosY = posY;
                addSiteFunction.SizeX = sizeX;
                addSiteFunction.SizeY = sizeY;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiteFunction, cancellationToken);
        }

        public Task<string> AddSiteMessageRequestAsync(AddSiteMessageFunction addSiteMessageFunction)
        {
             return ContractHandler.SendRequestAsync(addSiteMessageFunction);
        }

        public Task<TransactionReceipt> AddSiteMessageRequestAndWaitForReceiptAsync(AddSiteMessageFunction addSiteMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiteMessageFunction, cancellationToken);
        }

        public Task<string> AddSiteMessageRequestAsync(BigInteger index, string message)
        {
            var addSiteMessageFunction = new AddSiteMessageFunction();
                addSiteMessageFunction.Index = index;
                addSiteMessageFunction.Message = message;
            
             return ContractHandler.SendRequestAsync(addSiteMessageFunction);
        }

        public Task<TransactionReceipt> AddSiteMessageRequestAndWaitForReceiptAsync(BigInteger index, string message, CancellationTokenSource cancellationToken = null)
        {
            var addSiteMessageFunction = new AddSiteMessageFunction();
                addSiteMessageFunction.Index = index;
                addSiteMessageFunction.Message = message;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSiteMessageFunction, cancellationToken);
        }

        public Task<uint> GetSiteColorQueryAsync(GetSiteColorFunction getSiteColorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteColorFunction, uint>(getSiteColorFunction, blockParameter);
        }

        
        public Task<uint> GetSiteColorQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getSiteColorFunction = new GetSiteColorFunction();
                getSiteColorFunction.Index = index;
            
            return ContractHandler.QueryAsync<GetSiteColorFunction, uint>(getSiteColorFunction, blockParameter);
        }

        public Task<BigInteger> GetSiteCountQueryAsync(GetSiteCountFunction getSiteCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteCountFunction, BigInteger>(getSiteCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetSiteCountQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteCountFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> GetSiteMessageQueryAsync(GetSiteMessageFunction getSiteMessageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteMessageFunction, string>(getSiteMessageFunction, blockParameter);
        }

        
        public Task<string> GetSiteMessageQueryAsync(BigInteger siteIndex, BigInteger msgIndex, BlockParameter blockParameter = null)
        {
            var getSiteMessageFunction = new GetSiteMessageFunction();
                getSiteMessageFunction.SiteIndex = siteIndex;
                getSiteMessageFunction.MsgIndex = msgIndex;
            
            return ContractHandler.QueryAsync<GetSiteMessageFunction, string>(getSiteMessageFunction, blockParameter);
        }

        public Task<BigInteger> GetSiteMessageCountQueryAsync(GetSiteMessageCountFunction getSiteMessageCountFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteMessageCountFunction, BigInteger>(getSiteMessageCountFunction, blockParameter);
        }

        
        public Task<BigInteger> GetSiteMessageCountQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getSiteMessageCountFunction = new GetSiteMessageCountFunction();
                getSiteMessageCountFunction.Index = index;
            
            return ContractHandler.QueryAsync<GetSiteMessageCountFunction, BigInteger>(getSiteMessageCountFunction, blockParameter);
        }

        public Task<string> GetSiteNameQueryAsync(GetSiteNameFunction getSiteNameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetSiteNameFunction, string>(getSiteNameFunction, blockParameter);
        }

        
        public Task<string> GetSiteNameQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getSiteNameFunction = new GetSiteNameFunction();
                getSiteNameFunction.Index = index;
            
            return ContractHandler.QueryAsync<GetSiteNameFunction, string>(getSiteNameFunction, blockParameter);
        }

        public Task<GetSitePositionOutputDTO> GetSitePositionQueryAsync(GetSitePositionFunction getSitePositionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSitePositionFunction, GetSitePositionOutputDTO>(getSitePositionFunction, blockParameter);
        }

        public Task<GetSitePositionOutputDTO> GetSitePositionQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getSitePositionFunction = new GetSitePositionFunction();
                getSitePositionFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSitePositionFunction, GetSitePositionOutputDTO>(getSitePositionFunction, blockParameter);
        }

        public Task<GetSiteSizeOutputDTO> GetSiteSizeQueryAsync(GetSiteSizeFunction getSiteSizeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetSiteSizeFunction, GetSiteSizeOutputDTO>(getSiteSizeFunction, blockParameter);
        }

        public Task<GetSiteSizeOutputDTO> GetSiteSizeQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getSiteSizeFunction = new GetSiteSizeFunction();
                getSiteSizeFunction.Index = index;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetSiteSizeFunction, GetSiteSizeOutputDTO>(getSiteSizeFunction, blockParameter);
        }

        public Task<string> SetSiteColorRequestAsync(SetSiteColorFunction setSiteColorFunction)
        {
             return ContractHandler.SendRequestAsync(setSiteColorFunction);
        }

        public Task<TransactionReceipt> SetSiteColorRequestAndWaitForReceiptAsync(SetSiteColorFunction setSiteColorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSiteColorFunction, cancellationToken);
        }

        public Task<string> SetSiteColorRequestAsync(BigInteger index, uint color)
        {
            var setSiteColorFunction = new SetSiteColorFunction();
                setSiteColorFunction.Index = index;
                setSiteColorFunction.Color = color;
            
             return ContractHandler.SendRequestAsync(setSiteColorFunction);
        }

        public Task<TransactionReceipt> SetSiteColorRequestAndWaitForReceiptAsync(BigInteger index, uint color, CancellationTokenSource cancellationToken = null)
        {
            var setSiteColorFunction = new SetSiteColorFunction();
                setSiteColorFunction.Index = index;
                setSiteColorFunction.Color = color;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSiteColorFunction, cancellationToken);
        }

        public Task<string> SetSiteNameRequestAsync(SetSiteNameFunction setSiteNameFunction)
        {
             return ContractHandler.SendRequestAsync(setSiteNameFunction);
        }

        public Task<TransactionReceipt> SetSiteNameRequestAndWaitForReceiptAsync(SetSiteNameFunction setSiteNameFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSiteNameFunction, cancellationToken);
        }

        public Task<string> SetSiteNameRequestAsync(BigInteger index, string name)
        {
            var setSiteNameFunction = new SetSiteNameFunction();
                setSiteNameFunction.Index = index;
                setSiteNameFunction.Name = name;
            
             return ContractHandler.SendRequestAsync(setSiteNameFunction);
        }

        public Task<TransactionReceipt> SetSiteNameRequestAndWaitForReceiptAsync(BigInteger index, string name, CancellationTokenSource cancellationToken = null)
        {
            var setSiteNameFunction = new SetSiteNameFunction();
                setSiteNameFunction.Index = index;
                setSiteNameFunction.Name = name;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setSiteNameFunction, cancellationToken);
        }
    }
}
