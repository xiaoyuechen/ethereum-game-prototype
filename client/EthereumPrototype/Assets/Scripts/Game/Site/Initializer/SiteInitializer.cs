using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public class SiteInitializer : MonoBehaviour
    {
        [SerializeField]
        private GameObject sitePrefab = null;
        [SerializeField]
        private float networkPullInterval = 5.0f;

        private SiteStorage siteStorage = null;
        private SiteFactory siteFactory = null;
        private SiteManager siteManager = null;

        private void Start()
        {
            siteStorage = new SiteStorage();
            siteFactory = new SiteFactory(sitePrefab);
            siteManager = new SiteManager(siteFactory, siteStorage);
            StartCoroutine(PullSiteStorage());
        }

        private IEnumerator PullSiteStorage()
        {
            while (true)
            {
                yield return siteStorage.Pull();
                yield return new WaitForSeconds(networkPullInterval);
            }
        }
    }
}