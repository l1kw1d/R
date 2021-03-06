//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawCMS.Library.Core;
using RawCMS.Library.Core.Attributes;
using RawCMS.Library.Core.Enum;
using RawCMS.Library.Schema;
using RawCMS.Plugins.Core.Model;
using System;
using System.Collections.Generic;

namespace RawCMS.Plugins.Core.Controllers.Controllers.admin
{
    [AllowAnonymous]
    [RawAuthentication]
    [Route("system/[controller]")]
    public class EnumController
    {
        private static Dictionary<string, Type> enumMap = new Dictionary<string, Type>()
        {
            { "SavePipelineStage", typeof(PipelineStage) },
            { "FieldBaseType", typeof(FieldGraphType) }
        };

        protected ILogger<EnumController> logger;

        public EnumController(ILogger<EnumController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("{name}")]
        public RestMessage<Dictionary<string, string>> Get(string name)
        {
            var data = new Dictionary<string, string>();
            var result = new RestMessage<Dictionary<string, string>>(data);

            try
            {
                var values = Enum.GetValues(enumMap[name]);
                var names = Enum.GetNames(enumMap[name]);
                for (int i = 0; i < names.Length; i++)
                {
                    data[names[i]] = values.GetValue(i).ToString();
                }
            }
            catch (Exception err)
            {
                this.logger.LogError(err, "error during enum resolution");
                result.Errors.Add(new Error()
                {
                    Code = "001",
                    Title = "Error getting enum",
                    Description = err.Message
                });
            }
            return result;
        }
    }
}