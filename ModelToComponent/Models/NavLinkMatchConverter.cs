// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent.Models
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using Microsoft.AspNetCore.Components.Routing;

    public class NavLinkMatchConverter : JsonConverter<NavLinkMatch>
    {
        public override NavLinkMatch Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options) => reader.GetString() switch
            {
                "All" => NavLinkMatch.All,
                _ => NavLinkMatch.Prefix
            };

        public override void Write(
            Utf8JsonWriter writer,
            NavLinkMatch navLinkMatch,
            JsonSerializerOptions options) => 
                writer.WriteStringValue(navLinkMatch.ToString());
    }
}
