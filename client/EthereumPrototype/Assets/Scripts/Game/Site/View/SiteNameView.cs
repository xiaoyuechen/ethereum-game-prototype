using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteNameView
    {
        void UpdateText(string name);
    }


    public class SiteNameView : ISiteNameView
    {
        private TextMeshPro nameText = null;

        public SiteNameView(TextMeshPro nameText)
        {
            this.nameText = nameText;
        }

        public void UpdateText(string name)
        {
            nameText.SetText(name);
        }
    }
}