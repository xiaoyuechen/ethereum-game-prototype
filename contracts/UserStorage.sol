pragma solidity 0.7.0;

import "Game.sol";

contract UserStorage {
    address admin;
    mapping(address => Game.User) userMap;
    address[] usersAddress;
    
    function addUser(bytes32 username) public {
        require(username != "", "username must not be empty");
        Game.User storage user = userMap[msg.sender];
        require(user.username == "", "address already registered");
        user.username = username;
        usersAddress.push(msg.sender);
    }
    
    function getUser() public view returns (bytes32 username) {
        return userMap[msg.sender].username;
    }
}
