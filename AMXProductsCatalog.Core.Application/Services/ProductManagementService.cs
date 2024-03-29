//using AutoMapper;

//namespace AMXProductsCatalog.Core.Application.Services
//{
//    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;

//    public class ProductManagementService : IProductManagementService
//    {
//        private readonly IMapper _mapper;
//       // private readonly IEntityWriteRepository<ProductEntity> _productEntityWriteRepository;

//        public ProductManagementService(IMapper mapper
//            //IEntityWriteRepository<ProductEntity> entityWriteRepository,
//            //IEntityReadRepository<ProductEntity> productCodeEntityReadRepository,
//            //IProviderManagementService providerManagementtService
//            )
//        {
//            _mapper = mapper;
//        }

//        public async Task<long> CreateProduct(Product product)
//        {
//            await VerifyProviderExist(product);
//            var productEntity = BuildProductEntity(product);

//            try
//            {
//                var result = await _productEntityWriteRepository.Create(productEntity);
//                return result;
//            }
//            catch (Exception e)
//            {
//                throw new InvalidOperationException("Error when creating provider");
//            }
//        }

//        public async Task<Product> GetProductByCode(long productCode)
//        {
//            try
//            {
//                var productEntity = await _productCodeEntityReadRepository.Get(productCode);
//                if (productEntity.Status == 2)
//                    return new Product();

//                var provider = await GetProvider(productEntity.ProviderCode);

//                var product = _mapper.Map<Product>(productEntity);
//                product.InsertProvider(provider);

//                return product;
//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("Error when searching for the product by code");
//            }
//        }

//        public async Task<bool> DeleteProductByCode(long productCode)
//        {
//            try
//            {
//                var productEntity = await GetProductEntityForDeleteByCode(productCode);
//                bool result = await _productEntityWriteRepository.UpdateAsync(productEntity);

//                return result;
//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("Error when updating for the product by code");
//            }
//        }

//        public async Task<Product[]> GetAllProducts(int? pageNumber = null, int? pageSize = null)
//        {
//            try
//            {
//                var productEntities = await _productCodeEntityReadRepository.GetAll();

//                var products = await BuildProducts(productEntities);

//                if (pageNumber.HasValue && pageSize.HasValue)
//                {
//                    products = products.Skip((pageNumber.Value - 1) * pageSize.Value)
//                                       .Take(pageSize.Value).ToArray();
//                }

//                return products.ToArray();
//            }
//            catch (Exception ex)
//            {
//                throw new InvalidOperationException("Error when searching all products", ex);
//            }
//        }

//        public async Task<bool> PutProductByCode(Product product)
//        {
//            try
//            {
//                var productEntity = BuildProductEntity(product);
//                return await _productEntityWriteRepository.UpdateAsync(productEntity);
//            }
//            catch (Exception e)
//            {
//                throw new InvalidOperationException("Error when updating provider");
//            }
//        }

//        private ProductEntity BuildProductEntity(Product product)
//        {
//            var productEntity = _mapper.Map<ProductEntity>(product);
//            return productEntity;
//        }

//        private async Task<Product[]> BuildProducts(ProductEntity[] productEntities)
//        {
//            var productList = new List<Product>();
//            foreach (var productEntity in productEntities)
//            {
//                if (productEntity.Status == 2)
//                    continue;

//                var provider = await GetProvider(productEntity.ProviderCode);

//                var product = _mapper.Map<Product>(productEntity);
//                product.InsertProvider(provider);

//                productList.Add(product);
//            }

//            return productList.ToArray();
//        }

//        private async Task VerifyProviderExist(Product product)
//        {
//            await _providerManagementtService.VerifyProviderExistByCode(product.Provider.Code);
//        }

//        private async Task<ProductEntity> GetProductEntityForDeleteByCode(long productCode)
//        {
//            var productEntity = await _productCodeEntityReadRepository.Get(productCode);
//            productEntity.Status = 2;

//            return productEntity;
//        }

//        private async Task<Provider> GetProvider(long code)
//        {
//            var provider = await _providerManagementtService.GetProviderByCode(code);
//            return provider;
//        }
//    }
//}