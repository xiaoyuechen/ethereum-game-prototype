using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteController
    {
        void Init(ISiteModel model, ISiteView view);
        void UpdateThumbnail();
        void UpdateMessages();
        void ShowMessages();
        void HideMessages();
    }


    public class SiteController : MonoBehaviour, ISiteController
    {
        private ISiteModel siteModel = null;
        private ISiteView siteView = null;

        public void Init(ISiteModel model, ISiteView view)
        {
            siteModel = model;
            siteView = view;
        }

        public void UpdateThumbnail()
        {
            var site = siteModel.GetSite();
            var siteThumbnail = new SiteThumbnail
            {
                name = site.name,
                position = site.position,
                size = site.graphicsComponent.size,
                color = site.graphicsComponent.color,
            };
            siteView.UpdateThumbnail(siteThumbnail);
        }

        public void UpdateMessages()
        {
            var site = siteModel.GetSite();
            siteView.UpdateMessages(site.messageComponent.messages);
        }

        public void ShowMessages()
        {
            siteView.ShowMessages();
        }

        public void HideMessages()
        {
            siteView.HideMessages();
        }
    }
}