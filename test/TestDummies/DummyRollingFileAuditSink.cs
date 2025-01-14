﻿using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;

namespace TestDummies
{
    public class DummyRollingFileAuditSink : ILogEventSink
    {
        [ThreadStatic]
        static List<LogEvent> _emitted;

        public static List<LogEvent> Emitted => _emitted ?? (_emitted = new List<LogEvent>());

        public void Emit(LogEvent logEvent)
        {
            Emitted.Add(logEvent);
        }

        public static void Reset()
        {
            _emitted = null;
        }
    }
}
