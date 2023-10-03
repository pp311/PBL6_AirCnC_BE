using AirCnC.Application.Services.Property.Dtos;
using AirCnC.Application.QueryParameters;
using AirCnC.Domain;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Repositories;
using AirCnC.Domain.Data;
using AutoMapper;
using OAuth2.Infrastructure;

namespace AirCnC.Application.Services.Property
{
    public interface IPropertyService
    {
        Task<PagedResult<GetPropertyDto>> GetListAsync(PropertyQueryParameters PropertyQueryParameters);
        Task<GetPropertyDto?> GetByIdAsync(int id);
    }
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _PropertyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PropertyService(IPropertyRepository PropertyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _PropertyRepository = PropertyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<GetPropertyDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<GetPropertyDto>> GetListAsync(PropertyQueryParameters pqp)
        {
            var (items, TotalCount) = await _PropertyRepository.GetPropertyPagedListAsync(search: pqp.Search,
                                                                                         type: pqp.Type,
                                                                                         orderBy: pqp.OrderBy,
                                                                                         skip: (pqp.PageIndex - 1) * pqp.PageSize,
                                                                                         take: pqp.PageSize,
                                                                                         isDescending: pqp.IsDescending);
            var result = _mapper.Map<List<GetPropertyDto>>(items);
            return new PagedResult<GetPropertyDto>(result, TotalCount, pqp.PageIndex, pqp.PageSize);
        }
    }
}
