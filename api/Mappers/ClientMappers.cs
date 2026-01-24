using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Client;
using api.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace api.Mappers
{
    public static class ClientMappers
    {
        public static ReadClientDto ToReadClientDto(this Client clientModel)
        {
            return new ReadClientDto
            {
                Id= clientModel.Id,
                FirstName=clientModel.FirstName,
                LastName=clientModel.LastName,
                Email=clientModel.Email,
                PhoneNumber=clientModel.PhoneNumber,
                Address=clientModel.Address,
                BirthDate=clientModel.BirthDate,
                EmergencyContactName=clientModel.EmergencyContactName,
                EmergencyContactPhone=clientModel.EmergencyContactPhone,
            };
        }

        public static Client ToClientFromCreateDto(this CreateClientDto clientDto)
        {
            return new Client
            {
                FirstName=clientDto.FirstName,
                LastName=clientDto.LastName,
                Email=clientDto.Email,
                PhoneNumber=clientDto.PhoneNumber,
                Address=clientDto.Address,
                BirthDate=clientDto.BirthDate,
                EmergencyContactName=clientDto.EmergencyContactName,
                EmergencyContactPhone=clientDto.EmergencyContactPhone,
            };
        }
    }
}