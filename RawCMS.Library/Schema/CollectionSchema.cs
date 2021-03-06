//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************

//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Min�</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace RawCMS.Library.Schema
{
    public class CollectionSchema
    {
        public string CollectionName { get; set; }
        public bool AllowNonMappedFields { get; set; }

        public List<Field> FieldSettings { get; set; } = new List<Field>();

        public JObject Events { get; set; } = new JObject();

        public Dictionary<string, JObject> PluginConfiguration { get; set; } = new Dictionary<string, JObject>();
    }
}