using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Nethereum.JsonRpc.UnityClient;
using EthereumPrototype.ContractAPI.SiteStorage.ContractDefinition;

namespace EthereumPrototype.ContractAPI.SiteStorage
{
    public struct QueryContext
    {
        public string url;
        public string contractAddress;
        public string account;
    }


    public class GetSiteCountQuery
    {
        private int count;

        public int Count
        {
            get { return count; }
        }

        public IEnumerator Query(QueryContext context)
        {
            var request = new QueryUnityRequest<
                GetSiteCountFunction,
                GetSiteCountOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(context.contractAddress);
            count = (int)request.Result.Count;
        }
    }


    public class GetSiteNameQuery
    {
        private string name;

        public string Name
        {
            get { return name; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var request = new QueryUnityRequest<
                GetSiteNameFunction,
                GetSiteNameOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(
                new GetSiteNameFunction { Index = siteIndex },
                context.contractAddress);
            name = request.Result.Name;
        }
    }


    public class GetSitePositionQuery
    {
        public Vector2 position;

        public Vector2 Position
        {
            get { return position; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var request = new QueryUnityRequest<
                GetSitePositionFunction,
                GetSitePositionOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(
                new GetSitePositionFunction { Index = siteIndex },
                context.contractAddress);
            position = new Vector2(
                (float)request.Result.PosX,
                (float)request.Result.PosY);
        }
    }


    public class GetSiteSizeQuery
    {
        private Vector2 size;

        public Vector2 Size
        {
            get { return size; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var request = new QueryUnityRequest<
                GetSiteSizeFunction,
                GetSiteSizeOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(
                new GetSiteSizeFunction { Index = siteIndex },
                context.contractAddress);
            size = new Vector2(
                (float)request.Result.SizeX,
                (float)request.Result.SizeY);
        }
    }


    public class GetSiteColorQuery
    {
        private Color color;

        public Color Color
        {
            get { return color; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var request = new QueryUnityRequest<
                GetSiteColorFunction,
                GetSiteColorOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(
                new GetSiteColorFunction { Index = siteIndex },
                context.contractAddress);
            var colorRaw = request.Result.Color;
            color.b = (byte)((colorRaw) & 0xFF);
            color.g = (byte)((colorRaw >> 8) & 0xFF);
            color.r = (byte)((colorRaw >> 16) & 0xFF);
            color.a = (byte)((colorRaw >> 24) & 0xFF);
        }
    }


    public class GetSiteMessageCountQuery
    {
        private int count;

        public int Count
        {
            get { return count; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var request = new QueryUnityRequest<
                GetSiteMessageCountFunction,
                GetSiteMessageCountOutputDTO>(
                context.url,
                context.account);
            yield return request.Query(
                new GetSiteMessageCountFunction { Index = siteIndex },
                context.contractAddress);
            count = (int)request.Result.Count;
        }
    }


    public class GetSiteMessageQuery
    {
        private string message;

        public string Message
        {
            get { return message; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex, int msgIndex)
        {
            var request = new QueryUnityRequest<
                GetSiteMessageFunction,
                GetSiteMessageOutputDTO>(
                context.url,
                context.account);
            var func = new GetSiteMessageFunction
            {
                SiteIndex = siteIndex,
                MsgIndex = msgIndex,
            };
            yield return request.Query(func, context.contractAddress);
            message = request.Result.Message;
        }
    }


    public class GetSiteAllMessagesQuery
    {
        private List<string> messageList = new List<string> { };

        public string[] Messages { get { return messageList.ToArray(); } }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var getSiteMessageCount = new GetSiteMessageCountQuery { };
            yield return getSiteMessageCount.Query(context, siteIndex);
            messageList.Clear();
            for (int msgIndex = 0; msgIndex != getSiteMessageCount.Count; ++msgIndex)
            {
                var getSiteMessage = new GetSiteMessageQuery { };
                yield return getSiteMessage.Query(context, siteIndex, msgIndex);
                messageList.Add(getSiteMessage.Message);
            }
        }
    }

    public class GetSiteQuery
    {
        private EthereumPrototype.Game.Site.Site site =
            new EthereumPrototype.Game.Site.Site { };

        public EthereumPrototype.Game.Site.Site Site
        {
            get { return site; }
        }

        public IEnumerator Query(QueryContext context, int siteIndex)
        {
            var getSiteName = new GetSiteNameQuery { };
            yield return getSiteName.Query(context, siteIndex);
            site.name = getSiteName.Name;

            var getSitePosition = new GetSitePositionQuery { };
            yield return getSitePosition.Query(context, siteIndex);
            site.position = getSitePosition.position;

            var getSiteSize = new GetSiteSizeQuery { };
            yield return getSiteSize.Query(context, siteIndex);
            site.graphicsComponent.size = getSiteSize.Size;

            var getSiteColor = new GetSiteColorQuery { };
            yield return getSiteColor.Query(context, siteIndex);
            site.graphicsComponent.color = getSiteColor.Color;

            var getSiteAllMsgs = new GetSiteAllMessagesQuery { };
            yield return getSiteAllMsgs.Query(context, siteIndex);
            site.messageComponent.messages = getSiteAllMsgs.Messages;
        }
    }

    public class GetAllSitesQuery
    {
        private List<EthereumPrototype.Game.Site.Site> siteList =
            new List<EthereumPrototype.Game.Site.Site> { };

        public EthereumPrototype.Game.Site.Site[] Sites
        {
            get { return siteList.ToArray(); }
        }

        public IEnumerator Query(QueryContext context)
        {
            var getSiteCount = new GetSiteCountQuery { };
            yield return getSiteCount.Query(context);
            siteList.Clear();
            for (int siteIndex = 0; siteIndex != getSiteCount.Count; ++siteIndex)
            {
                var getSite = new GetSiteQuery { };
                yield return getSite.Query(context, siteIndex);
                siteList.Add(getSite.Site);
            }
        }
    }
}
