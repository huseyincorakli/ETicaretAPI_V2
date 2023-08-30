﻿using ETicaretAPI_V2.Application.Repositories.ProductRepositories;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ETicaretAPI_V2.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        readonly ILogger<GetAllProductQueryHandler> _logger;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository, ILogger<GetAllProductQueryHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _logger = logger;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Tüm PRODUCTLAR LİSTLENEDİ!");
            var totalCount = await _productReadRepository.GetAll(false).CountAsync();
            var products = await _productReadRepository.GetAll(false)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreateDate,
                    p.UpdatedDate
                })
                .ToListAsync();

            var response = new GetAllProductQueryResponse
            {
                TotalCount = totalCount,
                Products = products
            };

            return response;
        }
    }
}
