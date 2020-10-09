// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponentMapper
{
    using Microsoft.AspNetCore.Components;

    public class ViewComponentBase<TModel> : ComponentBase
    {
        [Parameter]
        public TModel Model { get; set; }
    }
}
