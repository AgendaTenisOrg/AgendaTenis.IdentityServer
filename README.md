# AgendaTenis.IdentityServer


## Sobre<a name = "sobre"></a>
AgendaTenis.IdentityServer é um microsserviço da aplicação AgendaTenis cujo objetivo é realizar o cadastro de usuários na aplicação e geração de token JWT necessário para autenticação e autorização nos outros microsserviços da aplicação.
Este serviço é constituído por uma Web Api escrita em .NET 8 e utiliza o SQL Server para persistência de dados (mais detalhes na seção *Descrição Técnica*)

## Endpoints<a name = "endpoints"></a>

### Criar conta
Cadastro simples na plataforma com e-mail e senha.

**Rota**: Api/Identity/CriarConta\
**Método HTTP**: POST\
**Autenticação**: Não precisa estar autenticado\
**Autorização**: N/A

### Gerar token (login)
Gera um token jwt para autenticação do usuário.\
Basta informar o e-mail e senha para obter o token.

**Rota**: Api/Identity/GerarToken\
**Método HTTP**: POST\
**Autenticação**: Não precisa estar autenticado\
**Autorização**: N/A
 
## Descrição técnica<a name = "descricao_tecnica"></a>
Segue a descrição técnica do AgendaTenis.IdentityServer.

- Projeto: AgendaTenis.Core.Identity
- Modelo de dados:
    - Usuários
        - Id: int
        - Email: string 
        - Senha: string
- Banco de Dados: SQL Server
- Acesso a dados: O acesso a dados foi abstraído com uso do EntityFramework.Core
- Observações:
    - Utilizei o "Repository Pattern" para não depender diretamente do EntityFrameworkCore
    - Utilizei o FluentValidation para realizar validações de dados
- Dependências:
    - AgendaTenis.Notificacoes.Core (pacote nuget) versão 1.0.1
    - FluentValidation versão 11.9.2
    - Microsoft.AspNetCore.Authentication.JwtBearer versão 8.0.6
    - Microsoft.EntityFrameworkCore.SqlServer versão 8.0.6
    - Microsoft.Extensions.Identity.Core versão 8.0.6
 
### Docker
- Criei um arquivo Dockerfile na raiz do repositório
- Utilize as instruções presentes na seção *Como executar* do repositório [Agte](https://github.com/AgendaTenisOrg/AgendaTenis.WebApp) para executar a stack inteira da aplicação

## Considerações sobre o projeto
- A implementação atual é bastante simples, mas futuramente vou alterar a implementação para utilizar uma biblioteca robusta como AspNet.Core.Identity ou um serviço como Keycloak.
