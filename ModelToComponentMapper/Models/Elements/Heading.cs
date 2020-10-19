// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

using System;

namespace ModelToComponentMapper.Models.Elements
{
    public class Heading : AttributeBaseElement
    {
        public object Content { get; set; }

        [Obsolete("Text is obsolete switch to Content")]
        public string Text { get => (string)Content; set => Content = value; }

        public HeadingLevel Level { get; set; }
    }
}
