
---

## 🏷️ **NoteSphere**

> Um espaço organizado para suas anotações categorizadas, simples de usar, acessível de qualquer lugar.

---

## 🧱 Arquitetura Geral da Aplicação

```
┌──────────────┐           HTTP REST          ┌────────────────────────┐
│ App Mobile   │  ─────────────────────────▶  │ API ASP.NET WebAPI     │
│ (.NET MAUI)  │                              │ (.NET 7 + EF Core)     │
└──────────────┘  ◀─────────────────────────  │                        │
        ▲                                      │ SQLite (banco local)   │
        │                                      └────────────────────────┘
   Interface Gráfica                           Backend e Persistência
```

---

## 📂 Estrutura do Projeto

```
NoteSphere/
├── MyNotes.API/          # Projeto backend com WebAPI
│   ├── Controllers/      # Lida com as requisições HTTP
│   ├── Models/           # Define as entidades (Note, Category)
│   ├── Data/             # DbContext para Entity Framework
│   └── Program.cs        # Inicialização da API
├── MyNotes.App/          # Projeto frontend com .NET MAUI
│   ├── Views/            # Telas (ex: lista de notas)
│   ├── Services/         # Comunicação HTTP com a API
│   ├── Models/           # Estruturas de dados locais
│   └── App.xaml.cs       # Ponto de entrada do app
```

---

## 🔄 Funcionamento da API (Backend - MyNotes.API)

### ✳️ Objetivo

Gerenciar as **Notas** que pertencem a uma **Categoria**, permitindo operações de CRUD através de endpoints HTTP REST.

### 🛠️ Tecnologias

* ASP.NET WebAPI
* Entity Framework Core
* SQLite

### 📌 Endpoints

| Verbo  | Rota              | Ação                        |
| ------ | ----------------- | --------------------------- |
| GET    | `/api/notes`      | Retorna todas as notas      |
| GET    | `/api/notes/{id}` | Retorna uma nota específica |
| POST   | `/api/notes`      | Cria uma nova nota          |
| PUT    | `/api/notes/{id}` | Atualiza uma nota existente |
| DELETE | `/api/notes/{id}` | Remove uma nota             |

### 🗃️ Banco de Dados

* Entidades:

  * `Category`: `Id`, `Name`, `Notes`
  * `Note`: `Id`, `Title`, `Content`, `CategoryId`

* Relacionamento:

  * Uma categoria possui várias notas (1\:N)

### 🔗 Comunicação com o banco

Feita automaticamente pelo **Entity Framework**, que traduz os comandos C# em SQL para o banco SQLite.

---

## 📲 Funcionamento do App (Frontend - MyNotes.App)

### ✳️ Objetivo

Oferecer uma interface simples para o usuário **visualizar, cadastrar, editar e excluir notas**, integrando-se diretamente com a API.

### 🛠️ Tecnologias

* .NET MAUI (suporte Android, iOS, Windows)
* MVVM (Model-View-ViewModel simplificado)

### 🧩 Componentes

#### 🔹 `Views/NotesPage.xaml`

Interface com uma lista de notas (CollectionView) e visualização básica de título e conteúdo.

#### 🔹 `Services/NoteService.cs`

Classe que lida com chamadas HTTP para a API:

* `GetNotesAsync()`: busca todas as notas
* `CreateNoteAsync()`, `UpdateNoteAsync()`, `DeleteNoteAsync()` → CRUD via HTTP

#### 🔹 `Models/Note.cs`

Estrutura usada no app para mapear os dados da API.

### 🔌 Conexão com a API

Utiliza `HttpClient` com endereço:

```csharp
BaseAddress = new Uri("http://<SEU_IP_LOCAL>:5000/api/");
```

---

## 🔁 Fluxo Completo

1. O usuário abre o app e vê uma lista de notas via chamada `GET /api/notes`
2. Ao criar uma nota:

   * Preenche título e conteúdo
   * O app envia um `POST /api/notes` para a API
3. A API grava os dados no banco SQLite
4. A resposta volta ao app e atualiza a lista exibida
5. Edição e exclusão funcionam com `PUT` e `DELETE`

---

## ✅ Benefícios da Arquitetura

* 🔗 **Separação de responsabilidades**: frontend e backend desacoplados
* 🚀 **Escalável**: o backend pode ser hospedado na nuvem
* 🌐 **Multi-plataforma**: app roda em Android, iOS e Windows
* 📦 **Persistência local eficiente** com EF Core e SQLite

---




