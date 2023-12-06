using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.PaymentInfos.Dtos;
using AirCnC.Application.Services.PaymentInfos.Spectifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;

namespace AirCnC.Application.Services.PaymentInfos
{
    public interface IPaymentInfoService
    {
        Task<PaymentInfoDto> GetPaymentInfoAsync();
        Task<PaymentInfoDto> CreatePaymentInfoAsync(PaymentInfoDto paymentInfoDto);
        Task<PaymentInfoDto> UpdatePaymentInfoAsync(PaymentInfoDto paymentInfoDto);

    }
    public class PaymentInfoService: IPaymentInfoService
    {
        private readonly IRepository<PaymentInfo> _paymentInfoRepository;
        private readonly IRepository<Host> _hostRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUser _currentUser;
        private readonly IMapper _mapper;
        public PaymentInfoService(IRepository<PaymentInfo> paymentInfoRepository, IRepository<Host> hostRepository, IUnitOfWork unitOfWork, ICurrentUser currentUser, IMapper mapper)
        {
            _paymentInfoRepository = paymentInfoRepository;
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
            _currentUser = currentUser;
            _mapper = mapper;
        }

        public async Task<PaymentInfoDto> GetPaymentInfoAsync()
        {
            var host = await ValidateHost();
            if(host.PaymentInfo is null)
                throw new EntityNotFoundException(nameof(PaymentInfo), host.UserId.ToString());
            return _mapper.Map<PaymentInfoDto>(host.PaymentInfo);

        }

        public async Task<PaymentInfoDto> CreatePaymentInfoAsync(PaymentInfoDto paymentInfoDto)
        {
            var host = await ValidateHost();
            if (host.PaymentInfo is null)
            {
                PaymentInfo paymentInfo = _mapper.Map<PaymentInfo>(paymentInfoDto);
                paymentInfo.HostId = host.Id;
                _paymentInfoRepository.Add(paymentInfo);
                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<PaymentInfoDto>(paymentInfo);
            }
            throw new EntityAlreadyExistedException(nameof(PaymentInfo), host.UserId.ToString());
        }

        public async Task<PaymentInfoDto> UpdatePaymentInfoAsync(PaymentInfoDto paymentInfoDto)
        {
            var host = await ValidateHost();
            var spec = new PaymentInfoSpecification(host.Id);
            var paymentInfo = await _paymentInfoRepository.FindOneAsync(spec);
            if (paymentInfo is null)
                throw new EntityNotFoundException(nameof(PaymentInfo), host.UserId.ToString());
            _mapper.Map(paymentInfoDto, paymentInfo);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<PaymentInfoDto>(host.PaymentInfo);
        }

        public async Task<Host> ValidateHost()
        {
            int userId = int.Parse(_currentUser.Id);
            var spec = new HostByUserIdSpecification(userId);
            var host = await _hostRepository.FindOneAsync(spec);
            if (host is null)
                throw new EntityNotFoundException(nameof(Host), userId.ToString());
            return host;
        }
    }
    public class PaymentInfoMapping: Profile
    {

        public PaymentInfoMapping()
        {
            CreateMap<PaymentInfo, PaymentInfoDto>().ReverseMap();
        }
    }
}
