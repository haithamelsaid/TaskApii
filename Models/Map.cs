using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskApi.Models
{
    public class Map
    {
        [Key]
        public int Id { get; set; }
        public string ClusterRaduis { get; set; }
        public bool IsGeoFencing { get; set; }
        public double TimeBuffer { get; set; }
        public double LocationBuffer { get; set; }
        public int Duration { get; set; }

        [ForeignKey("MapType")]
        public int MapTypeId { get; set; }
        public MapType MapType{ get; set; }
        
        [ForeignKey("MapSubType")]
        public int MapSubTypeId { get; set; }
        public MapSubType MapSubType { get; set; }


    }
}
