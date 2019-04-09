// ***********************************************************************
// Assembly         : FrederickNguyen.ApplicationLayer
// Author           : thangnd
// Created          : 07-09-2018
//
// Last Modified By : thangnd
// Last Modified On : 07-09-2018
// ***********************************************************************
// <copyright file="MappingEntityToDto.cs" company="FrederickNguyen.ApplicationLayer">
//     Copyright (c) by adguard. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using AutoMapper;
using iStorage.Domain.AggregatesModels.Users;
using iStorage.Business.DataTransferObjects;

namespace iStorage.Business.MappingConfigurations
{
    /// <summary>
    /// Class MappingEntityToDto.
    /// </summary>
    public class MappingEntityToDtoProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingEntityToDtoProfile" /> class.
        /// </summary>
        public MappingEntityToDtoProfile()
        {
            CreateMap<User, UserDTO>();
        }
    }
}
