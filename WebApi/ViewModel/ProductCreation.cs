using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.ViewModel
{
    public class ProductCreation
    {
        [Display(Name="产品名字")]
        [Required(ErrorMessage ="{0}是必填项")]
        [StringLength(10,MinimumLength =2,ErrorMessage ="{0}长度必须不小于{2}，不超过{1}")]
        public string Name { get; set; }

        [Display(Name="产品价格")]
        [Required(ErrorMessage ="{0}是必填项")]
        [Range(0,Double.MaxValue,ErrorMessage ="{0}必须大于{1}")]
        public decimal Price { get; set; }

        [Display(Name="描述")]
        [MaxLength(100,ErrorMessage ="{0}的长度不能超过{1}个字符")]
        public string Description { get; set; }
    }
}
