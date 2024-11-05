using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Entity;
using ReactApp2.Server.Interface;

namespace ReactApp2.Server.Repositary;

public class LoanRepositary:ILoanRepositary
{
    public readonly ApplicationDbContext _context;

    public LoanRepositary(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }
    
    public async Task<List<Loan>> GetAllLoanAsync()
    {
        var Loans=await _context.Loans.ToListAsync();
        return Loans;
        
    }

    public async Task<Loan?> GetLoanByIdAsync(int id)
    {
        var Loan = await _context.Loans.FirstOrDefaultAsync(x => x.Id == id);
        if (Loan == null)
        {
            return null;
        }
        return Loan;
    }
    
    public async Task<Loan> AddLoanAsync(Loan loan)
    {
        await _context.AddAsync(loan);
        await _context.SaveChangesAsync();
        return loan;
        
    }

    public async Task<Loan> UpdateLoanAsync(int id, Loan loan)
    {
        var oldLoan = await _context.Loans.FindAsync(id);
        if (oldLoan == null)
        {
            return null;
        }
        oldLoan.LoanName = loan.LoanName;
        oldLoan.TypeLoad = loan.TypeLoad;
        oldLoan.Lender = loan.Lender;
        oldLoan.LoanAmount = loan.LoanAmount;
        oldLoan.InterestRate = loan.InterestRate;
        oldLoan.term=oldLoan.term;
        oldLoan.StartDate = loan.StartDate;
        oldLoan.EndDate = loan.EndDate;
        oldLoan.mounthlyPayment = loan.mounthlyPayment;
        oldLoan.totalPayment = loan.totalPayment;
        oldLoan.Status = loan.Status;
        oldLoan.Description = loan.Description;
        
        return loan;
    }

    


    public async Task<Loan?> DeleteLoanAsync(int id)
    {
        var loan = await _context.Loans.FindAsync(id);
        if (loan == null)
        {
            return null;
        }
        _context.Loans.Remove(loan);
        _context.SaveChanges();
        return loan;
    }

    public Task<Loan> GetLoanbyNameAsync(string Name)
    {
        throw new NotImplementedException();
    }
}