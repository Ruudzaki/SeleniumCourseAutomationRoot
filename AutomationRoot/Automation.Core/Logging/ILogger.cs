﻿using System;

namespace Automation.Core.Logging
{
    interface ILogger
    {
        void Debug(string message);
        void Debug(string format, params object[] args);
        void Debug(Exception exception, string message);
    }
}
