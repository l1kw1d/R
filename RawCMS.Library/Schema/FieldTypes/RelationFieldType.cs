//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
namespace RawCMS.Library.Schema.FieldTypes
{
    public class RelationFieldType : FieldType
    {
        public override string TypeName => "relation";

        public override FieldGraphType GraphType => FieldGraphType.Relation;

        public RelationFieldType()
        {
            OptionParameter.Add(new OptionParameter()
            {
                Name = "Collection",
                Type = "entities-list"
            });

            OptionParameter.Add(new OptionParameter()
            {
                Name = "Multiple",
                Type = "bool",
                Description = "1N or NM",
            });

            OptionParameter.Add(new OptionParameter()
            {
                Name = "Property",
                Type = "fields-list",
                Description = "property to show in search list",
            });
        }
    }
}