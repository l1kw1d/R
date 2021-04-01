﻿//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
namespace RawCMS.Library.Schema.Validation
{
    public class EntitiesListValidation : BaseJavascriptValidator
    {
        public override string Type => "entities-list";

        public override string Javascript
        {
            get
            {
                return @"
const innerValidation = function() {
    if (value === null || value === undefined) {
        return;
    }

    // code starts here

    return JSON.stringify(errors);
};

var backendResult = innerValidation();
            ";
            }
        }
    }
}