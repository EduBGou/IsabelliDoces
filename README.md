# IsabelliDoces

Um **Programa de Console** desenvolvido como trabalho final para a disciplina de **Análise e Projeto de Software (APS)**.

---

## Tecnologias e Ambiente de Desenvolvimento

* **Framework:** .NET 8
* **Linguagem:** C#
* **Ambiente de Desenvolvimento (IDE/Editor):** Visual Studio Code

### Extensões Essenciais do VS Code

Para garantir o funcionamento e facilitar o desenvolvimento, as seguintes extensões são recomendadas:

* **C#**
* **C# Dev Kit**
* **.NET Install Tool**
* **SQLite 3 Editor** (Útil para vizualizr ou editar manualmente os valores dentro do banco de dados)

---

## Casos de Uso Implementados (Funcionalidades)

As seguintes funcionalidades principais estão disponíveis no sistema:

1.  **Cadastrar Pedido**
2.  **Listar Pedido**
3.  **Alterar Pedido**
4.  **Cancelar Pedido**
5.  **Confirmar Entrega de Pedido**

---

## Cargos e Acessos (Credenciais de Teste)

O sistema possui diferentes cargos, cada um com um conjunto específico de permissões. Use as credenciais abaixo para testar o acesso:

| Cargo | Permissões | E-mail | Senha |
| :--- | :--- | :--- | :--- |
| **SUPERADMIN** | Todas as permissões. | `edu@gmail.com` | `123` |
| **ADMIN** | CRUD de Cliente e Funcionários. | `isa@gmail.com` | `321` |
| **ATENDENTE** | Cadastrar, Listar, Alterar e Cancelar Pedido. | `isa@gmail.com` | `321` |
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