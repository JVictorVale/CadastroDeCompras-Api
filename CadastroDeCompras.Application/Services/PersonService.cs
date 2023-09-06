using AutoMapper;
using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Application.DTOs.Validations;
using CadastroDeCompras.Application.Services.Interface;
using CadastroDeCompras.Domain.Entities;
using CadastroDeCompras.Domain.Repositories;

namespace CadastroDeCompras.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    
    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    
    public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
    {
        if (personDTO == null)
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

        var result = new PersonDTOValidator().Validate(personDTO);
        if (!result.IsValid)
            return ResultService.RequestError<PersonDTO>("Problemas de validade!", result);

        var person = _mapper.Map<Person>(personDTO);
        var data = await _personRepository.CreateAsync(person);
        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }
}