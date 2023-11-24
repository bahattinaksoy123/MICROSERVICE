using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepo(AppDbContext context) : RepositoryBase<AppDbContext, Platform>(context), IPlatformRepo
    {
        public void CreatePlatform(Platform platform)
        {
            Add(platform);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return GetAll();
        }

        public Platform GetPlatformById(int id)
        {
            return Get(i => i.Id == id);
        }
    }
}