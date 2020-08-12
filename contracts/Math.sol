pragma solidity 0.7.0;

library Math {
    struct Vector2 {
        int x;
        int y;
    }
    
    function abs(int x) internal pure returns (int) {
        int absolute = x < 0 ? -x : x;
        return absolute;
    }
}
