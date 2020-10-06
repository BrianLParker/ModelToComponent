// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent.Models
{
    using Microsoft.AspNetCore.Components.Routing;

    public class NavItem
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }

        public NavLinkMatch NavLinkMatch { get; set; } = NavLinkMatch.Prefix;
    }
}
