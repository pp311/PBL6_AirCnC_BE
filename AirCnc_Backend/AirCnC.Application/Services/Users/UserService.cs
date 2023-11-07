using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Users.Dtos;
using AirCnC.Application.Services.Users.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Application.Services.Users
{
    public interface IUserService
    {
        Task<PagedList<GetUserForAdminDto>> GetUsersAsync(PagingParameters pp);
    }

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IRepository<Host> _hostRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, IMapper mapper, IUnitOfWork unitOfWork,
            IRepository<Host> hostRepository)
        {
            _userManager = userManager;
            _mapper = mapper;
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }



        public async Task<PagedList<GetUserForAdminDto>> GetUsersAsync(PagingParameters pp)
        {
            var spec=new UsersPagingSpecification(pp);
            var users = await _userManager.Users.Skip(spec.Skip).Take(spec.Take).ToListAsync();

            var totalCount=users.Count;
            if (users is null)
                throw new EntityNotFoundException(nameof(Domain.Entities.User), pp.PageIndex.ToString());
            var result = _mapper.Map<List<GetUserForAdminDto>>(users);
            foreach (var user in result)
            {
                user.IsHost = await _hostRepository.AnyAsync(new HostByUserIdSpecification(int.Parse(user.Id)));
            }
            return new PagedList<GetUserForAdminDto>(result,totalCount,pp.PageIndex,pp.PageSize);
        }
    }

}
