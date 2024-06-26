namespace WebApi.Helpers;

using AutoMapper;
using WebApi.DTOs;
using WebApi.Entities;
using WebApi.Models.Users;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> User
        CreateMap<UserCreateRequest, User>();

        // UpdateRequest -> User
        CreateMap<UserUpdateRequest, User>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                    /*if (x.DestinationMember.Name == "Role" && src.Role == null) return false;*/

                    return true;
                }
            ));

        // Create mapping for UserDTO
        CreateMap<User, UserDTO>();
        CreateMap<UserDTO, User>();
        CreateMap<User, UserDTO>()
            .ForAllMembers(UserDTO => UserDTO.Condition(
                (src, dest, prop) =>
                {
					// ignore both null & empty string properties
					if (prop == null) return false;
					if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

					return true;
				}
                ));

    }
}