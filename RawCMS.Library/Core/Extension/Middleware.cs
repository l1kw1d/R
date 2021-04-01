﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using RawCMS.Library.Core.Interfaces;
using System.Threading.Tasks;

namespace RawCMS.Library.Core.Extension
{
    public abstract class Middleware<T> : IConfigurableMiddleware<T>
    {
        public RequestDelegate next { get; private set; }
        public ILogger logger { get; private set; }
        public T pluginConfig { get; private set; }

        public Middleware(RequestDelegate requestDelegate, ILogger logger, T config)
        {
            this.next = requestDelegate;
            this.logger = logger;
            this.pluginConfig = config;
        }

        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract Task InvokeAsync(HttpContext context);
    }
}