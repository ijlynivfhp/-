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
        public  override int Id { get; set; }
        /// <summary>
        /// 品牌名字
        /// </summary> 
        public string  Name { get; set; }

        
        


        public CarBrand()
        {
            
        } 
    }
}
