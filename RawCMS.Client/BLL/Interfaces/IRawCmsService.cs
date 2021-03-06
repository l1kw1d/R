//******************************************************************************
// <copyright file="license.md" company="RawCMS project  (https://github.com/arduosoft/RawCMS)">
// Copyright (c) 2019 RawCMS project  (https://github.com/arduosoft/RawCMS)
// RawCMS project is released under GPL3 terms, see LICENSE file on repository root at  https://github.com/arduosoft/RawCMS .
// </copyright>
// <author>Daniele Fontani, Emanuele Bucarelli, Francesco Mina'</author>
// <autogenerated>true</autogenerated>
//******************************************************************************
using RawCMS.Client.BLL.Model;
using RestSharp;
using System.Collections.Generic;

namespace RawCMS.Client.BLL.Interfaces
{
    public interface IRawCmsService
    {
        IRestResponse GetData(ListRequest req);

        IRestResponse CreateElement(CreateRequest req);

        void ElaborateQueue(Dictionary<string, List<string>> listFile, ConfigFile config, bool pretty);

        int CheckJSON(string filePath);

        void ProcessDirectory(bool recursive, Dictionary<string, List<string>> fileList, string targetDirectory, string collection = null);

        string FixUrl(string serverUrl);

        bool Ping(string url);
    }
}