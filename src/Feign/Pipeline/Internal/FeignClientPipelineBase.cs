﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feign.Pipeline.Internal
{
    internal class FeignClientPipelineBase<TService> : IFeignClientPipeline<TService>
    {
        public virtual bool Enabled { get; set; } = true;

        private readonly List<BuildingRequestDelegate<TService>> _buildingRequestMiddlewares = new List<BuildingRequestDelegate<TService>>();
        private readonly List<CancelRequestDelegate<TService>> _cancelRequestMiddlewares = new List<CancelRequestDelegate<TService>>();
        private readonly List<DisposingDelegate<TService>> _disposingMiddlewares = new List<DisposingDelegate<TService>>();
        private readonly List<ErrorRequestDelegate<TService>> _errorRequestMiddlewares = new List<ErrorRequestDelegate<TService>>();
        private readonly List<FallbackRequestDelegate<TService>> _fallbackRequestMiddlewares = new List<FallbackRequestDelegate<TService>>();
        private readonly List<InitializingDelegate<TService>> _initializingMiddlewares = new List<InitializingDelegate<TService>>();
        private readonly List<ReceivingResponseDelegate<TService>> _receivingResponseMiddlewares = new List<ReceivingResponseDelegate<TService>>();
        private readonly List<ReceivedResponseDelegate<TService>> _receivedResponseMiddlewares = new List<ReceivedResponseDelegate<TService>>();
        private readonly List<SendingRequestDelegate<TService>> _sendingRequestMiddlewares = new List<SendingRequestDelegate<TService>>();

        public IFeignClientPipeline<TService> UseBuildingRequest(BuildingRequestDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _buildingRequestMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseCancelRequest(CancelRequestDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _cancelRequestMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseDisposing(DisposingDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _disposingMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseErrorRequest(ErrorRequestDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _errorRequestMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseFallbackRequest(FallbackRequestDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _fallbackRequestMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseInitializing(InitializingDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _initializingMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseReceivingResponse(ReceivingResponseDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _receivingResponseMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseReceivedResponse(ReceivedResponseDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _receivedResponseMiddlewares.Add(middleware);
            }
            return this;
        }

        public IFeignClientPipeline<TService> UseSendingRequest(SendingRequestDelegate<TService> middleware)
        {
            if (middleware != null)
            {
                _sendingRequestMiddlewares.Add(middleware);
            }
            return this;
        }

        protected internal virtual async Task BuildingRequestAsync(IBuildingRequestPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_buildingRequestMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _buildingRequestMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual async Task SendingRequestAsync(ISendingRequestPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_sendingRequestMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _sendingRequestMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual async Task CancelRequestAsync(ICancelRequestPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_buildingRequestMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _cancelRequestMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual async Task ErrorRequestAsync(IErrorRequestPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_errorRequestMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _errorRequestMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual async Task ReceivingResponseAsync(IReceivingResponsePipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_receivingResponseMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _receivingResponseMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual async Task ReceivedResponseAsync(IReceivedResponsePipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_receivedResponseMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _receivedResponseMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }
        protected internal virtual void Initializing(IInitializingPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_initializingMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _initializingMiddlewares)
            {
                middleware.Invoke(context);
            }
        }
        protected internal virtual void Disposing(IDisposingPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_disposingMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _disposingMiddlewares)
            {
                middleware.Invoke(context);
            }
        }
        protected internal virtual async Task FallbackRequestAsync(IFallbackRequestPipelineContext<TService> context)
        {
            if (!Enabled)
            {
                return;
            }
            if (_fallbackRequestMiddlewares.Count == 0)
            {
                return;
            }
            foreach (var middleware in _fallbackRequestMiddlewares)
            {
                await middleware.Invoke(context).ConfigureAwait(false);
            }
        }

    }
}
