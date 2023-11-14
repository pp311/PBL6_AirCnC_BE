using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Services.Chat.Dtos;
using AirCnC.Application.Services.Chat.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Exceptions.Auth;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AirCnC.Application.Services.Chat;

public interface IChatService
{
    Task<List<GetMessageDto>> GetMessagesWithUserIdAsync(int userId);
    Task<List<GetContactDto>> GetContactsAsync();
} 

public class ChatService : IChatService
{
    private readonly IRepository<Message> _messageRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUser _currentUser;
    private readonly UserManager<User> _userManager;

    public ChatService(IRepository<Message> messageRepository,
                       ICurrentUser currentUser,
                       IMapper mapper,
                       UserManager<User> userManager)
    {
        _messageRepository = messageRepository;
        _currentUser = currentUser;
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<List<GetMessageDto>> GetMessagesWithUserIdAsync(int userId)
    {
        var currentUserId = int.Parse(_currentUser.Id!);
        
        var isUserExisted = await _userManager.Users.AnyAsync(u => u.Id == userId); 
        if (!isUserExisted)
            throw new UserNotFoundException(userId.ToString());

        var messages = await _messageRepository
                           .FindListAsync(new MessagesWithUserIdSpecification(currentUserId, userId));
        return _mapper.Map<List<GetMessageDto>>(messages);
    }

    public async Task<List<GetContactDto>> GetContactsAsync()
    {
        var currentUserId = int.Parse(_currentUser.Id!);

        var contactUsers = await _userManager.Users
           .Where(u => u.SentMessages.Any(m => m.ReceiverId == currentUserId) ||
                       u.ReceivedMessages.Any(m => m.SenderId == currentUserId))
           .ToListAsync();
        
        var contactDtos = _mapper.Map<List<GetContactDto>>(contactUsers);
        
        foreach (var contactDto in contactDtos)
        {
            var lastMessage = await _messageRepository
                .FindOneAsync(new MessagesWithUserIdSpecification(currentUserId, contactDto.Id, true));
            contactDto.LastMessage = lastMessage?.Content ?? string.Empty;
            contactDto.LastMessageTime = lastMessage?.CreatedAt ?? DateTime.MinValue;
        }
        
        return contactDtos;
    }
}

public class ChatMappingProfile : Profile
{
    public ChatMappingProfile()
    {
        CreateMap<Message, GetMessageDto>()
            .ForMember(dto => dto.MessageTime, opt => opt.MapFrom(m => m.CreatedAt));

        CreateMap<User, GetContactDto>();
    }
}