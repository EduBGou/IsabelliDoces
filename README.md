# IsabelliDoces

Um **Programa de Console** desenvolvido como trabalho final para a disciplina de **Análise e Projeto de Software (APS)**.

---

## Tecnologias e Ambiente de Desenvolvimento

* **Plataforma de Desenvolvimento:** .NET 8 SDK
* **IDE/Editor:** Visual Studio Code

Para iniciar o programa, basta ter o **.NET 8 SDK** instalado (disponível no site oficial da Microsoft) e executar o comando `dotnet run` no terminal. Se for utilizar o VS Code, recomenda-se baixar a extensão **SQLite 3 Editor** para vizualizar ou editar manualmente as tabelas do banco de dados.

---

## Casos de Uso Implementados (Funcionalidades)

As seguintes funcionalidades principais estão disponíveis no sistema:

1.  **Cadastrar Pedido**
2.  **Alterar Pedido**
3.  **Cancelar Pedido**
4.  **Confirmar Entrega de Pedido**

---

## Cargos e Acessos (Credenciais de Teste)

O sistema possui diferentes cargos, cada um com um conjunto específico de permissões. Use as credenciais abaixo para testar o acesso:

| Cargo | Permissões | E-mail | Senha |
| :--- | :--- | :--- | :--- |
| **SUPERADMIN** | Todas as permissões. | `edu@gmail.com` | `123` |
| **ADMIN** | CRUD de Cliente e Funcionários. | `isa@gmail.com` | `321` |
| **ATENDENTE** | CRUD de Cliente, Cadastrar, Listar, Alterar e Cancelar Pedido. | `isa@gmail.com` | `321` |
| **ENTREGADOR** | Listar Pedido e Confirmar Entrega de Pedido. | `scopel@gmail.com` | `852` |

---

## Dados de Exemplo (Outras Entidades)

O banco de dados já contém algumas entidades pré-cadastradas para fins de teste e demonstração:

### Clientes

| ID | Nome |
| :--- | :--- |
| 1 | Gustavo |
| 2 | Lana |
| 3 | Vinicius |

### Sabores de Bolo

| ID | Sabor |
| :--- | :--- |
| 1 | Chocolate |
| 2 | Morango |
| 3 | Pistache |

### Endereços

| ID | Endereço |
| :--- | :--- |
| 1 | Rua Mato Fino 4226 |
| 2 | Rua Floresta Grossa 9995 |
| 3 | Rua Luiz Hasper 9855 |
| 4 | Rua Luiz Hasper 871 |