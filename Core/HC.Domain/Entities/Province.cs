using HC.Domain.Common;

namespace HC.Domain.Entities
{
    public class Province : BaseEntity
    {
        public string Name { get; set; } = default!;

        public virtual ICollection<District> Districts { get; set; } = new List<District>();
    }
}
