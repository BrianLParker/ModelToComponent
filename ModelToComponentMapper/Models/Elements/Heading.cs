﻿// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.Elements
{
    public class Heading : AttributeBaseElement
    {
        public string Text { get; set; }

        public HeadingLevel Level { get; set; }
    }
}
