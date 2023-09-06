using AutoMapper;
using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Domain.Entities;

namespace CadastroDeCompras.Application.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Person, PersonDTO>();
    }
}