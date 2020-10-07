// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.ViewSelectorModels
{
    using System;

    public record ViewModelComponentInfo
    {
        public Type ModelType { get; init; }
        public Type ComponentType { get; init; }
        public string PropertyName { get; init; }
        public string ModelAssemblyQualifiedName => ModelType.AssemblyQualifiedName;
        internal bool IsValid => ComponentType.GetProperty(PropertyName).PropertyType.AssemblyQualifiedName == ModelAssemblyQualifiedName;
    }
}
