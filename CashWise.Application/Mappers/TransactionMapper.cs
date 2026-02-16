using AutoMapper;
using CashWise.Application.DTOs;
using CashWise.Domain.Entities;

namespace CashWise.Application.Mappers
{
    public class TransactionMapper : Profile
    {
        public TransactionMapper()
        {
            // Request Mapper
            CreateMap<TransactionRequestDTO, Transaction>();
            
            // Reponse Mapper
            CreateMap<Transaction, TransactionResponseDTO>();
        }
    }
}
