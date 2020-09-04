using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using EthereumPrototype.ContractAPI.SiteStorage;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteStorage
    {
        Site GetSite(int idx);
        int GetSiteCount();
        IEnumerator Pull();
        void AddPullCompleteEventListener(UnityAction call);
        void RemovePullCompleteEventListener(UnityAction call);
    }


    public class SiteStorage : ISiteStorage
    {
        private Site[] sites = null;
        private GetAllSitesQuery getAllSitesQuery = new GetAllSitesQuery { };
        private UnityEvent pullCompleteEvent = new UnityEvent { };

        public Site GetSite(int idx)
        {
            return sites[idx];
        }

        public int GetSiteCount()
        {
            return sites.Length;
        }
        public IEnumerator Pull()
        {
            var context = new QueryContext
            {
                url = NetContext.url,
                account = NetContext.account,
                contractAddress = NetContext.siteStorageAddress,
            };
            yield return getAllSitesQuery.Query(context);
            sites = getAllSitesQuery.Sites;
            pullCompleteEvent.Invoke();
        }

        public void AddPullCompleteEventListener(UnityAction call)
        {
            pullCompleteEvent.AddListener(call);
        }

        public void RemovePullCompleteEventListener(UnityAction call)
        {
            pullCompleteEvent.RemoveListener(call);
        }
    }
}
