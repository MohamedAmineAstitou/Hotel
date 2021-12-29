using Hotel_Astitou_Backend.Model;

namespace Hotel_Astitou_Backend.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly HotelAstitouContext context;

        protected BaseRepository(HotelAstitouContext context)
        {
            this.context = context;
        }
    }
}