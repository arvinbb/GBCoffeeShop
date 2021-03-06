﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace GBBCoffeeShop.Common
{
    public class WCFServiceClientWrapper<ServiceType> : IDisposable
    {
        private ServiceType _channel;
        public ServiceType Channel
        {
            get { return _channel; }
        }

        private static ChannelFactory<ServiceType> _channelFactory;

        public WCFServiceClientWrapper()
        {
            if (_channelFactory == null)
                // Given that the endpoint name is the same as FullName of contract.
                _channelFactory = new ChannelFactory<ServiceType>(typeof(ServiceType).FullName);
            _channel = _channelFactory.CreateChannel();
            ((IChannel)_channel).Open();
        }

        public void Dispose()
        {
            try
            {
                ((IChannel)_channel).Close();
            }
            catch (Exception e)
            {
                ((IChannel)_channel).Abort();
                // TODO: Log the exception
            }
        }
    }
}
