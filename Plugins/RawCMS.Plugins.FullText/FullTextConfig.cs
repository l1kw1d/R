//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
namespace RawCMS.Plugins.FullText
{
    public enum Engine
    {
        Elastic
    }

    public class FullTextConfig
    {
        public string Url { get; set; } = ("http://localhost:9300");
        public Engine Engine { get; set; } = Engine.Elastic;
    }
}