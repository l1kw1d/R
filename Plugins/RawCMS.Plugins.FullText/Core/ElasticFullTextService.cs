//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using Elasticsearch.Net;
using Nest;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace RawCMS.Plugins.FullText.Core
{
    public class JObjectResponse : ElasticsearchResponse<JObject>
    {
    }

    public class StringResponse : ElasticsearchResponse<string>
    {
    }

    public class ElasticFullTextService : FullTextService
    {
        protected ElasticClient client;

        public ElasticFullTextService(ElasticClient client)
        {
            this.client = client;
        }

        public override void AddDocumentRaw(string indexname, object data)
        {
            var jobj = JObject.FromObject(data);

            //Resolve object id. elastic whant an "id" field, mongo uses _id...
            if (!jobj.ContainsKey("Id"))
            {
                if (jobj.ContainsKey("_id"))
                {
                    jobj["Id"] = jobj["_id"];
                }
                else if (jobj.ContainsKey("id"))
                {
                    jobj["Id"] = jobj["id"];
                }
                else
                {
                    jobj["Id"] = Guid.NewGuid();
                }
            }

            if (jobj.ContainsKey("_id"))
            {
                jobj.Property("_id").Remove();
            }

            var resp = client.LowLevel.Index<JObjectResponse>(indexname, jobj["Id"].ToString(), PostData.String(jobj.ToString()));
        }

        public override void CreateIndex(string name)
        {
            var resp = client.Indices.Create(name);
            ThrowOnError(resp);
        }

        private static void ThrowOnError(IElasticsearchResponse resp)
        {
            if (!resp.ApiCall.Success)
            {
                if (resp.TryGetServerErrorReason(out string reason))
                {
                    throw new Exception($"Error during init {reason}");//TODO: check if the string commutation of error prduces a nice message
                }
            }
        }

        public override void DeleteDocument(string index, string id)
        {
            var response = client.LowLevel.Delete<JObjectResponse>(index, id);
            ThrowOnError(response);
        }

        public override JObject GetDocumentRaw(string indexname, string docId)
        {
            var response = client.LowLevel.Get<JObjectResponse>(indexname, docId);
            var json = Encoding.UTF8.GetString(response.ResponseBodyInBytes);
            return (JObject)JObject.Parse(json)["_source"];
        }

        public override bool IndexExists(string name)
        {
            var ex = this.client.Indices.Exists(name);
            return ex.Exists;
        }

        public override List<JObject> SearchDocumentsRaw(string indexname, string searchQuery, int start, int size)
        {
            var searchResponse = client.Search<JObject>(s => s
                         .Size(size)
                         .Skip(start)
                         .Index(indexname)
                         //   .FilterPath(new string[] { "_source" })
                         .Query(q => q.QueryString(

                             qs => qs.Query(searchQuery)
                             .AllowLeadingWildcard(true)
                             )

                         )
                     );

            return new List<JObject>(searchResponse.Documents);
        }
    }
}