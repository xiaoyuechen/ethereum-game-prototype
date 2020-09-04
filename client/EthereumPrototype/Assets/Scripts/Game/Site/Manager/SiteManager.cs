using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public class SiteManager
    {
        private ISiteFactory siteFactory = null;
        private ISiteStorage siteStorage = null;

        private List<ISiteController> sites = new List<ISiteController> { };

        public SiteManager(ISiteFactory siteFactory, ISiteStorage siteStorage)
        {
            this.siteFactory = siteFactory;
            this.siteStorage = siteStorage;
            siteStorage.AddPullCompleteEventListener(UpdateSites);
        }

        private void UpdateSites()
        {
            var networkCount = siteStorage.GetSiteCount();
            if (networkCount < sites.Count)
            {
                sites.RemoveRange(networkCount, sites.Count - networkCount);
            }
            else
            {
                for (int i = sites.Count; i != networkCount; ++i)
                {
                    sites.Add(siteFactory.BuildSite(i, siteStorage));
                }
            }

            foreach (var site in sites)
            {
                site.UpdateThumbnail();
                site.UpdateMessages();
            }
        }
    }
}