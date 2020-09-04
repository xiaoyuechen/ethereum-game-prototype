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
using EthereumPrototype.ContractAPI.TravelSystem.ContractDefinition;

namespace EthereumPrototype.ContractAPI.TravelSystem
{
    public partial class TravelSystemService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TravelSystemDeployment travelSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TravelSystemDeployment>().SendRequestAndWaitForReceiptAsync(travelSystemDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TravelSystemDeployment travelSystemDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TravelSystemDeployment>().SendRequestAsync(travelSystemDeployment);
        }

        public static async Task<TravelSystemService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TravelSystemDeployment travelSystemDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, travelSystemDeployment, cancellationTokenSource);
            return new TravelSystemService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TravelSystemService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DepatureRequestAsync(DepatureFunction depatureFunction)
        {
             return ContractHandler.SendRequestAsync(depatureFunction);
        }

        public Task<TransactionReceipt> DepatureRequestAndWaitForReceiptAsync(DepatureFunction depatureFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depatureFunction, cancellationToken);
        }

        public Task<string> DepatureRequestAsync(byte[] vehicleId, BigInteger destinationX, BigInteger destinationY, BigInteger depatureTime, BigInteger speed)
        {
            var depatureFunction = new DepatureFunction();
                depatureFunction.VehicleId = vehicleId;
                depatureFunction.DestinationX = destinationX;
                depatureFunction.DestinationY = destinationY;
                depatureFunction.DepatureTime = depatureTime;
                depatureFunction.Speed = speed;
            
             return ContractHandler.SendRequestAsync(depatureFunction);
        }

        public Task<TransactionReceipt> DepatureRequestAndWaitForReceiptAsync(byte[] vehicleId, BigInteger destinationX, BigInteger destinationY, BigInteger depatureTime, BigInteger speed, CancellationTokenSource cancellationToken = null)
        {
            var depatureFunction = new DepatureFunction();
                depatureFunction.VehicleId = vehicleId;
                depatureFunction.DestinationX = destinationX;
                depatureFunction.DestinationY = destinationY;
                depatureFunction.DepatureTime = depatureTime;
                depatureFunction.Speed = speed;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(depatureFunction, cancellationToken);
        }

        public Task<GetPositionOutputDTO> GetPositionQueryAsync(GetPositionFunction getPositionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPositionFunction, GetPositionOutputDTO>(getPositionFunction, blockParameter);
        }

        public Task<GetPositionOutputDTO> GetPositionQueryAsync(byte[] vehicleId, BigInteger time, BlockParameter blockParameter = null)
        {
            var getPositionFunction = new GetPositionFunction();
                getPositionFunction.VehicleId = vehicleId;
                getPositionFunction.Time = time;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPositionFunction, GetPositionOutputDTO>(getPositionFunction, blockParameter);
        }

        public Task<string> StationRequestAsync(StationFunction stationFunction)
        {
             return ContractHandler.SendRequestAsync(stationFunction);
        }

        public Task<TransactionReceipt> StationRequestAndWaitForReceiptAsync(StationFunction stationFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stationFunction, cancellationToken);
        }

        public Task<string> StationRequestAsync(byte[] vehicleId, BigInteger time)
        {
            var stationFunction = new StationFunction();
                stationFunction.VehicleId = vehicleId;
                stationFunction.Time = time;
            
             return ContractHandler.SendRequestAsync(stationFunction);
        }

        public Task<TransactionReceipt> StationRequestAndWaitForReceiptAsync(byte[] vehicleId, BigInteger time, CancellationTokenSource cancellationToken = null)
        {
            var stationFunction = new StationFunction();
                stationFunction.VehicleId = vehicleId;
                stationFunction.Time = time;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stationFunction, cancellationToken);
        }
    }
}
