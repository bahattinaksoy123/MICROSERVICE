using System.ComponentModel.DataAnnotations;
using PlatformService.Data;

namespace PlatformService.Models
{
    public class Platform : IEntity
    {
        public Platform()
        {
            
        }
        
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Publisher { get; set; }
        
        [Required]
        public string Cost { get; set; }
    }
}