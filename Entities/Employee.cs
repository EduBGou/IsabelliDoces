using IsabelliDoces.Interfaces;
using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class Employee() : Entity, INameable
{
    [AttributePresentation(Label = "CPF")]
    public string Cpf { get; init; } = string.Empty;

    [AttributePresentation(Label = "Nome", ListingOrder = 2)]
    public string Name { get; set; } = string.Empty;

    [AttributePresentation(Label = "Telefone")]
    public string Phone { get; set; } = string.Empty;
    
    [AttributePresentation(Label = "Email")]
    public required string Email { get; set; } = string.Empty;
    
    [AttributePresentation(Label = "Senha")]
    public required string Password { get; set; } = string.Empty;
        
    [AttributePresentation(Label = "Endereço")]
    public Address? Home { get; set; }

    public bool VerifyPassword(string senha) => senha == Password;

    public void SetPhone(string phone)
    {
        Phone = phone;
    }

    public void SetEmail(string newEmail)
    {
        Email = newEmail;
    }

    public void SetPassword(string newPassword)
    {
        Password = newPassword;
    }

    public override string ToString() => Name;
}
