namespace OrderApi.Infrastructure.Automapper
{
    using AutoMapper;
    using OrderApi.Domain;
    using OrderApi.Models;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>()
                .ForMember(
                    x => x.OrderState,
                    opt => opt.MapFrom(src => 1));
        }
    }
}
