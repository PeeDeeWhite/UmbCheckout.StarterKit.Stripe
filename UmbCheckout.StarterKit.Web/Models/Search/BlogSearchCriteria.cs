﻿namespace UmbCheckout.StarterKit.Web.Models.Search
{
    public class BlogSearchCriteria
    {
        public string? Keywords { get; set; } = null;

        public string? Category { get; set; } = null;

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 9;


    }
}
