// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models
{
    using System;

    public interface IViewSelector
    {
        (Type componentType, string propertyName) GetModelViewComponentInfo(object model);
    }
}
