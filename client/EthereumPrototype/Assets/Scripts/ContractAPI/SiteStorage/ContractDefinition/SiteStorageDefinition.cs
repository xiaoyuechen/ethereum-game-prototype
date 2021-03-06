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

namespace EthereumPrototype.ContractAPI.SiteStorage.ContractDefinition
{


    public partial class SiteStorageDeployment : SiteStorageDeploymentBase
    {
        public SiteStorageDeployment() : base(BYTECODE) { }
        public SiteStorageDeployment(string byteCode) : base(byteCode) { }
    }

    public class SiteStorageDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50600080546001600160a01b03191633179055610b85806100326000396000f3fe608060405234801561001057600080fd5b50600436106100a95760003560e01c80639bd93881116100715780639bd9388114610201578063bddc1fa714610276578063d19609b6146102eb578063e5ef413114610308578063eb34929114610342578063f12fa03e14610378576100a9565b80631750b531146100ae578063503ae27e146100e457806375edc53f1461010f5780638391f6e81461014f5780638adae75614610169575b600080fd5b6100cb600480360360208110156100c457600080fd5b5035610395565b6040805163ffffffff9092168252519081900360200190f35b61010d600480360360408110156100fa57600080fd5b508035906020013563ffffffff166103cd565b005b61012c6004803603602081101561012557600080fd5b5035610416565b604051808360030b81526020018260030b81526020019250505060405180910390f35b610157610454565b60408051918252519081900360200190f35b61018c6004803603604081101561017f57600080fd5b508035906020013561045a565b6040805160208082528351818301528351919283929083019185019080838360005b838110156101c65781810151838201526020016101ae565b50505050905090810190601f1680156101f35780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b61010d6004803603604081101561021757600080fd5b81359190810190604081016020820135600160201b81111561023857600080fd5b82018360208201111561024a57600080fd5b803590602001918460018302840111600160201b8311171561026b57600080fd5b509092509050610529565b61010d6004803603604081101561028c57600080fd5b81359190810190604081016020820135600160201b8111156102ad57600080fd5b8201836020820111156102bf57600080fd5b803590602001918460018302840111600160201b831117156102e057600080fd5b50909250905061057c565b61018c6004803603602081101561030157600080fd5b50356105bf565b61010d6004803603608081101561031e57600080fd5b508035600390810b916020810135820b916040820135810b9160600135900b61066d565b61035f6004803603602081101561035857600080fd5b50356108a1565b6040805192835260208301919091528051918290030190f35b6101576004803603602081101561038e57600080fd5b50356108e3565b600080600183815481106103a557fe5b6000918252602090912060049091020160020154600160401b900463ffffffff169392505050565b6000600183815481106103dc57fe5b60009182526020909120600260049092020101805463ffffffff909316600160401b0263ffffffff60401b19909316929092179091555050565b60008060006001848154811061042857fe5b6000918252602090912060026004909202010154600381810b96600160201b909204900b945092505050565b60015490565b606060006001848154811061046b57fe5b9060005260206000209060040201600301905080600001838154811061048d57fe5b600091825260209182902001805460408051601f600260001961010060018716150201909416939093049283018590048502810185019091528181529283018282801561051b5780601f106104f05761010080835404028352916020019161051b565b820191906000526020600020905b8154815290600101906020018083116104fe57829003601f168201915b505050505091505092915050565b60006001848154811061053857fe5b600091825260209091206004909102018054909150600260001961010060018416150201909116041561056a57600080fd5b61057581848461090e565b5050505050565b60006001848154811061058b57fe5b600091825260208083206003600490930201919091018054600181018255818452919092209192506105759101848461090e565b6060600182815481106105ce57fe5b6000918252602091829020600490910201805460408051601f60026000196101006001871615020190941693909304928301859004850281018501909152818152928301828280156106615780601f1061063657610100808354040283529160200191610661565b820191906000526020600020905b81548152906001019060200180831161064457829003601f168201915b50505050509050919050565b6000546001600160a01b031633146106cc576040805162461bcd60e51b815260206004820152601760248201527f6f6e6c792061646d696e2063616e206164642073697465000000000000000000604482015290519081900360640190fd5b6106d461098c565b60405180604001604052808660030b81526020018560030b81525090506106f96109a3565b506040805160608082018352600386810b835285900b60208084019190915263ffffffff83850152835160008082529181019094529192909161074c565b60608152602001906001900390816107375790505b5090506107576109c3565b50604080516020810190915281815261076e6109d6565b506040805160a08101825260006080820181815282526020808301889052928201869052606082018490526001805480820182559152815180519293849360049093027fb10e2d527612073b26eecdfd717e6a320cf44b4afac2b0732d9fcbe2b7fa0cf601926107e19284920190610a0f565b5060208281015180516001840180549284015163ffffffff19938416600393840b63ffffffff9081169190911767ffffffff0000000019908116600160201b93860b8316840217909355604080890151805160028a018054838b015193909401519390981690870b84161790941693850b82169092029290921763ffffffff60401b1916600160401b91909216021790915560608401518051805191939285019261089192849290910190610a7d565b5050505050505050505050505050565b6000806000600184815481106108b357fe5b6000918252602090912060016004909202010154600381810b810b96600160201b909204810b900b945092505050565b600080600183815481106108f357fe5b60009182526020909120600360049092020101549392505050565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061094f5782800160ff1982351617855561097c565b8280016001018555821561097c579182015b8281111561097c578235825591602001919060010190610961565b50610988929150610ad6565b5090565b604080518082019091526000808252602082015290565b604080516060810182526000808252602082018190529181019190915290565b6040518060200160405280606081525090565b6040518060800160405280606081526020016109f061098c565b81526020016109fd6109a3565b8152602001610a0a6109c3565b905290565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f10610a5057805160ff191683800117855561097c565b8280016001018555821561097c579182015b8281111561097c578251825591602001919060010190610a62565b828054828255906000526020600020908101928215610aca579160200282015b82811115610aca5782518051610aba918491602090910190610a0f565b5091602001919060010190610a9d565b50610988929150610aeb565b5b808211156109885760008155600101610ad7565b80821115610988576000610aff8282610b08565b50600101610aeb565b50805460018160011615610100020316600290046000825580601f10610b2e5750610b4c565b601f016020900490600052602060002090810190610b4c9190610ad6565b5056fea26469706673582212202647c3ee1f5a446bd487b11ef81bad71327bc94dd1df59bccdc8a0f3d667541264736f6c63430007000033";
        public SiteStorageDeploymentBase() : base(BYTECODE) { }
        public SiteStorageDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddSiteFunction : AddSiteFunctionBase { }

