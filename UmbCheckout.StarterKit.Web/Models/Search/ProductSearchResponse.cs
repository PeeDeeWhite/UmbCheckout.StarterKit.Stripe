﻿using Umbraco.Cms.Core.Models.PublishedContent;

namespace UmbCheckout.StarterKit.Web.Models.Search
{
    public class ProductSearchResponse
    {
        public ProductSearchResponse(ProductSearchCriteria criteria)
        {
            Criteria = criteria ?? throw new ArgumentNullException(nameof(criteria));
        }

        public ProductSearchCriteria Criteria { get; private set; }

        public SearchResults? SearchResults { get; set; }
    }
}
