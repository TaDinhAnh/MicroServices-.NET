using System;
using System.Collections.Generic;
using System.Linq;
using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatFormRepo : IPlatFormRepo
    {
        private readonly AppDBContext _context;

        public PlatFormRepo(AppDBContext context)
        {
            _context = context;
        }
        public void CreatePlatForm(Platform platform)
        {
           if(platform == null){
               throw new ArgumentNullException(nameof(platform));
           }
           _context.PlatForms.Add(platform);
        }

        public IEnumerable<Platform> GetAllFlatForm()
        {
           return _context.PlatForms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
          return _context.PlatForms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}