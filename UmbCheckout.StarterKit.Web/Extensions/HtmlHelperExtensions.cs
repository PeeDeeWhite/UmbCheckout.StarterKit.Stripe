﻿using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UmbCheckout.StarterKit.Web.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string ToRewrittenUrl(this IHtmlHelper _, string url, string linkType, string name)
        {
            return $"{url}{linkType}/{HttpUtility.UrlEncode(name).ToLower()}/";
        }
    }
}
