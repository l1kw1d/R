//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using RawCMS.Library.Core.Enum;
using RawCMS.Library.Service;
using System.Collections.Generic;

namespace RawCMS.Plugins.Core.Lambdas.CRUDSecurity
{
    public class ReadSecurity : GenericSecurity
    {
        public override string Name => nameof(ReadSecurity);
        public override PipelineStage Stage => PipelineStage.PreOperation;
        public override DataOperation Operation => DataOperation.Read;

        public override string Description => nameof(ReadSecurity);

        public override void Execute(string collection, ref JObject item, ref Dictionary<string, object> dataContext)
        {
            CheckGeneric(collection, Operation);
        }

        public ReadSecurity(EntityService entityService, IHttpContextAccessor httpContextAccessor) : base(entityService, httpContextAccessor)
        { }
    }
}