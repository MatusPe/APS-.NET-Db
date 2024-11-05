using System.ComponentModel.DataAnnotations;

namespace ReactApp2.Server.Entity;

public class User
{
    [Key]
    public int id{get;set;}
    
    public String Username{get;set;}
    public String Password{get;set;}
    public String FirstName{get;set;}
    public String Lastname{get;set;}
    public String Email{get;set;}
    public DateTime Birthday{get;set;}
    public String Gender{get;set;}
    public String State{get;set;}
    public String City{get;set;}
    public String Address{get;set;}
    public String ZipCode{get;set;}
    public String Phone{get;set;}
    
    public List<Wallet> Wallets{get;set;}
    
    
    
}