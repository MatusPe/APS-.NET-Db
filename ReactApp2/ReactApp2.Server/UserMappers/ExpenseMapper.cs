using ReactApp2.Server.DTOs;
using ReactApp2.Server.Entity;

namespace ReactApp2.Server.UserMappers;

public static class ExpenseMapper
{
    public static CashExpenses fromExpenseDTOsToExpense(this ExpanseDTOs expanseDTOs, int ExpensesId)
    {

        return new CashExpenses()
        {
           
            Type = expanseDTOs.Type,
            Company = expanseDTOs.Company,
            Quantity = expanseDTOs.Quantity,
            TotalPriceDPH = expanseDTOs.TotalPriceDPH,
            TotalPriceNotDPH = expanseDTOs.TotalPriceNotDPH,
            ExpendDate = expanseDTOs.ExpendDate,
            Description = expanseDTOs.Description,
            ExpensesId = ExpensesId,
            
            
            
            
        };


    }
}