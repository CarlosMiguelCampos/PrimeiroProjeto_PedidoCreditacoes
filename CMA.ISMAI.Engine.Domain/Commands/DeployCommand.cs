﻿using CMA.ISMAI.Core.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CMA.ISMAI.Engine.Domain.Commands
{
    public abstract class DeployCommand : Command
    {
        public Guid Id { get; protected set; }
        public string WorkFlowName { get; set; }
        public string ProcessName { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public Assembly AssemblyName { get; set; }
    }
}
