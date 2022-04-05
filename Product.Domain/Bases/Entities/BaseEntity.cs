using FluentValidation.Results;

namespace Product.Domain.Bases.Entities
{
    public class BaseEntity<TId>
    {
        public TId? Id { get; set; }
        public ValidationResult? ValidationResult { get; set; }
    }
}
