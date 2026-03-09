using AutoMapper;
using CashWise.Application.DTOs;
using CashWise.Domain.Entities;

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
