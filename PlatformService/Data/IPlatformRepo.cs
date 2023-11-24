using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepo : IRepository<Platform>
    {
        void CreatePlatform(Platform platform);
        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
    }
}