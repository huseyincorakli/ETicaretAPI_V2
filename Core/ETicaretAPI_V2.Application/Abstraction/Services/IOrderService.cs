﻿using ETicaretAPI_V2.Application.DTOs.Order;

namespace ETicaretAPI_V2.Application.Abstraction.Services
{
    public interface IOrderService
    {
        Task CreateOrderAsync(CreateOrder createOrder);
        Task<ListOrder> GetAllOrdersAsync(int page,int size,bool isCompleted);
        Task<SingleOrder> GetOrderByIdAsync(string id);
        Task<(bool, CompletedOrderDTO)> CompleteOrderAsync(string id);
    }
}
