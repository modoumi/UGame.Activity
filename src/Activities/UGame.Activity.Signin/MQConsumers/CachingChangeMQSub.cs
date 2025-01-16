//using UGame.Activity.Signin.Caching;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx.Extensions.RabbitMQ;
//using Xxyy.Common.MQ;
//using Xxyy.MQ.Admin;

//namespace UGame.Activity.Signin.MQConsumers
//{

//    /// <summary>
//    /// 清理内存缓存消费端
//    /// </summary>
//    public class CachingChangeMQSub : XxyySubConsumer<CachingChangeMsg>
//    {
//        public override MQSubscribeMode SubscribeMode => MQSubscribeMode.Multicast;

//        public CachingChangeMQSub()
//        {
//            RegisterAction(ClearCaching);
//        }
//        private async Task ClearCaching(CachingChangeMsg message, CancellationToken cancellationToken)
//        {
//            if (message == null)
//                return;

//            if (message.TableName.StartsWith("sa_"))
//                SigninDCacheUtil.Clear();
//        }

//    }

//}
