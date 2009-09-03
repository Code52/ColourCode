﻿// Copyright (c) Microsoft Corporation.  All rights reserved.

using ColorCode.Styling.StyleSheets;

namespace ColorCode
{
    /// <summary>
    /// Provides easy access to ColorCode's built-in style sheets.
    /// </summary>
    public static class StyleSheets
    {
        /// <summary>
        /// Gets the default style sheet.
        /// </summary>
        /// <remarks>
        /// The default style sheet mimics the default colorization scheme used by Visual Studio 2008 to the extent possible.
        /// </remarks>
        public static IStyleSheet Default { get { return new DefaultStyleSheet(); }}
    }
}
