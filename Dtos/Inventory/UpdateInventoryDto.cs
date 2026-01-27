using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetSavingBackend.DTOs.Inventory
{
    public class UpdateInventoryDTO
    {
        [MaxLength (100, ErrorMessage ="El nombre no puede superar los 100 caracteres")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Column(TypeName= "decimal(10,2)")]
        public decimal? UnitValue { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int? Stock { get; set; }

        [MaxLength(100, ErrorMessage ="EL nombre del proveedor no puede superar los 100 caracteres")]
        public string? SupplerName { get; set; }
    }
}