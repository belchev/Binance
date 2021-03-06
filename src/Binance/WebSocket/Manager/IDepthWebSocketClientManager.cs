﻿using System;
using Binance.Manager;

namespace Binance.WebSocket.Manager
{
    /// <summary>
    /// A depth web socket client manager.
    /// </summary>
    public interface IDepthWebSocketClientManager : IDepthClientManager<IWebSocketStream>, IWebSocketControllerManager
    {
        /// <summary>
        /// The controller error event.
        /// </summary>
        event EventHandler<ErrorEventArgs> Error;
    }
}
