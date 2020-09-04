using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteMessageView
    {
        void UpdateText(string[] messages);
        void Show();
        void Hide();
    }


    public class SiteMessageView : ISiteMessageView
    {
        private TextMeshPro msgText = null;
        private StringBuilder msgBuilder = new System.Text.StringBuilder { };

        public SiteMessageView(TextMeshPro msgText)
        {
            this.msgText = msgText;
        }

        public void UpdateText(string[] messages)
        {
            msgBuilder.Clear();

            for (int i = 0; i != messages.Length; ++i)
            {
                msgBuilder.Append((i + 1).ToString());
                msgBuilder.Append(". ");
                msgBuilder.Append(messages[i]);
                msgBuilder.Append("\n");
            }

            msgText.SetText(msgBuilder.ToString());
        }

        public void Show()
        {
            msgText.enabled = true;
        }

        public void Hide()
        {
            msgText.enabled = false;
        }
    }
}
