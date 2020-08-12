pragma solidity >=0.4.22 <0.7.0;

import "Game.sol";

contract SiteStorage {
    address admin;
    Game.Site[] sites;
    
    constructor() public {
        admin = msg.sender;
    }
    
    function getSite(uint index) public view returns (int posX, int posY) {
        Game.Site storage site = sites[index];
        return (site.position.x, site.position.y);
    }
    
    function getSites() public view returns (int[] memory posXs, int[] memory posYs) {
        uint count = sites.length;
        posXs = new int[](count);
        posYs = new int[](count);
        for (uint i = 0; i != count; ++i) {
            (int posX, int posY) = getSite(i);
            posXs[i] = posX;
            posYs[i] = posY;
        }
        return (posXs, posYs);
    }
    
    function addSite(int posX, int posY) public {
        require(msg.sender == admin, "only admin can add site");
        Math.Vector2 memory pos = Math.Vector2(posX, posY);
        Game.Site memory site = Game.Site(pos);
        sites.push(site);
    }
    
    function addSites(int[] memory posXs, int[] memory posYs) public {
        require(msg.sender == admin, "only admin can add site");
        for (uint i = 0; i != posXs.length; ++i) {
            addSite(posXs[i], posYs[i]);
        }
    }
}
