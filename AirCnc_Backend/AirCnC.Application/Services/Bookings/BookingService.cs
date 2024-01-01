using AirCnC.Application.Commons;
using AirCnC.Application.Commons.Identity;
using AirCnC.Application.Commons.Specifications;
using AirCnC.Application.Services.Bookings.Dtos;
using AirCnC.Application.Services.Bookings.Specifications;
using AirCnC.Domain.Data;
using AirCnC.Domain.Entities;
using AirCnC.Domain.Enums;
using AirCnC.Domain.Exceptions;
using AirCnC.Domain.Exceptions.BookingException;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AirCnC.Application.Services.Bookings;

public interface IBookingService
{
    Task<PagedList<GetBookingForHostDto>> GetBookingsForHostAsync(int hostId, BookingQueryParameters bqp);
    Task<PagedList<GetBookingForGuestDto>> GetBookingsForGuestAsync(int guestId, BookingQueryParameters bqp);
    Task<GetDraftBookingDto> CreateBookingAsync(CreateBookingDto createBookingDto);
    Task<List<GetBookingForPropertyDto>> GetBookingsForPropertyAsync(int propertyId, DateTime fromDate, DateTime toDate);
    Task ChangeBookingStatusAsync(int bookingId, BookingStatus status);
}

public class BookingService : IBookingService
{
    private readonly IRepository<Booking> _bookingRepository;
    private readonly IRepository<Property> _propertyRepository;
    private readonly IRepository<Guest> _guestRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AirCnCSettings _airCnCSettings;
    private readonly ILogger<BookingService> _logger;
    private readonly ICurrentUser _currentUser;

