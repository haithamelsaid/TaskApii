    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskApi.Models;

namespace TaskApi.ViewModels
{
    public class MapVM
    {
        public string ClusterRaduis { get; set; }
        public bool IsGeoFencing { get; set; }
        public double TimeBuffer { get; set; }
        public double LocationBuffer { get; set; }
        public int Duration { get; set; }
        public int MapTypeId { get; set; }
        public int MapSubTypeId { get; set; }
    }
}
