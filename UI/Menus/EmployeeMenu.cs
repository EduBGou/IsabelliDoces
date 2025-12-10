// using IsabelliDoces.UI;

// namespace IsabelliDoces.UI.Menus;

// public class EmployeeMenu() : Menu
// {
//     protected override string MenuTitle => "FUNCIONÁRIO";
//     public override Menu PreviousMenuHierarchy => MenuManager.MainMenu;

//     protected override MenuOption[] AllOptions => [
//         new("Listar/Alterar Funcionários", ListEmployee, Permission.CRUD_EMPLOYEE),
//         new("Cadastrar Funcionário", CreateEmployee, Permission.CRUD_EMPLOYEE),
//     ];

//     private void ListEmployee()
//     {
//         MenuExtention.Listing<Employee, EmployeeDTO>();

//         if (!MenuExtention.Continue("ver detalhes de algum deles"))
//         {
//             PreviousMenuHierarchy.Display();
//             return;
//         }

//         Employee gotEmployee = MenuExtention.SelectionById<Employee, EmployeeDTO>();
//         MenuExtention.ModelDetails<Employee, EmployeeDTO>(gotEmployee);

//         if (!MenuExtention.Continue("alterar este funcionário"))
//         {
//             PreviousMenuHierarchy.Display();
//             return;
//         }

//         var tempEmployeeDTO = AutoMapper.Map<Employee, EmployeeDTO>(gotEmployee);
//         tempEmployeeDTO = MenuExtention.DtoFromInputSimpleFields(gotEmployee, tempEmployeeDTO);

//         if (MenuExtention.Continue($"alterar o Endereço"))
//         {
//             var newAdress = MenuExtention.UpdateForingKeyInput<Address, AddressDTO>();
//             tempEmployeeDTO = tempEmployeeDTO with { Address = newAdress };
//         }

//         // Change to Role Contract Menu
//         if (MenuExtention.Continue("ver os contratos de Cargo dele"))
//         {
//             var roleContracts = DAOManager.RoleContractDAO.GetRoleContractsOf(gotEmployee);
//             MenuExtention.PrintList<RoleContract, RoleContractDTO>(roleContracts);

//             RoleContractDTO tempRoleContractDTO = new();
//             if (MenuExtention.Continue($"adicionar Contrato de Cargo"))
//             {
//                 tempRoleContractDTO = MenuExtention.DtoFromInputSimpleFields(new RoleContract(), tempRoleContractDTO, true);
//                 var newRole = MenuExtention.UpdateForingKeyInput<Role, RoleDTO>();
//                 tempRoleContractDTO = tempRoleContractDTO with { Role = newRole };
//                 var newRoleContract = DAOManager.RoleContractDAO.Create(tempRoleContractDTO);
//                 MenuExtention.ModelDetails<RoleContract, RoleContractDTO>(newRoleContract);
//             }

//             if (MenuExtention.Continue($"encerrar contrato de cargo"))
//             {
//                 RoleContract gotRoleContract = MenuExtention.SelectionById<RoleContract, RoleContractDTO>();
//                 tempRoleContractDTO = MenuExtention.DtoFromInputSimpleFields(gotRoleContract, tempRoleContractDTO);
//                 DAOManager.RoleContractDAO.Update(gotRoleContract.Id, tempRoleContractDTO);
//             }
//         }

//         DAOManager.EmployeeDAO.Update(gotEmployee.Id, tempEmployeeDTO);

//         Console.WriteLine("Pressione qualquer tecla para voltar à tela anterior.");
//         Console.ReadKey();
//         PreviousMenuHierarchy.Display();
//     }

//     private void CreateEmployee()
//     {

//     }
// }