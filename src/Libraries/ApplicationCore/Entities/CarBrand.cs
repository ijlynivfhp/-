using MicroOrm.Dapper.Repositories.Attributes.Joins;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    /// <summary>
    /// 汽车品牌实体
    /// </summary>
    [Table("CarBrands")]
    public class CarBrand:BaseEntity
    {
        /// <summary>
        /// 品牌名字
        /// </summary>
        [Required]
        [Column("BrandName")]
        public string BrandName { get; set; }

        
        [LeftJoin("Cars", "Id", "CarBrandId")] 
        public List<Car> Cars { get; set; }


        public CarBrand()
        {
            
        } 
    }
}
