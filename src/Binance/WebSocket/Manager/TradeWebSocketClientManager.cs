﻿using System;
using Binance.Client;
using Binance.Manager;
using Microsoft.Extensions.Logging;

namespace Binance.WebSocket.Manager
{
    /// <summary>
    /// The default <see cref="ITradeWebSocketClientManager"/> implementation.
    /// </summary>
    public class TradeWebSocketClientManager : TradeClientManager<IWebSocketStream>, ITradeWebSocketClientManager
    {
        #region Public Events

        public event EventHandler<ErrorEventArgs> Error
        {
            add => Controller.Error += value;
            remove => Controller.Error -= value;
        }

        #endregion Public Events

        #region Constructors

        /// <summary>
        /// Default constructor provides default <see cref="ITradeClient"/>
        /// and default <see cref="IWebSocketStream"/>, but no logger.
        /// </summary>
        public TradeWebSocketClientManager()
            : this(new TradeClient(), new BinanceWebSocketStreamController())
        { }

        /// <summary>
        /// The DI constructor.
        /// </summary>
        /// <param name="client">The JSON client (required).</param>
        /// <param name="controller">The web socket stream controller (required).</param>
        /// <param name="logger">The logger (optional).</param>
        public TradeWebSocketClientManager(ITradeClient client, IWebSocketStreamController controller, ILogger<TradeWebSocketClientManager> logger = null)
            : base(client, controller, logger)
        { }

        #endregion Construtors
    }
}
