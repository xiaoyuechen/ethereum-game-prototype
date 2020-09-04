using UnityEngine;
using TMPro;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteFactory
    {
        ISiteController BuildSite(int index, ISiteStorage siteStorage);
    }


    public class SiteFactory : ISiteFactory
    {
        private GameObject sitePrefab = null;

        public SiteFactory(GameObject sitePrefab)
        {
            this.sitePrefab = sitePrefab;
        }

        public ISiteController BuildSite(int index, ISiteStorage siteStorage)
        {
            var site = GameObject.Instantiate(sitePrefab);
            var controller = site.GetComponent<ISiteController>();
            controller.Init(
                new SiteModel(index, siteStorage),
                BuildSiteView(site));
            controller.HideMessages();
            return controller;
        }

        static private ISiteNameView BuildSiteNameView(GameObject site)
        {
            var tag = site.GetComponentInChildren<SiteNameTextTag>();
            var comp = tag.GetComponent<TextMeshPro>();
            return new SiteNameView(comp);
        }

        static private ISiteSpriteView BuildSiteSpriteView(GameObject site)
        {
            var tag = site.GetComponentInChildren<SiteSpriteTag>();
            var comp = tag.GetComponent<SpriteRenderer>();
            return new SiteSpriteView(comp);
        }

        static private ISiteMessageView BuildSiteMessageView(GameObject site)
        {
            var tag = site.GetComponentInChildren<SiteMessageTextTag>();
            var comp = tag.GetComponent<TextMeshPro>();
            return new SiteMessageView(comp);
        }

        static private ISiteView BuildSiteView(GameObject site)
        {
            return new SiteView(
                site.transform, 
                BuildSiteNameView(site),
                BuildSiteSpriteView(site),
                BuildSiteMessageView(site));
        }
    }
}
