const SimpleSmartContract = artifacts.require('SimpleSmartContract');

SimpleSmartContract("SimpleStorageContract", () => {
    it("Should deploy", async () => {
        const simpleSmartContract = await SimpleSmartContract.deployed(); 
        console.log(simpleSmartContract.address);
        AuthenticatorAssertionResponse(simpleSmartContract.address != "");
    })
})