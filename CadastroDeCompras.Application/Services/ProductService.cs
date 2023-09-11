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
}