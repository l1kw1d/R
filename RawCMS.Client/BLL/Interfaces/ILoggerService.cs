//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using System;

namespace RawCMS.Client.BLL.Interfaces
{
    public interface ILoggerService
    {
        void SetPretty(bool pretty);

        void SetVerbose(bool verbose);

        void Info(string message);

        void Info(string message, object[] args);

        void Debug(string message);

        void Debug(string message, object[] args);

        void Warn(string message);

        void Warn(string message, object[] args);

        void Error(string message);

        void Error(string message, Exception e);

        void Trace(string message);

        void Trace(string message, object[] args);

        void Fatal(string message);

        void Fatal(string message, object[] args);

        void Response(string contentResponse);

        void Request(string contentRequest);
    }
}