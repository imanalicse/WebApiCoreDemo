using AutoMapper;
using WebApiCoreDemo.Model;

namespace WebApiCoreDemo.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TicketItem, TicketItemViewModel>();
        }
    }
}
