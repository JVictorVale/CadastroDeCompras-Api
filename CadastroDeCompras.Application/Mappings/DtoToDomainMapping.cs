using AutoMapper;
using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Application.Mappings;

public class DtoToDomainMapping : Profile
{
    public DtoToDomainMapping()
    {
        CreateMap<PersonDTO,Person>();
    }
}