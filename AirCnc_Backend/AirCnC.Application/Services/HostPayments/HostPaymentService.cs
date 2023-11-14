using AirCnC.Application.Commons;
using AirCnC.Application.Services.HostPayments.Dtos;
using AirCnC.Application.Services.HostPayments.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.HostPayments
{
    public interface IHostPaymentService
    {
        Task<PagedList<HostPaymentDto>> GetPaymentsAsync(HostPaymentQueryParameters hqp);
        Task<HostPaymentDto> GetPaymentAsync(int hostPaymentId);
        Task Pay(int hostPaymentId);
        Task<PagedList<HostPaymentDto>> GetPaymentsByHostIdAsync(int hostId, HostPaymentQueryParameters hqp);
    }
    public class HostPaymentService : IHostPaymentService
    {
        private readonly IRepository<HostPayment> _hostPaymentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HostPaymentService(IRepository<HostPayment> hostPaymentRepository, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _hostPaymentRepository = hostPaymentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<HostPaymentDto>> GetPaymentsAsync(HostPaymentQueryParameters hqp)
        {
            var spec = new GetHostPaymentsSpecification(hqp);
            var (hostPayments,totalCount) = await _hostPaymentRepository.FindWithTotalCountAsync(spec);
            var hostPaymentsDto = _mapper.Map<List<HostPaymentDto>>(hostPayments);
            return new PagedList<HostPaymentDto>(hostPaymentsDto, totalCount, hqp.PageIndex, hqp.PageSize);
        }

        public async Task<HostPaymentDto> GetPaymentAsync(int hostPaymentId)
        {
            var spec = new GetHostPaymentSpecification(hostPaymentId);
            var hostPayment = await _hostPaymentRepository.FindOneAsync(spec)
                              ?? throw new EntityNotFoundException(nameof(HostPayment), hostPaymentId.ToString());
            return _mapper.Map<HostPaymentDto>(hostPayment);
        }

        public async Task Pay(int hostPaymentId)
        {
            var hostPayment = await _hostPaymentRepository.GetByIdAsync(hostPaymentId)
                              ?? throw new EntityNotFoundException(nameof(HostPayment), hostPaymentId.ToString());
            hostPayment.Status = HostPaymentStatus.Paid;
            _hostPaymentRepository.Update(hostPayment);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedList<HostPaymentDto>> GetPaymentsByHostIdAsync(int hostId, HostPaymentQueryParameters hqp)
        {
            var spec = new GetHostPaymentsSpecification(hqp, hostId);
            var (hostPayments, totalCount) = await _hostPaymentRepository.FindWithTotalCountAsync(spec);
            var hostPaymentsDto = _mapper.Map<List<HostPaymentDto>>(hostPayments);
            return new PagedList<HostPaymentDto>(hostPaymentsDto, totalCount, hqp.PageIndex, hqp.PageSize);
        }
    }
}
