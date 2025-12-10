// using APS.Classes.Models;
// using IsabelliDoces.UI;

// namespace IsabelliDoces.UI.Menus;

// public class LoginMenu() : Menu
// {
//     private static Employee? User { get; set; }

//     public Employee GetUser()
//     {
//         if (User is null)
//         {
//             Console.WriteLine("Faça login para acessar o sistema. Pressione qualquer tecla para continuar...");
//             Console.ReadKey();
//             Display();
//         }
//         return User!;
//     }

//     public override void Display()
//     {
//         while (true)
//         {
//             Console.Clear();
//             Console.WriteLine("Informe seu email:");
//             string? email = Console.ReadLine();

//             Console.WriteLine("Informe sua senha:");
//             string? senha = Console.ReadLine();

//             if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
//             {
//                 Console.WriteLine("Preencha os campos adequadamente. Pressione qualquer tecla para tentar novamente.");
//                 Console.ReadKey();
//                 continue;
//             }

//             Employee? funcionario = DAOManager.EmployeeDAO.GetByEmail(email);

//             if (funcionario is null)
//             {
//                 Console.WriteLine("O funcionário não foi encontrado. Pressione qualquer tecla para tentar novamente.");
//                 Console.ReadKey();
//                 continue;
//             }

//             if (!funcionario.VerifyPassword(senha))
//             {
//                 Console.WriteLine("Senha Incorreta! Pressione qualquer tecla para tentar novamente.");
//                 Console.ReadKey();
//                 continue;
//             }
//             User = funcionario;
//             break;
//         }

//         MenuManager.MainMenu.Display();
//     }
// }