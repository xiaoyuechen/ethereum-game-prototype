// SPDX-License-Identifier: MIT
pragma solidity 0.7.0;

library Math {
    struct Vector2 {
        int32 x;
        int32 y;
    }
    
    function abs(int32 x) internal pure returns (int32) {
        int32 absolute = x < 0 ? -x : x;
        return absolute;
    }
}
