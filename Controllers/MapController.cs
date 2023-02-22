using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Models;
using TaskApi.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        public MapDbContext db { get; set; }
        public MapController(MapDbContext db)
        {
            this.db = db;

        }
        [HttpGet]
        public List<Map> Get()
        {
            List<Map> Maps = db.Maps.Include(x=>x.MapType).Include(x=>x.MapSubType).ToList();
            return Maps;
        }
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Map? map=db.Maps.Where(x => x.Id == id).FirstOrDefault();
            return Ok(map);
        }
        [HttpPost]
        public IActionResult Post(MapVM mapVM)
        {
            Map map = new Map()
            {
                ClusterRaduis = mapVM.ClusterRaduis,
                IsGeoFencing = mapVM.IsGeoFencing,
                TimeBuffer= mapVM.TimeBuffer,
                LocationBuffer=mapVM.LocationBuffer,
                Duration=mapVM.Duration,
                MapTypeId=mapVM.MapTypeId,
                MapSubTypeId=mapVM.MapSubTypeId

            };
            db.Maps.Add(map);
            db.SaveChanges();
            return Ok(map);

        }
        [HttpPut("{id}")]
        public IActionResult Put(int id,MapVM mapVM)
        {
            Map? map = db.Maps.Where(x => x.Id == id).FirstOrDefault();
            map.ClusterRaduis = mapVM.ClusterRaduis;
            map.IsGeoFencing = mapVM.IsGeoFencing;
            map.TimeBuffer = mapVM.TimeBuffer;
            map.LocationBuffer = mapVM.LocationBuffer;
            map.Duration = mapVM.Duration;
            map.MapTypeId = mapVM.MapTypeId;
            map.MapSubTypeId = mapVM.MapSubTypeId;
            db.Maps.Update(map);
            db.SaveChanges();
            return Ok(map);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Map? map = db.Maps.Where(x => x.Id == id).FirstOrDefault();
            db.Maps.Remove(map);
            db.SaveChanges();
            return Ok("This map Delete Successfully");
        }

    }
}
