using System.Linq.Dynamic.Core;
using AirCnC.Application.Commons;
using AirCnC.Application.Services.Users.Dtos;
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
        Task<GetUserForAdminDto> GetUserAsync(int id);
        Task<PagedList<GetUserForAdminDto>> GetUsersAsync(UserPagingParameters pp);
        Task<GetUserForAdminDto> UpdateUserAsync(int id, UpdateUserInfoDto dto);
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
        
        public async Task<GetUserForAdminDto> GetUserAsync(int id)
        {
            var user = await _userManager.Users
                .Include(u => u.Host)
                .Include(u => u.Guest)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new EntityNotFoundException(nameof(User), id.ToString());

            var result = _mapper.Map<GetUserForAdminDto>(user);
            result.IsHost = user.Host is not null;
            return result;
        }

        public async Task<PagedList<GetUserForAdminDto>> GetUsersAsync(UserPagingParameters pp)
        {
            var skip = (pp.PageIndex - 1) * pp.PageSize;
            var take = pp.PageSize;
            
            var adminIds = (await _userManager.GetUsersInRoleAsync("Admin")).Select(x => x.Id);
            
            var users = await _userManager.Users
                            .Include(u => u.Host)
                            .Include(u => u.Guest)
                            .Where(u => adminIds.All(id => id != u.Id))
                            .Where(u => !pp.IsHostOnly || u.Host != null)
                            .OrderBy(i => pp.IsDescending ? -i.Id : i.Id)
                            .Skip(skip)
                            .Take(take)
                            .ToListAsync();
            
            var totalCount = await _userManager.Users
                            .Where(u => adminIds.All(id => id != u.Id))
                            .Where(u => !pp.IsHostOnly || u.Host != null)
                            .CountAsync();

            var result = _mapper.Map<List<GetUserForAdminDto>>(users);
            foreach (var user in result)
                user.IsHost = users.FirstOrDefault(u => u.Id == user.Id)?.Host is not null;
            
            return new PagedList<GetUserForAdminDto>(result, totalCount, pp.PageIndex, pp.PageSize);
        }

        public async Task<GetUserForAdminDto> UpdateUserAsync(int id, UpdateUserInfoDto dto)
        {
            var user = await _userManager.Users
                .Include(u => u.Host)
                .Include(u => u.Guest)
                .FirstOrDefaultAsync(u => u.Id == id);
            if (user is null)
                throw new EntityNotFoundException(nameof(User), id.ToString());

            _mapper.Map(dto, user);
            await _unitOfWork.SaveChangesAsync();

            var result = _mapper.Map<GetUserForAdminDto>(user);
            result.IsHost = user.Host is not null;
            return result;
        }
    }

}
