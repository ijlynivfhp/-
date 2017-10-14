using MicroOrm.Dapper.Repositories.Attributes;
using MicroOrm.Dapper.Repositories.Attributes.Joins;
using MicroOrm.Dapper.Repositories.Attributes.LogicalDelete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// 汽车实体
    /// </summary>
    [Table("Cars")]
    public class Car:BaseEntity
    { 
        [Required]
        public string CName { get; set; }

        /// <summary>
        /// 不用在数据库创建字段
        /// </summary>
        [NotMapped]
        public byte[] Data { get; set; }

        
        public int CarBrandId { get; set; }

        [LeftJoin("CarBrands", "CarBrandId", "Id")]
        public CarBrand CarBrand { get; set; }

        /// <summary>
        /// 实现软删除（逻辑删除）
        /// </summary>
        [Status, Deleted]
        public bool Deleted { get; set; }

        [UpdatedAt]
        public DateTime? UpdatedAt { get; set; }


    } 
}
