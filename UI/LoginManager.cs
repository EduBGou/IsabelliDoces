using IsabelliDoces.Data;
using IsabelliDoces.Entities;
using Microsoft.EntityFrameworkCore;

namespace IsabelliDoces.UI;

public static class LoginManager
{
    private static Employee? User { get; set; }

    public static Employee GetUser()
    {
        if (User is null)
        {
            throw new InvalidOperationException("User not logged in. Please attempt login first.");
        }
        return User;
    }

    public static async Task Login(IsabelliDocesContext dbContext)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Informe seu email:");
            string? email = Console.ReadLine();

            Console.WriteLine("Informe sua senha:");
            string? senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                Console.WriteLine("Preencha os campos adequadamente. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                continue;
            }

            Employee? funcionario = await dbContext.Employees
                .FirstOrDefaultAsync(e => e.Email == email);

            if (funcionario is null)
            {
                Console.WriteLine("O funcionário não foi encontrado. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                continue;
            }

            if (!funcionario.VerifyPassword(senha))
            {
                Console.WriteLine("Senha Incorreta! Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
                continue;
            }
            User = funcionario;
            break;
        }
        await MenuManager.MainMenu.Display(dbContext);
    }
}
