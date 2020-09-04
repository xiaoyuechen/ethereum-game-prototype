using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteView
    {
        void UpdateThumbnail(SiteThumbnail siteThumbnail);
        void UpdateMessages(string[] messages);
        void ShowMessages();
        void HideMessages();
    }


    public struct SiteThumbnail : System.IEquatable<SiteThumbnail>
    {
        public string name;
        public Vector2 position;
        public Vector2 size;
        public Color color;

        public bool Equals(SiteThumbnail other)
        {
            return name == other.name
                && position == other.position
                && size == other.size
                && color == other.color;
        }
    }


    public class SiteView : ISiteView
    {
        private Transform rootTransform = null;
        private ISiteNameView nameView = null;
        private ISiteSpriteView spriteView = null;
        private ISiteMessageView messageView = null;
        // cache
        private SiteThumbnail siteThumbnail = new SiteThumbnail { };
        private string[] siteMessages = null;

        public SiteView(
            Transform rootTransform,
            ISiteNameView nameView,
            ISiteSpriteView spriteView,
            ISiteMessageView messageView)
        {
            this.rootTransform = rootTransform;
            this.nameView = nameView;
            this.spriteView = spriteView;
            this.messageView = messageView;
        }

        public void UpdateThumbnail(SiteThumbnail siteThumbnail)
        {
            if (this.siteThumbnail.Equals(siteThumbnail)) { return; }

            this.siteThumbnail = siteThumbnail;
            rootTransform.position = siteThumbnail.position;
            nameView.UpdateText(siteThumbnail.name);
            spriteView.UpdateSprite(
                siteThumbnail.size,
                siteThumbnail.color);
            // TODO (Xiaoyue): offset text views. 
        }

        public void UpdateMessages(string[] messages)
        {
            if (siteMessages != null
                && Enumerable.SequenceEqual(siteMessages, messages))
            {
                return;
            }

            siteMessages = messages;
            messageView.UpdateText(messages);
        }

        public void ShowMessages()
        {
            messageView.Show();
        }

        public void HideMessages()
        {
            messageView.Hide();
        }
    }
}