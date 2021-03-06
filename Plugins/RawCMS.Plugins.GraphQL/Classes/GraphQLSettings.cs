//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Http;
using System;

namespace RawCMS.Plugins.GraphQL.Classes
{
    public class GraphQLSettings
    {
        public GraphQLSettings()
        {
            Path = "/api/graphql";
            EnableMetrics = false;
            GraphiQLPath = "/graphql";
        }

        public string Path { get; set; }

        public string GraphiQLPath { get; set; }

        public Func<HttpContext, object> BuildUserContext { get; set; }

        public bool EnableMetrics { get; set; }
    }
}