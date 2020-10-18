// ---------------------------------------------------------------
// Copyright (c) Brian Parker. All rights reserved.
// Licensed under the MIT License.
// See License.txt in the project root for license information.
// ---------------------------------------------------------------

namespace ModelToComponent.Models
{
    using System.Collections.Generic;

    public class NavigationView
    {
        public NavItem[] NavigationItems { get; set; }
        public string Title { get; set; }
    }
}
