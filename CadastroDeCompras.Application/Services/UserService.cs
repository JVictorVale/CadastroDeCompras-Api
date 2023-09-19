using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Application.DTOs.Validations;
using CadastroDeCompras.Application.Services.Interface;
using CadastroDeCompras.Domain.Authentication;
using CadastroDeCompras.Domain.Repositories;

namespace CadastroDeCompras.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenGeneretor _tokenGeneretor;

        public UserService(IUserRepository userRepository, ITokenGeneretor tokenGeneretor)
        {
            _userRepository = userRepository;
            _tokenGeneretor = tokenGeneretor;
        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(UserDTO userDTO)
        {
            if (userDTO == null)
                return ResultService.Fail<dynamic>("Objeto deve ser informado");

            var validator = new UserDTOValidator().Validate(userDTO);

            if (!validator.IsValid)
                return ResultService.RequestError<dynamic>("Problemas de validação", validator);

            var user = await _userRepository.GetUserByEmailAndPasswordAsync(userDTO.Email, userDTO.Password);
            if (user == null)
                return ResultService.Fail<dynamic>("Usuário ou senha não encontrado!");

            return ResultService.Ok(_tokenGeneretor.Generator(user));
        }
    }
}