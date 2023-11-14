using AirCnC.Domain.Entities;
using AirCnC.Domain.Specification;

namespace AirCnC.Application.Services.Chat.Specifications;

public class MessagesWithUserIdSpecification : Specification<Message>
{
    public MessagesWithUserIdSpecification(int userId1, int userId2, bool isDescending = false)
    {
        AddFilter(m => m.SenderId == userId1 && m.ReceiverId == userId2 
                       || m.SenderId == userId2 && m.ReceiverId == userId1);
        
        if (isDescending)
            ApplyDescending();
    } 
}