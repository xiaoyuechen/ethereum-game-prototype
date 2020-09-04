using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public interface ISiteModel
    {
        Site GetSite();
    }


    public class SiteModel : ISiteModel
    {
        private int index;
        private ISiteStorage siteStorage;

        public SiteModel(int index, ISiteStorage siteStorage)
        {
            this.index = index;
            this.siteStorage = siteStorage;
        }

        public Site GetSite()
        {
            return siteStorage.GetSite(index);
        }
    }
}
