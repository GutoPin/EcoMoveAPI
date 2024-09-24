using System.Net.Mime;
using EcoMoveAPI.Payment.Domain.Model.Queries;
using EcoMoveAPI.Payment.Domain.Services;
using EcoMoveAPI.Payment.Interfaces.REST.Resources;
using EcoMoveAPI.Payment.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EcoMoveAPI.Payment.Interfaces.REST;

/**
 * The transactions controller
 * <summary>
 * The transactions controller
 * </summary>
 * <remarks>
 * The transactions controller
 * </remarks>
 */

[ApiController]
[Route(("api/v1/[controller]"))]
[Produces(MediaTypeNames.Application.Json)]
public class TransactionsController(ITransactionCommandService transactionCommandService,
    ITransactionQueryService transactionQueryService) : ControllerBase
{
    /**
     * Creates a transaction
     * <summary>
     * Creates a transaction with a given user id, amount and date
     * </summary>
     * <param name="createTransactionResource">The transaction resource</param>
     * <returns>The transaction</returns>
     * <response code="201">The transaction was created</response>
     * <response code="400">The transaction was not created</response>
     */
    [HttpPost]
    [SwaggerOperation(
        Summary = "Creates a transaction",
        Description = "Creates a transaction with a given user id, amount and date",
        OperationId = "CreateTransaction")]
    [SwaggerResponse(201, "The transaction was created", typeof(TransactionResource))]
    public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionResource createTransactionResource)
    {
        var createTransactionCommand = CreateTransactionCommandFromResourceAssembler.ToCommandFromResource(createTransactionResource);
        var transaction = await transactionCommandService.Handle(createTransactionCommand);
        if (transaction is null) return BadRequest();
        var transactionResource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return Created("api/v1/Transactions/{transaction.TransactionId}", transactionResource);
    }
    
    /**
     * Gets all transactions by user id
     * <summary>
     *  Gets all transactions for a given user identifier
     * </summary>
     * <param name="userId">The user identifier</param>
     * <returns>The transactions</returns>
     */
    [HttpGet ("{userId:int}")]
    [SwaggerOperation(
        Summary = "Gets all transactions by user id",
        Description = "Gets all transactions for a given user identifier",
        OperationId = "GetAllTransactionsByUserId")]
    [SwaggerResponse(200, "The transactions were found", typeof(TransactionResource))]
    public async Task<IActionResult> GetAllTransactionsByUserId(int userId)
    {
        var getAllTransactionsByUserIdQuery = new GetAllTransactionsByUserIdQuery(userId);
        var transactions = await transactionQueryService.Handle(getAllTransactionsByUserIdQuery);
        var transactionResources = transactions.Select(TransactionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(transactionResources);
    }
}