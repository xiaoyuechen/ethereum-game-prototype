// SPDX-License-Identifier: MIT
pragma solidity 0.7.0;

import "./Game.sol";

contract SiteStorage {
    address admin;
    Game.Site[] sites;
    
    constructor() {
        admin = msg.sender;
    }

    function getSiteCount()
    public 
    view 
    returns (uint count) {
        count = sites.length;
    }

    function getSiteName(uint index) 
    public 
    view 
    returns (string memory name)
    {
        name = sites[index].name;
    }

    function getSitePosition(uint index) 
    public 
    view 
    returns (int posX, int posY) {
        Game.Site storage site = sites[index];
        posX = site.position.x;
        posY = site.position.y;
    }

    function getSiteSize(uint index)
    public 
    view 
    returns (int32 sizeX, int32 sizeY) {
        Game.SiteGraphicsComponent storage comp = sites[index].graphicsComponent;
        sizeX = comp.sizeX;
        sizeY = comp.sizeY;
    }

    function getSiteColor(uint index)
    public
    view
    returns (uint32 color) {
        Game.SiteGraphicsComponent storage comp = sites[index].graphicsComponent;
        color = comp.color;
    }

    function getSiteMessageCount(uint index) 
    public 
    view 
    returns (uint count)
    {
        Game.SiteMessageComponent storage comp = sites[index].messageComponent; 
        count = comp.messages.length;
    }

    function getSiteMessage(uint siteIndex, uint msgIndex) 
    public 
    view 
    returns (string memory message)
    {
        Game.SiteMessageComponent storage comp = sites[siteIndex].messageComponent; 
        message = comp.messages[msgIndex];
    }

    function addSite(int32 posX, int32 posY, int32 sizeX, int32 sizeY) public {
        require(msg.sender == admin, "only admin can add site");
        Math.Vector2 memory pos = Math.Vector2(posX, posY);
        Game.SiteGraphicsComponent memory graphicsComp = 
            Game.SiteGraphicsComponent(sizeX, sizeY, ~uint32(0));
        string[] memory messages = new string[](0);
        Game.SiteMessageComponent memory messageComp = Game.SiteMessageComponent(messages);
        Game.Site memory site = Game.Site("", pos, graphicsComp, messageComp);
        sites.push(site);
    }

    function setSiteName(uint index, string calldata name) public {
        Game.Site storage site = sites[index];
        require(bytes(site.name).length == 0);
        site.name = name;
    }

    function setSiteColor(uint index, uint32 color) public {
        Game.Site storage site = sites[index];
        site.graphicsComponent.color = color;
    }

    function addSiteMessage(uint index, string calldata message) public {
        Game.SiteMessageComponent storage comp = sites[index].messageComponent;
        comp.messages.push(message);
    }
}
