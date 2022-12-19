using Data;
using Models;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesForModels
{
    public class AreaService
    {
        private AppDbContext _context;
       public AreaService(AppDbContext context)
        {

            _context = context;
        }


        public void AddArea(Area area)
        {
            var _area = new Area()
            {
                Sity = area.Sity,
                State = area.State,
                PostCode = area.PostCode,
                Market = area.Market
            };
            _context.Areas.Add(_area);
            _context.SaveChanges();
        }

        //GetAll
        public List<Area> GetAllAreas() => _context.Areas.ToList();

        //GetById
        public Area GetAreaById(int areaId) => _context.Areas.FirstOrDefault(n => n.Id == areaId);
        
        //Update
        public Area UpdateAreaById(int areaId, AreaVM area)
        {
            var _area = _context.Areas.FirstOrDefault(n => n.Id == areaId);
            if (_area != null)
            {
                _area.Sity = area.Sity;
                _area.State = area.State;
                _area.PostCode = area.PostCode;
                _area.Market = area.Market;
                _context.SaveChanges();
            }
            return _area;   
        }
        
        //Delete
        public void DeleteAreaById(int areaId)
        {
            var _area = _context.Areas.FirstOrDefault(n => n.Id == areaId);
            if(_area != null)
            {
                _context.Areas.Remove(_area);
                _context.SaveChanges();
            }
        }
    }
}
