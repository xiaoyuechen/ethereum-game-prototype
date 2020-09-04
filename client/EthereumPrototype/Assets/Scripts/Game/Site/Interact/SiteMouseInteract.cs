using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EthereumPrototype.Game.Site
{
    public class SiteMouseInteract : MonoBehaviour
    {
        private ISiteController siteController = null;

        private void Start()
        {
            siteController = GetComponentInParent<ISiteController>();
        }

        private void OnMouseEnter()
        {
            siteController.UpdateMessages();
            siteController.ShowMessages();
        }

        private void OnMouseExit()
        {
            siteController.HideMessages();
        }
    }
}