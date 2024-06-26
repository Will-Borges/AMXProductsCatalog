﻿using AutoMapper;

namespace AMXProductsCatalog.Automapper
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Orders;
    using AMXProductsCatalog.Core.Domain.Domains.Orders.CreateOrders;
    using AMXProductsCatalog.Core.Domain.Domains.Products;
    using AMXProductsCatalog.Core.Domain.Domains.Products.GetProduct;
    using AMXProductsCatalog.Core.Domain.Domains.Products.UpdateCar;
    using AMXProductsCatalog.Core.Domain.Domains.Stocks;
    using AMXProductsCatalog.Core.Domain.Domains.Stocks.GetStock;
    using AMXProductsCatalog.Core.Domain.Domains.Users;
    using AMXProductsCatalog.Core.Domain.Entities.Orders.CreateOrder;
    using AMXProductsCatalog.Core.Domain.Entities.Products;
    using AMXProductsCatalog.Core.Domain.Entities.Stocks;
    using AMXProductsCatalog.Core.Domain.Entities.Users;
    using AMXProductsCatalog.Views.Authentication;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Request;
    using AMXProductsCatalog.Views.Orders.CreateOrder.Response;
    using AMXProductsCatalog.Views.Orders.GetOrder.Response;
    using AMXProductsCatalog.Views.Products.CreateCar.Request;
    using AMXProductsCatalog.Views.Products.GetCar.Response;
    using AMXProductsCatalog.Views.Products.UpdateCar.Request;
    using AMXProductsCatalog.Views.Stocks.GetStock.Response;
    using AMXProductsCatalog.Views.Users;

    public class ProductsCatalogProfile : Profile
    {
        public ProductsCatalogProfile()
        {
            MapCarProduct();
            MapStock();
            MapOrder();
            MapUser();
        }

        private void MapUser()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<User, UserEntity>();

            CreateMap<UserEntity, User>();

            CreateMap<UserAuthenticationDTO, User>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Role, opt => opt.Ignore());
        }

        private void MapOrder()
        {
            // Items

            CreateMap<StockItem, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<OrderItem, GetOrderItemResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            // DTOs

            CreateMap<CreateOrderRequestDTO, CreateOrder>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, CreateOrderResponseDTO>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<OrderItem, CreateOrderItemResponseDTO>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Order, GetOrderResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            // Entities

            CreateMap<Order, OrderEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.OrderItemsId, opt => opt.MapFrom(src => src.Items.Select(item => item.Id).ToArray()))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.TotalPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

            CreateMap<StockItemEntity, OrderItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => new BaseProduct { Id = src.ProductId }))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<OrderItem, OrderItemEntity>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<CreateOrder, OrderItemEntity>()
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }

        private void MapStock()
        {
            // Responses

            CreateMap<GetStockResponse, GetStockResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StockItems, opt => opt.MapFrom(src => src.StockItems));

            CreateMap<GetStockItemResponse, GetStockItemResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.LastUpdated));

            CreateMap<StockItemEntity, StockItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => src.LastUpdated));
        }

        private void MapCarProduct()
        {
            // Requests

            CreateMap<CreateCarProductRequestDTO, CarProduct>()
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<UpdateCarProductRequestDTO, UpdateCarProductRequest>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));


            // Responses

            CreateMap<CarProductEntity, GetCarProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<GetCarProductResponse, GetCarProductResponseDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));


            // Entitys

            CreateMap<CarProduct, CarProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<UpdateCarProductRequest, CarProductEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            // Domains

            CreateMap<CarProductEntity, CarProduct>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.Year))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
