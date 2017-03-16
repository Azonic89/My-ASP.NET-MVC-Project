using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CarSystem.Data.Models.Contracts;
using CarSystem.ValidationConstants;

namespace CarSystem.Data.Models
{
    public class Category : ICategory
    {
        private ICollection<VehicleModel> vehicleModel;

        public Category()
        {
            this.vehicleModel = new HashSet<VehicleModel>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(ModelsValidationConstants.CategoryNameMinLength)]
        [MaxLength(ModelsValidationConstants.CategoryNameMaxLength)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels
        {
            get
            {
                return this.vehicleModel;
            }

            set
            {
                this.vehicleModel = value;
            }
        }
    }
}
