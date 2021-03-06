// SPDX-License-Identifier: MIT

pragma solidity 0.7.0;

import "./Math.sol";

library Game {
    
    struct MovementComponent {
        int32 maxSpeed;
    }
    
    enum TravelState {
        STATIONARY, 
        EN_ROUTE
    }
    
    struct TravelComponent { 
        TravelState state;
        Math.Vector2 origin;
        Math.Vector2 destination;
        uint depatureTime;
        int32 speed;
    }
    
    struct OwnershipComponent {
        address owner;
    }
    
    struct Vehicle {
        OwnershipComponent ownershipComponent;
        MovementComponent movementComponent;
        TravelComponent travelComponent;
    }
    
    struct User {
        bytes32 username;
        Vehicle[] Vehicles;
    }

    struct Site {
        string name;
        Math.Vector2 position;
        SiteGraphicsComponent graphicsComponent;
        SiteMessageComponent messageComponent;
    }
    
    struct SiteGraphicsComponent {
        int32 sizeX;
        int32 sizeY;
        uint32 color;
    }

    struct SiteMessageComponent {
        string[] messages;
    }
}