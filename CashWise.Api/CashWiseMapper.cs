using AutoMapper;
using CashWise.Domain.Entities;
using CashWise.Api.DTOs;

namespace CashWise.Application
{
    public class CashWiseMapper : Profile
    {
        public CashWiseMapper()
        {
            // Request Mapper
            CreateMap<TransactionRequestDTO, Transaction>();
            
            // Reponse Mapper
            CreateMap<Transaction, TransactionResponseDTO>();
        }
    }
}
