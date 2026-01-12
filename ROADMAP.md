# Finance Control API — Guia de Implementação por Fases ✅

> Projeto em ASP.NET Core (.NET 8) para treinar: **POO, Algoritmos, DI, Testes Unitários, REST, Exceptions, Refatoração/SOLID e conceitos básicos de Microserviços**.

---

## 📚 Sumário
- [Visão Geral](#-visão-geral)
- [Stack e Arquitetura](#-stack-e-arquitetura)
- [Checklist Global](#-checklist-global)
- [Fase 1 — Domínio e POO](#fase-1--domínio-e-poo)
- [Fase 2 — DI, Repositórios e Serviços](#fase-2--di-repositórios-e-serviços)
- [Fase 3 — Validação e Exceptions](#fase-3--validação-e-exceptions)
- [Fase 4 — REST e Endpoints](#fase-4--rest-e-endpoints)
- [Fase 5 — Testes Unitários](#fase-5--testes-unitários)
- [Fase 6 — Algoritmos (Recorrência, Categorias, Orçamento)](#fase-6--algoritmos-recorrência-categorias-orçamento)
- [Fase 7 — Refatoração e SOLID](#fase-7--refatoração-e-solid)
- [Fase 8 — Microserviços básicos](#fase-8--microserviços-básicos)
- [Como rodar](#como-rodar)
- [Decisões de Arquitetura](#decisões-de-arquitetura)
- [Roadmap Sugerido (2–4 semanas)](#roadmap-sugerido-24-semanas)

---

## 🎯 Visão Geral
API para controle financeiro pessoal:
- **Transactions** (despesas/receitas, categoria, recorrência)
- **Accounts** (contas)
- **Budgets** (orçamentos por categoria/mês)
- **Reports** (sumário mensal e gastos por categoria)

**Objetivo:** evoluir habilidades essenciais com entregas incrementais e testes.

---

## 🧰 Stack e Arquitetura
- **.NET 8** · **ASP.NET Core** (Minimal APIs ou Controllers)
- **EF Core** (InMemory/SQLite/SQL Server)
- **FluentValidation**
- **xUnit + Moq** (testes unitários)
- **Arquitetura em camadas**: `Domain`, `Application`, `Infrastructure`, `WebApi`

---

## ✅ Checklist Global
- [ ] README atualizado com fases e decisões
- [ ] Swagger/OpenAPI publicado
- [ ] Scripts de seed e coleção do Postman/Insomnia
- [ ] Cobertura de testes apresentada (Coverlet + ReportGenerator)
- [ ] Logs estruturados e middleware de erros

---

## Fase 1 — Domínio e POO
**Meta:** Modelar entidades e regras com encapsulamento e construtores.

**Tarefas**
- [ ] Criar entidades: `Transaction`, `Account`, `Budget`, `Category`
- [ ] Usar tipos apropriados: `decimal` (dinheiro), `DateOnly`, `enum` para tipo
- [ ] Invariantes de domínio (ex.: `Amount > 0`, descrição obrigatória)
- [ ] Métodos de negócio: `IsExpense`, `IsIncome`, `ApplyCategory`, `MarkAsRecurring`
- [ ] Objetos de valor (opcional): `Money`, `Period`

**Entrega**
- [ ] Projeto `Finance.Domain` com testes simples de construção de entidades

---

## Fase 2 — DI, Repositórios e Serviços
**Meta:** Separar persistência e lógica com interfaces e injeção de dependência.

**Tarefas**
- [ ] `ITransactionRepository` + implementação `EfTransactionRepository`
- [ ] `TransactionService` orquestrando regras e repositório
- [ ] `ICategoryRuleEngine` (Strategy para inferir categoria)
- [ ] Registrar tudo no container de DI

**Entrega**
- [ ] `Finance.Infrastructure` (DbContext + EF) e `Finance.Application` (services)
- [ ] `Program.cs` com DI + Swagger

---

## Fase 3 — Validação e Exceptions
**Meta:** Inputs válidos e erros padronizados.

**Tarefas**
- [ ] DTOs para requests/responses (não vazar entidades)
- [ ] `FluentValidation` para `TransactionDto`, `BudgetDto`
- [ ] Middleware para tratamento de exceções → mapeamento de HTTP status
- [ ] Logs estruturados (Serilog/NLog)

**Entrega**
- [ ] Respostas com `400/404/500` e mensagens consistentes

---

## Fase 4 — REST e Endpoints
**Meta:** API RESTful com filtros e paginação.

**Tarefas**
- [ ] Endpoints: `/accounts`, `/transactions`, `/budgets`, `/reports`
- [ ] Verbos e status corretos: `GET/POST/PUT/DELETE` · `200/201/204/...`
- [ ] Query params de filtros: `from`, `to`, `category`, `page`, `pageSize`
- [ ] Versionamento opcional: `/v1`

**Entrega**
- [ ] Swagger com exemplos de requests/responses

---

## Fase 5 — Testes Unitários
**Meta:** Testar regras e interações com mocks e asserts robustos.

**Tarefas**
- [ ] Testar `TransactionService.AddAsync` (aplica categoria e persiste)
- [ ] Testar `KeywordRuleEngine` (regras de palavras-chave/valores)
- [ ] Testar `BudgetService` (cálculo de status: Atingido/Abaixo/Estourado)
- [ ] Cobertura mínima acordada (ex.: 70%)

**Entrega**
- [ ] Projeto `Finance.Tests` com xUnit + Moq

---

## Fase 6 — Algoritmos (Recorrência, Categorias, Orçamento)
**Meta:** Implementar lógica que agregue valor.

**Tarefas**
- [ ] **Detecção de recorrência**: mesma descrição e valor ~ (tolerância 5%) por mês
- [ ] **Engine de categoria**: Strategy (keywords, regex, thresholds)
- [ ] **Orçamentos**: agregação mensal por categoria + status

**Entrega**
- [ ] Endpoint `GET /reports/summary?month` com saldo e gastos por categoria

---

## Fase 7 — Refatoração e SOLID
**Meta:** Melhorar design e reaproveitar código.

**Tarefas**
- [ ] SRP: validação separada, regras separadas, persistência separada
- [ ] OCP: novas regras sem alterar serviços (Strategy)
- [ ] DIP: depender de interfaces (`ITransactionRepository`, `ICategoryRuleEngine`)
- [ ] Remover duplicações, extrair métodos e mapeadores

**Entrega**
- [ ] Revisão de design + explicação das escolhas no README

---

## Fase 8 — Microserviços básicos
**Meta:** Isolar relatórios em outro serviço e integrar por HTTP.

**Tarefas**
- [ ] Criar `ReportsApi` (sumário mensal)
- [ ] `TransactionsApi` expõe consultas com filtros
- [ ] Integração entre serviços (HTTP) + HealthChecks
- [ ] Docker Compose para subir ambos e banco

**Entrega**
- [ ] Diagrama simples de contexto e contratos

---

## ▶️ Como rodar
```bash
# Clonar e restaurar
git clone <seu-repo>
cd FinanceControl

dotnet restore

# Rodar WebApi (dev)
dotnet run --project src/Finance.WebApi

# Executar testes
dotnet test
```

**Configuração rápida (dev):**
- Banco InMemory por padrão
- `ASPNETCORE_ENVIRONMENT=Development`
- Swagger habilitado

---

## 🧠 Decisões de Arquitetura
- Minimal APIs para simplicidade; Controllers se preferir atributos/filters
- EF Core InMemory em dev; trocar para SQLite/SQL Server em produção
- Strategy para categorização; Repository para persistência
- Middleware centraliza tratamento de erros

---

## 🗓️ Roadmap Sugerido (2–4 semanas)
- **Semana 1:** Fase 1 + 2 → Domínio, DI, CRUD básico
- **Semana 2:** Fase 3 + 4 → Validação, Exceptions, REST refinado
- **Semana 3:** Fase 5 + 6 → Testes e algoritmos
- **Semana 4:** Fase 7 + 8 → Refatorações e microserviços

---

## 📎 Anexos (opcional)
- Postman/Insomnia collection
- Scripts de seed
- Badge de cobertura de testes

