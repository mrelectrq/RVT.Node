using AutoMapper;
using RVT_Node_BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace RVT_Node_BusinessLayer.Mapper
{
    public class Mapping
    {
        private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProile>();
            });

            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper => _mapper.Value;
    }

    internal class MappingProile : Profile
    {
        public MappingProile()
        {
            CreateMap<NodeConfig, Node>();
        }
    }
}
