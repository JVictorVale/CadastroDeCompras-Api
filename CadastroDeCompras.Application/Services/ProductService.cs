using AutoMapper;
using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Application.DTOs.Validations;
using CadastroDeCompras.Application.Services.Interface;
using CadastroDeCompras.Domain.Entities;
using CadastroDeCompras.Domain.Repositories;

namespace CadastroDeCompras.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;


    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
        if (productDTO == null)
            return ResultService.Fail<ProductDTO>("Objeto deve ser informado!");

        var result = new ProductDTOValidator().Validate(productDTO);
        if (!result.IsValid)
            return ResultService.RequestError<ProductDTO>("Problemas na validação!", result);

        var product = _mapper.Map<Product>(productDTO);
        var data = await _productRepository.CreateAsync(product);
        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }

    public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
        var products = await _productRepository.GetByIdAsync(id);
        if (products == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado!");

        return ResultService.Ok(_mapper.Map<ProductDTO>(products));
    }

    public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
    {
        var product = await _productRepository.GetProductsAsync();
        return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(product));
    }

    public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
    {
        if(productDTO == null)
            return ResultService.Fail("Dados do produto devem ser informados!");

        var validation = new ProductDTOValidator().Validate(productDTO);
        if(!validation.IsValid)
            return ResultService.RequestError("Problema de validação dos dados informados!", validation);

        var product = await _productRepository.GetByIdAsync(productDTO.Id);
        if(product == null)
            return ResultService.Fail("Produto não encontrado!");

        product = _mapper.Map<ProductDTO, Product>(productDTO, product);

        await _productRepository.EditAsync(product);
        return ResultService.Ok("Produto editado!");
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var product = await _productRepository.GetByIdAsync(id);
        if(product == null)
            return ResultService.Fail("Produto não encontrado!");

        await _productRepository.DeleteAsync(product);
        return ResultService.Ok($"Produto do id: {id} foi deletado!");
    }
}