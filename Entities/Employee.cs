using IsabelliDoces.Utilities;

namespace IsabelliDoces.Entities;

public class Employee() : Entity
{
    [AttributePresentation(Label = "CPF")]
    public string Cpf { get; init; } = string.Empty;
    
    [AttributePresentation(Label = "Nome", OnListing = true)]
    public required string Name { get; init; } = string.Empty;
    
    [AttributePresentation(Label = "Telefone")]
    public string Phone { get; set; } = string.Empty;
    
    [AttributePresentation(Label = "Email")]
    public required string Email { get; set; } = string.Empty;
    
    [AttributePresentation(Label = "Senha")]
    public required string Password { get; set; } = string.Empty;
        
    [AttributePresentation(Label = "Endereço")]
    public Address? Address { get; set; }

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

    public override string ToString() =>
        $"[{Id}]: {nameof(Name)} = {Name,30}, {nameof(Phone)} = {Phone,10},  {nameof(Email)} = {Email,20},  {nameof(Password)} = {Password,15}, {nameof(Address)} = {Address}";
}
