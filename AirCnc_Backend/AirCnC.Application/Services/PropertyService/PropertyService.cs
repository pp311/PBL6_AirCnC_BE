﻿using AirCnC.Application.Commons;
using AirCnC.Application.Services.PropertyService.Dtos;
using AirCnC.Application.Services.PropertyService.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AutoMapper;

namespace AirCnC.Application.Services.PropertyService
{
    public interface IPropertyService
    {
        Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters propertyQueryParameters);
        Task<GetPropertyDto?> GetByIdAsync(int id);
    }
    public class PropertyService : IPropertyService
    {
        private readonly IRepository<Property> _propertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService(IRepository<Property> propertyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public Task<GetPropertyDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<GetPropertyDto>> GetListAsync(PropertyQueryParameters pqp)
        {
            var propertyFilterSpec = new PropertyFilterSpecification(search: pqp.Search, type: pqp.Type, 
                                                                    orderBy: pqp.OrderBy, 
                                                                    isDescending: pqp.IsDescending,
                                                                    pageIndex: pqp.PageIndex,
                                                                    pageSize: pqp.PageSize);


            var (items, totalCount) = await _propertyRepository.FindWithTotalCountAsync(propertyFilterSpec);
    
            var result = _mapper.Map<List<GetPropertyDto>>(items);
            
            return new PagedList<GetPropertyDto>(result, totalCount, pqp.PageIndex, pqp.PageSize);
        }
    }
}