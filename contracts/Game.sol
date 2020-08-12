pragma solidity 0.7.0;

import "Math.sol";

library Game {
    
    struct MovementComponent {
        int maxSpeed;
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
        int speed;
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
        Math.Vector2 position;
    }
    
}
