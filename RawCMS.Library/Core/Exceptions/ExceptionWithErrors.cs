//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using System;
using System.Collections.Generic;

namespace RawCMS.Library.Core.Exceptions
{
    public class ExceptionWithErrors : Exception
    {
        public List<Error> Errors { get; set; } = new List<Error>();
        public List<Error> Warnings { get; set; } = new List<Error>();
        public List<Error> Infos { get; set; } = new List<Error>();

        public ExceptionWithErrors()
        {
        }

        public ExceptionWithErrors(List<Error> Errors) : this(Errors, null)
        {
        }

        public ExceptionWithErrors(List<Error> Errors, Exception source) : base("", source)
        {
            this.Errors = Errors;
        }
    }
}