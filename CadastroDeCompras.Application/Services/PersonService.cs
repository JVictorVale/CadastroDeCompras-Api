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
            return ResultService.RequestError<PersonDTO>("Problema de validação dos dados informados!", result);

        var person = _mapper.Map<Person>(personDTO);
        var data = await _personRepository.CreateAsync(person);
        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }

    public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
    {
        var people = await _personRepository.GetPeopleAsync();
        return ResultService.Ok<ICollection<PersonDTO>>(_mapper.Map<ICollection<PersonDTO>>(people));
    }

    public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");
                
        return ResultService.Ok(_mapper.Map<PersonDTO>(person));
    }

    public async Task<ResultService> UpdateAsync(PersonDTO personDTO)
    {
        if (personDTO == null)
            return ResultService.Fail("Dados da pessoa devem ser informados!");

        var validation = new PersonDTOValidator().Validate(personDTO);
        if (!validation.IsValid)
            return ResultService.RequestError("Problema de validação dos dados informados!", validation);

        var person = await _personRepository.GetByIdAsync(personDTO.Id);
        if(person == null)
            return ResultService.Fail("Pessoa não encontrada!");

        person = _mapper.Map<PersonDTO, Person>(personDTO, person);

        await _personRepository.EditAsync(person);
        return ResultService.Ok("Pessoa editada!");
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada!");

        await _personRepository.DeleteAsync(person);
        return ResultService.Ok($"Pessoa do id: {id} foi deletada!");
    }
}