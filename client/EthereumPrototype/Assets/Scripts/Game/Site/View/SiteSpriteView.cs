using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteSpriteView
    {
        void UpdateSprite(Vector2 size, Color color);
    }


    public class SiteSpriteView : ISiteSpriteView
    {
        private SpriteRenderer spriteRenderer = null;

        public SiteSpriteView(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }

        public void UpdateSprite(Vector2 size, Color color)
        {
            var scaleZ = spriteRenderer.transform.localScale.z;
            spriteRenderer.transform.localScale = new Vector3(size.x, size.y, scaleZ);
            spriteRenderer.color = color;
        }
    }
}
