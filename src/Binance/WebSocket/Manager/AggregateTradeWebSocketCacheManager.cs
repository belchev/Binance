﻿using System;
using Binance.Api;
using Binance.Cache;
using Binance.Manager;
using Binance.Utility;
using Microsoft.Extensions.Logging;

namespace Binance.WebSocket.Manager
{
    /// <summary>
    /// The default <see cref="IAggregateTradeWebSocketCacheManager"/> implementation.
    /// </summary>
    public class AggregateTradeWebSocketCacheManager : AggregateTradeCache, IAggregateTradeWebSocketCacheManager
    {
        #region Public Events

        public event EventHandler<ErrorEventArgs> Error
        {
            add => _manager.Controller.Error += value;
            remove => _manager.Controller.Error -= value;
        }

        #endregion Public Events

        #region Public Properties

        public IJsonStreamController<IWebSocketStream> Controller => _manager.Controller;

        public IWatchdogTimer Watchdog => _manager.Watchdog;

        #endregion Public Properties

        #region Private Fields

        private readonly IAggregateTradeWebSocketClientManager _manager;

        #endregion Private Fields

        #region Constructors

        /// <summary>
        /// Default constructor provides default <see cref="IBinanceApi"/>
        /// and default <see cref="IAggregateTradeWebSocketClientManager"/>, but no logger.
        /// </summary>
        public AggregateTradeWebSocketCacheManager()
            : this(new BinanceApi(), new AggregateTradeWebSocketClientManager())
        { }

        /// <summary>
        /// The DI constructor.
        /// </summary>
        /// <param name="api">The Binance API (required).</param>
        /// <param name="manager">The web socket client manager (required).</param>
        /// <param name="logger">The logger (optional).</param>
        public AggregateTradeWebSocketCacheManager(IBinanceApi api, IAggregateTradeWebSocketClientManager manager, ILogger<AggregateTradeWebSocketCacheManager> logger = null)
            : base(api, manager, logger) // use manager as client.
        {
            Throw.IfNull(manager, nameof(manager));

            _manager = manager;
        }

        #endregion Construtors

        #region IDisposable

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _manager?.Dispose();
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion IDisposable
    }
}
