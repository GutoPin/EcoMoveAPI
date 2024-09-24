using System.Net.Mime;
using EcoMoveAPI.BookingReservation.Domain.Model.Queries;
using EcoMoveAPI.BookingReservation.Domain.Services;
using EcoMoveAPI.BookingReservation.Interfaces.REST.Resources;
using EcoMoveAPI.BookingReservation.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.BookingReservation.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BookingsController(
    IBookingCommandService bookingCommandService,
    IBookingQueryService bookingQueryService)
    : ControllerBase
{
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a booking",
        Description = "Creates a booking with a given user id, vehicle id, start date and end date",
        OperationId = "CreateBooking")]
    [SwaggerResponse(201, "The booking was created", typeof(BookingResource))]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingResource createBookingResource)
    {
        var createBookingCommand = CreateBookingCommandFromResourceAssembler.ToCommandFromResource(createBookingResource);
        var booking = await bookingCommandService.Handle(createBookingCommand);
        if (booking is null) return BadRequest();
        var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
        return CreatedAtAction(nameof(GetBookingById), new { id = booking.BookingId }, bookingResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Gets all bookings",
        Description = "Gets all bookings",
        OperationId = "GetAllBookings")]
    [SwaggerResponse(200, "The bookings were found", typeof(BookingResource))]
    public async Task<IActionResult> GetAllBookings()
    {
        var getAllBookingsQuery = new GetAllBookingsQuery();
        var bookings = await bookingQueryService.Handle(getAllBookingsQuery);
        var bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(bookingResources);
    }
    
    [HttpGet("{id:int}")]
    [SwaggerOperation(
        Summary = "Gets a booking by id",
        Description = "Gets a booking for a given identifier",
        OperationId = "GetBookingById")]
    [SwaggerResponse(200, "The booking was found", typeof(BookingResource))]
    public async Task<IActionResult> GetBookingById(int id)
    {
        var getBookingByIdQuery = new GetBookingByBookingIdQuery(id);
        var booking = await bookingQueryService.Handle(getBookingByIdQuery);
        if (booking == null) return NotFound();
        var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);
        return Ok(bookingResource);
    }
    
    [HttpGet("user-id/{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets all bookings by user id",
        Description = "Gets all bookings for a given user identifier",
        OperationId = "GetAllBookingsByUserId")]
    [SwaggerResponse(200, "The bookings were found", typeof(BookingResource))]
    public async Task<IActionResult> GetAllBookingsByUserId(int userId)
    {
        var getAllBookingsByUserIdQuery = new GetAllBookingsByUserIdQuery(userId);
        var bookings = await bookingQueryService.Handle(getAllBookingsByUserIdQuery);
        var bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(bookingResources);
    }
}