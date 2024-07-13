﻿using ArcTemplate.Core.Entities;
using ArcTemplate.Core.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ArcTemplate.Application.UseCases.GetCategoryProducts
{
    public class GetCategoryProductsRequest : IRequest<GetCategoryProductsResponse>
    {
        public string Name { get; set; }
    }

    public class GetCategoryProductsResponse
    {
        public IEnumerable<Product> Products { get; set; }
    }

    public class GetCategoryProductsHandler : IRequestHandler<GetCategoryProductsRequest, GetCategoryProductsResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryProductsHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<GetCategoryProductsResponse> Handle(GetCategoryProductsRequest request, CancellationToken cancellationToken)
        {
            var products = _categoryRepository.GetCategoryProducts(request.Name);

            var response = new GetCategoryProductsResponse
            {
                Products = products.Select(p => new Product
                {
                    Id = p.Id, 
                    Name = p.Name,
                    Price = p.Price,
                    BrandName = p.BrandName
                }).ToList()
            };

            return Task.FromResult(response);
        }
    }
}