    [Function("addSite")]
    public class AddSiteFunctionBase : FunctionMessage
    {
        [Parameter("int32", "posX", 1)]
        public virtual int PosX { get; set; }
        [Parameter("int32", "posY", 2)]
        public virtual int PosY { get; set; }
        [Parameter("int32", "sizeX", 3)]
        public virtual int SizeX { get; set; }
        [Parameter("int32", "sizeY", 4)]
        public virtual int SizeY { get; set; }
    }

    public partial class AddSiteMessageFunction : AddSiteMessageFunctionBase { }

    [Function("addSiteMessage")]
    public class AddSiteMessageFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
        [Parameter("string", "message", 2)]
        public virtual string Message { get; set; }
    }

    public partial class GetSiteColorFunction : GetSiteColorFunctionBase { }

    [Function("getSiteColor", "uint32")]
    public class GetSiteColorFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class GetSiteCountFunction : GetSiteCountFunctionBase { }

    [Function("getSiteCount", "uint256")]
    public class GetSiteCountFunctionBase : FunctionMessage
    {

    }

    public partial class GetSiteMessageFunction : GetSiteMessageFunctionBase { }

    [Function("getSiteMessage", "string")]
    public class GetSiteMessageFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "siteIndex", 1)]
        public virtual BigInteger SiteIndex { get; set; }
        [Parameter("uint256", "msgIndex", 2)]
        public virtual BigInteger MsgIndex { get; set; }
    }

    public partial class GetSiteMessageCountFunction : GetSiteMessageCountFunctionBase { }

    [Function("getSiteMessageCount", "uint256")]
    public class GetSiteMessageCountFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class GetSiteNameFunction : GetSiteNameFunctionBase { }

    [Function("getSiteName", "string")]
    public class GetSiteNameFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class GetSitePositionFunction : GetSitePositionFunctionBase { }

    [Function("getSitePosition", typeof(GetSitePositionOutputDTO))]
    public class GetSitePositionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class GetSiteSizeFunction : GetSiteSizeFunctionBase { }

    [Function("getSiteSize", typeof(GetSiteSizeOutputDTO))]
    public class GetSiteSizeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class SetSiteColorFunction : SetSiteColorFunctionBase { }

    [Function("setSiteColor")]
    public class SetSiteColorFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
        [Parameter("uint32", "color", 2)]
        public virtual uint Color { get; set; }
    }

    public partial class SetSiteNameFunction : SetSiteNameFunctionBase { }

    [Function("setSiteName")]
    public class SetSiteNameFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
        [Parameter("string", "name", 2)]
        public virtual string Name { get; set; }
    }





    public partial class GetSiteColorOutputDTO : GetSiteColorOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteColorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "color", 1)]
        public virtual uint Color { get; set; }
    }

    public partial class GetSiteCountOutputDTO : GetSiteCountOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "count", 1)]
        public virtual BigInteger Count { get; set; }
    }

    public partial class GetSiteMessageOutputDTO : GetSiteMessageOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteMessageOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "message", 1)]
        public virtual string Message { get; set; }
    }

    public partial class GetSiteMessageCountOutputDTO : GetSiteMessageCountOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteMessageCountOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "count", 1)]
        public virtual BigInteger Count { get; set; }
    }

    public partial class GetSiteNameOutputDTO : GetSiteNameOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteNameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
    }

    public partial class GetSitePositionOutputDTO : GetSitePositionOutputDTOBase { }

    [FunctionOutput]
    public class GetSitePositionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int256", "posX", 1)]
        public virtual BigInteger PosX { get; set; }
        [Parameter("int256", "posY", 2)]
        public virtual BigInteger PosY { get; set; }
    }

    public partial class GetSiteSizeOutputDTO : GetSiteSizeOutputDTOBase { }

    [FunctionOutput]
    public class GetSiteSizeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("int32", "sizeX", 1)]
        public virtual int SizeX { get; set; }
        [Parameter("int32", "sizeY", 2)]
        public virtual int SizeY { get; set; }
    }




}
