using MicroOrm.Dapper.Repositories.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entities
{
        public class BaseEntity<TKey> where TKey :IEquatable<TKey>
    {
        [Key, Identity]
        public TKey Id { get; set; }
    }

    public class BaseEntity: BaseEntity<int>
    {
        
    }
}
