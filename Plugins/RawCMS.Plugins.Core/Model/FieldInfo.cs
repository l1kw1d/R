﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using RawCMS.Library.Schema;
using System.Collections.Generic;

namespace RawCMS.Plugins.Core.Model
{
    public class FieldInfo
    {
        public FieldType Type { get; set; }
        public List<FieldClientValidation> Validations { get; set; }
    }
}