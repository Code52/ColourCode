﻿// Copyright (c) Microsoft Corporation.  All rights reserved.   

using System.Collections.Generic;
using ColorCode.Common;

namespace ColorCode.Compilation.Languages
{
    public class Css : ILanguage
    {
        public string Id
        {
            get { return LanguageId.Css; }
        }

        public string Name
        {
            get { return "CSS"; }
        }

        public string CssClassName
        {
            get { return "css"; }
        }

        public string FirstLinePattern
        {
            get
            {
                return null;
            }
        }

        public IList<LanguageRule> Rules
        {
            get
            {
                return new List<LanguageRule>
                           {
                               new LanguageRule(
                                   @"(?msi)(?:(\s*/\*.*?\*/)|(([a-z0-9#. \[\]=\"":_-]+)\s*(?:,\s*|{))+(?:(\s*/\*.*?\*/)|(?:\s*([a-z0-9 -]+\s*):\s*([a-z0-9#,<>\?%. \(\)\\\/\*\{\}:'\""!_=-]+);?))*\s*})",
                                   new Dictionary<int, string>
                                       {
                                           { 3, ScopeName.CssSelector },
                                           { 5, ScopeName.CssPropertyName },
                                           { 6, ScopeName.CssPropertyValue },
                                           { 4, ScopeName.Comment },
                                           { 1, ScopeName.Comment },
                                       }),
                           };
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
