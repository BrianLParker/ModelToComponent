// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.Elements
{
    using System.Collections.Generic;

    public class AttributeBaseElement : BaseElement
    {
        public Dictionary<string, object> InputAttributes { get; set; }
    }
}
