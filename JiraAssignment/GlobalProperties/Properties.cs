﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraAssignment
{

    enum PropertyTypes
    {
        Id,
        Name,
        CssSelector,
        TagName,
        Xpath,
        LinkText
    }

    class Properties
    {
        public static IWebDriver driver {get; set;}
    }
}
