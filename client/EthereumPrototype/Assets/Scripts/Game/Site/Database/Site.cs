using UnityEngine;
using System;

namespace EthereumPrototype.Game.Site
{
    public struct Site
    {
        public string name;
        public Vector2 position;
        public SiteGraphicsComponent graphicsComponent;
        public SiteMessageComponent messageComponent;
    }


    public struct SiteGraphicsComponent
    {
        public Vector2 size;
        public Color color;
    }


    public struct SiteMessageComponent
    {
        public string[] messages;
    }

}
