﻿//===========================================================
//CopyRight (c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//===========================================================

using Microsoft.Extensions.Logging;
using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<ILoggingBroker> logger;

        public LoggingBroker(ILogger<ILoggingBroker> logger) =>
            this.logger = logger;


        public void LogError(Exception exception) =>
            this.logger.LogError(exception,exception.Message);

        public void LogCritical(Exception exception) =>
            this.logger.LogCritical(exception,exception.Message);
    }
}
