// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.ViewSelectorModels
{
    using System;
    using System.Collections.Generic;

    public class ViewModelComponentDictionary
    {
        private readonly Dictionary<string, ViewModelComponentInfo> viewRegistrations = new Dictionary<string, ViewModelComponentInfo>();
        public ViewModelComponentInfo this[object model] => this.viewRegistrations[model.GetType().AssemblyQualifiedName];
        public void Set<TModel, TComponent>(string propertyName)
        {
            ViewModelComponentInfo componentInfo = new ViewModelComponentInfo
            {
                ModelType = typeof(TModel),
                ComponentType = typeof(TComponent),
                PropertyName = propertyName
            };

            if (componentInfo.IsValid)
            {
                this.viewRegistrations[componentInfo.ModelAssemblyQualifiedName] = componentInfo;
            }
            else
            {
                throw new ArgumentException("Property type be the same as TModel");
            }
        }
    }
}
