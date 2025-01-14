﻿using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Easy.Hosts.Core.Repositories.Interface;
using Easy.Hosts.Core.DTOs.ProductDto;

namespace Easy.Hosts.Core.Repositories.Entities
{
    public class ProductRepository : IProductRepository
    {
        private readonly EasyHostsDbContext _context;

        public ProductRepository(EasyHostsDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(ProductCreate productCreate)
        {
            Product product = new Product
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Name = productCreate.Name,
                Quantity = productCreate.Quantity,
            };

            await _context.Set<Product>().AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FindAllAsync()
        {
            return await _context.Set<Product>().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _context.Set<Product>().FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}
