﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using UmbCheckout.StarterKit.Web.Extensions;
using UmbCheckout.StarterKit.Web.Interfaces;
using UmbCheckout.StarterKit.Web.Models.Search;
using UmbCheckout.StarterKit.Web.ViewModels;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.Controllers;

namespace UmbCheckout.StarterKit.Web.Controllers
{
    public class ProductsController : RenderController
    {
        private readonly IProductSearchService _productSearchService;
        private readonly IAppPolicyCache _cache;
        public ProductsController(ILogger<RenderController> logger, ICompositeViewEngine compositeViewEngine, IUmbracoContextAccessor umbracoContextAccessor, AppCaches caches, IProductSearchService productSearchService)
            : base(logger, compositeViewEngine, umbracoContextAccessor)
        {
            _productSearchService = productSearchService;
            _cache = caches.RuntimeCache;
        }

        public IActionResult Products(int page = 1, string? keywords = null, string? category = null)
        {
            var searchCriteria = new ProductSearchCriteria
            {
                Keywords = keywords,
                Category = category,
                CurrentPage = page,
                PageSize = CurrentPage.Value<int>("maximumPerPage")
            };

            var searchResults = _productSearchService.SearchProducts(searchCriteria);

            var model = new ProductsViewModel(CurrentPage)
            {
                SearchResponse = searchResults,
                Categories = GetProductCategories()
            };

            return CurrentTemplate(model);
        }

        private IEnumerable<string?> GetProductCategories()
        {
            return _cache.GetCacheItem("ProductCategories", () => CurrentPage.GetHomePage()
                    .FirstChildOfType("productCategories")
                    .Children()
                    .Select(x => x.Value<string>("categoryName")),
                TimeSpan.FromMinutes(60)) ?? Enumerable.Empty<string?>();
        }
    }
}
