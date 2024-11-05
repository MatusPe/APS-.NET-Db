using Microsoft.EntityFrameworkCore;
using ReactApp2.Server.DateBase;
using ReactApp2.Server.Interface;
using ReactApp2.Server.Repositary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Register
builder.Services.AddDbContext<ApplicationDbContext>(options=>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers().
    AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddScoped<IUserRepositary, UserRepositary>();
builder.Services.AddScoped<ICashExpenseRepositary, CashExpenseRepositary>();
builder.Services.AddScoped<IProductsRepositary, ProductRepositary>();
builder.Services.AddScoped<IWalletRepositary, WalletRepositary>();
builder.Services.AddScoped<ILoanRepositary, LoanRepositary>();
builder.Services.AddScoped<IInvestmentRepositary, InvestmentRepositary>();
builder.Services.AddScoped<IBudgetRepositary, BudgetRepositary>();
builder.Services.AddScoped<IExpensesRepositary, ExpenseRepositary>();
builder.Services.AddScoped<ITransactionRepositary, TransactionRepositary>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.MapControllers();
app.Run();
