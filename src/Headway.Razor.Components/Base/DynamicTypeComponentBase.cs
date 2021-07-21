﻿using Headway.Core.Attributes;
using Headway.Core.Interface;
using Headway.Core.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Headway.Razor.Components.Base
{
    public abstract class DynamicTypeComponentBase : HeadwayComponentBase
    {
        [Inject]
        public IConfigCache ConfigCache { get; set; }

        [Inject]
        public IDynamicTypeCache DynamicTypeCache { get; set; }

        protected Config config;

        protected string modelNameSpace;

        protected string componentNameSpace;

        protected async Task GetConfig(string configName)
        {
            config = await ConfigCache.GetConfigAsync(configName).ConfigureAwait(false);

            modelNameSpace = GetTypeNamespace(config.Model, typeof(DynamicModelAttribute));

            componentNameSpace = GetTypeNamespace(config.Component, typeof(DynamicComponentAttribute));
        }

        protected string GetTypeNamespace(string name, Type attribute)
        {
            var dynamicType = DynamicTypeCache.GetDynamicType(name, attribute);

            if (dynamicType == null)
            {
                RaiseAlert($"Failed to map {name} to a fully qualified type.");
                return default;
            }

            return dynamicType.Namespace;
        }
    }
}
