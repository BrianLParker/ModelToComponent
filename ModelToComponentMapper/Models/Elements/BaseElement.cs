// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper.Models.Elements
{
    public class BaseElement
    {
    }

    interface IContentBase  { }

    interface ITextContent : IContentBase
    {
        string Text { get; }
    }
    interface IMarkupContent : IContentBase
    {
        string Markup { get; }
    }

    interface IComponentContent : IContentBase
    {
        object Content { get; }
    }
}
