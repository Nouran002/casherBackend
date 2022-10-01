using AutoMapper;
using casher.Properties.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace casher.Properties.Mapper
{
    public class MappingProfile:Profile
    {
            public MappingProfile()
            {
                CreateMap<CustomerRegister, Customerr>();
                CreateMap<AdminRegister, Adminn>();
                CreateMap<ProductDetails, Productt>();
                CreateMap<catDetails, Categoryy>();

        }
    }
    }

