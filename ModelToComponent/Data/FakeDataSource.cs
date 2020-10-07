﻿// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent.Data
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components.Routing;
    using ModelToComponent.Models;
    using ModelToComponentMapper.Models;

    public static class FakeDataSource
    {
        public static readonly IReadOnlyList<object> BlogItems = new object[]
        {
            new Heading { Text = "Hello World!", Level= HeadingLevel.One },
            new Division { Text = "Welcome to my" },
            new Anchor { Text = "My Website.", Href ="https://brianparker.azurewebsites.net/" },
            new Division { Text = "All these items are being rendered based on their data type and order from an enumerable object source" },
            new ImageSource { DisplayHeight=259, DisplayWidth=241, Source = imageData },
            new Division { Text = "Pretty cool, huh?" },
            new Markup { Text = stackFlare }
        };

        public static readonly IReadOnlyList<object> NavItems = new object[]
        {
            new NavItem { Text = "Home", Icon ="oi oi-home" , Href ="" , NavLinkMatch = NavLinkMatch.All },
            new NavItem { Text = "By Layout", Icon ="oi oi-code" , Href ="byLayout" },
            new NavItem { Text = "By Code", Icon ="oi oi-excerpt" , Href ="byCode" },
            new NavItem { Text = "Non Enumerable", Icon ="oi oi-image" , Href ="nonEnumerable" },
            new NavItem { Text = "Standard Component", Icon ="oi oi-image" , Href ="standardComponent" }

            
        };

        public const string imageData = "data:image/jpeg; base64, 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";
        public const string stackFlare = "<a href=\"https://stackoverflow.com/users/1492496/brian-parker\" target=\"_blank\"><img src=\"https://stackoverflow.com/users/flair/1492496.png?theme=dark\" width=\"208\" height=\"58\" alt=\"profile for Brian Parker at Stack Overflow, Q & A for professional and enthusiast programmers\" title=\"profile for Brian Parker at Stack Overflow, Q & A for professional and enthusiast programmers\"></a>";

    }
}
