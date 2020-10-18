// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent.Models
{
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Components.Routing;
    public class NavItem
    {
        public string Text { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }

        [JsonConverter(typeof(NavLinkMatchConverter))]
        public NavLinkMatch NavLinkMatch { get; set; } = NavLinkMatch.Prefix;
    }
}
