using AutoMapper;
using ItemAPI.Models;
using ItemAPI.Models.Dto;

namespace ItemAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ItemDto, Item>();
                config.CreateMap<Item, ItemDto>();
                config.CreateMap<UpsertItemDto, Item>()
                .ForMember(dest => dest.Updated_at, opt => opt.Ignore())
                .ForMember(dest => dest.Updated_at, opt => opt.Ignore());
            });

            return mappingConfig;
        }
    }
}
