using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApi.Models
{
    public class MapSubType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("MapType")]
        public int MapTypeId { get; set; }
        public MapType MapType { get; set; }

    }
}
