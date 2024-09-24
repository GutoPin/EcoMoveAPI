using EcoMoveAPI.Payment.Domain.Model.Aggregates;
using EcoMoveAPI.Payment.Interfaces.REST.Resources;

namespace EcoMoveAPI.Payment.Interfaces.REST.Transform;

/**
 * Assembler class to convert a Transaction object to a TransactionResource object.
 * This class is used to convert Transaction objects to TransactionResource objects.
 * This is useful when returning Transaction objects in the REST API.
 */
public static class TransactionResourceFromEntityAssembler
{
    public static TransactionResource ToResourceFromEntity(Transaction transaction)
    {
        return new TransactionResource(transaction.TransactionId, transaction.UserId, transaction.Amount, transaction.Date);
    }
}