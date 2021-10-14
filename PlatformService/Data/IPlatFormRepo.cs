using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data{
    public interface IPlatFormRepo{
        bool SaveChanges();

        IEnumerable<Platform> GetAllFlatForm();

        Platform GetPlatformById(int id);

        void CreatePlatForm(Platform platform);
    }
}