    public BookingService(IRepository<Booking> bookingRepository,
                          IUnitOfWork unitOfWork,
                          IMapper mapper,
                          IRepository<Property> propertyRepository,
                          IOptions<AirCnCSettings> airCnCSettings,
                          IRepository<Guest> guestRepository,
                          ILogger<BookingService> logger,
                          ICurrentUser currentUser)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _propertyRepository = propertyRepository;
        _guestRepository = guestRepository;
        _logger = logger;
        _currentUser = currentUser;
        _airCnCSettings = airCnCSettings.Value;
    }

    public async Task<PagedList<GetBookingForHostDto>> GetBookingsForHostAsync(int hostId, BookingQueryParameters bqp)
    {
        var spec = new GetBookingsForHostSpecification(hostId, bqp);
        var (bookings, totalCount) = await _bookingRepository.FindWithTotalCountAsync(spec);

        var bookingsDto = _mapper.Map<List<GetBookingForHostDto>>(bookings);

        return new PagedList<GetBookingForHostDto>(bookingsDto, totalCount, bqp.PageIndex, bqp.PageSize);
    }

    public async Task<PagedList<GetBookingForGuestDto>> GetBookingsForGuestAsync(int guestId, BookingQueryParameters bqp)
    {
        var spec = new GetBookingsForGuestSpecification(guestId, bqp);
        var (bookings, totalCount) = await _bookingRepository.FindWithTotalCountAsync(spec);

        var bookingsDto = _mapper.Map<List<GetBookingForGuestDto>>(bookings);

        return new PagedList<GetBookingForGuestDto>(bookingsDto, totalCount, bqp.PageIndex, bqp.PageSize);
    }

    public async Task<GetDraftBookingDto> CreateBookingAsync(CreateBookingDto createBookingDto)
    {
        _logger.LogInformation("Creating booking {@Booking}", createBookingDto);
        var guest = await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(int.Parse(_currentUser.Id!)));
        if (guest == null)
            throw new EntityNotFoundException(nameof(Guest), _currentUser.Id!);
        createBookingDto.GuestId = guest.Id;
        // Get property info
        var propertyInfo = await _propertyRepository.FindOneAsync(new GetPropertyWithHostSpecification(createBookingDto.PropertyId))
                           ?? throw new EntityNotFoundException(nameof(Property), createBookingDto.PropertyId.ToString());
        
        var userId = int.Parse(_currentUser.Id!);
        createBookingDto.GuestId = (await _guestRepository.FindOneAsync(new GuestByUserIdSpecification(userId)))?.Id
                      ?? throw new EntityNotFoundException(nameof(Guest), userId.ToString());
        //add 1 day to check-in and check-out date #FE fix later
        createBookingDto.CheckInDate = createBookingDto.CheckInDate.AddDays(1);
        createBookingDto.CheckOutDate = createBookingDto.CheckOutDate.AddDays(1);

        // Validate input
        await ValidateInput(createBookingDto, propertyInfo);

        // Map property price info to booking
        var booking = _mapper.Map<Booking>(createBookingDto);
        booking.CancellationPolicyType = propertyInfo.CancellationPolicyType;
        booking.PricePerNight = propertyInfo.PricePerNight;
        booking.CleaningFee = propertyInfo.CleaningFee;
        booking.SystemFee = _airCnCSettings.SystemFee;

        // Set booking status to pending
        booking.Status = BookingStatus.Pending;

        // Calculate total price
        var numberOfDays = (booking.CheckOutDate.Date - booking.CheckInDate.Date).Days;
        var stayPrice = booking.PricePerNight * numberOfDays;
        booking.TotalPrice = stayPrice + booking.CleaningFee;

        // Save booking
        _bookingRepository.Add(booking);
        await _unitOfWork.SaveChangesAsync();
        _logger.LogInformation("Booking created {@Booking}", booking);

        // Map booking to dto
        return _mapper.Map<GetDraftBookingDto>(booking);
    }

    public async Task<List<GetBookingForPropertyDto>> GetBookingsForPropertyAsync(int propertyId, DateTime fromDate, DateTime toDate)
    {
        var spec = new ActiveBookingBetweenDatesSpecification(propertyId, fromDate, toDate);
        var bookings = await _bookingRepository.FindListAsync(spec);

        var bookingsDto = _mapper.Map<List<GetBookingForPropertyDto>>(bookings);

        return bookingsDto;
    }

    public async Task ChangeBookingStatusAsync(int bookingId, BookingStatus status)
    {
        var booking = await _bookingRepository.GetByIdAsync(bookingId, true)
                      ?? throw new EntityNotFoundException(nameof(Booking), bookingId.ToString());
        // TODO: add validate here?
        booking.Status = status;
        await _unitOfWork.SaveChangesAsync();
    }

    private async Task ValidateInput(CreateBookingDto createBookingDto, Property property)
    {
        // Check if checkin and checkout date is valid
        if (createBookingDto.CheckInDate.Date >= createBookingDto.CheckOutDate.Date)
            throw new InvalidBookingDateException("Checkin date must be before checkout date");

        // Check if checkin date is after today
        if (createBookingDto.CheckInDate.Date <= DateTime.Now.Date)
            throw new InvalidBookingDateException("Checkin date must be after today");

        // Check if checkin date is after today + max days in advance
        if (createBookingDto.CheckInDate.Date > DateTime.Now.AddDays(_airCnCSettings.MaxDaysInAdvance).Date)
            throw new InvalidBookingDateException($"Checkin date must be before today + {_airCnCSettings.MaxDaysInAdvance} days");

        // Check if stay duration is valid
        if ((createBookingDto.CheckOutDate.Date - createBookingDto.CheckInDate.Date).Days > _airCnCSettings.MaxStayDuration)
            throw new InvalidBookingDateException($"Stay duration must be less than {_airCnCSettings.MaxStayDuration} days");

        // Check if property is available for booking
        var isPropertyAlreadyBusy = await _bookingRepository.AnyAsync(new ActiveBookingBetweenDatesSpecification(createBookingDto.PropertyId, createBookingDto.CheckInDate, createBookingDto.CheckOutDate));
        if (isPropertyAlreadyBusy)
            throw new InvalidBookingDateException("Property is not available for booking");

        // Check if number of guests is valid
        if (createBookingDto.NumberOfAdults > property.MaxAdultCount)
            throw new InvalidGuestCountException($"Number of adults must be less than {property.MaxAdultCount}");

        if (createBookingDto.NumberOfChildren > property.MaxChildCount)
            throw new InvalidGuestCountException($"Number of children must be less than {property.MaxChildCount}");

        // Check if guest is booking his own property
        var guestUserId = int.Parse(_currentUser.Id!);
        if (guestUserId == property.Host.UserId)
            throw new GuestIsHostException("Guest cannot book his own property");
    }
}
