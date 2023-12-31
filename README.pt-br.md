# Bundle Calculator (Calculadora de pacotes)

### O que é um pacote?
Antes de começar a descrever a aplicação, é necessário definir o que é um bundle ou pacote.
Um pacote é um item composto por um ou mais itens. Por exemplo, uma bicicleta é composta de
rodas, pedais, entre outros itens.

### Descrição
Esta aplicação tem como objetivo calcular o número de pacotes possíveis a partir de um estoque 
disponível

### Dados
Data.json é um arquivo que informa as regras para pacotes, itens e suas respectivas quantidades

### Divisão da solução
A solução está dividida em dois projetos, um projeto principal, que é uma aplicação de console,
e um projeto de teste que contém testes unitários e testes de integração.

### Por que apenas um projeto? (além de testes)
É comum ver soluções dotnet com múltiplos projetos para que cada camada da aplicação
está bem isolado, evitando acoplamento entre camadas e mantendo boas práticas.

Mas sejamos honestos, para efeitos desta aplicação, qualquer coisa que não seja a divisão em
pastas que temos aqui é apenas **excesso de engenharia**.

### Sobre o algoritmo principal
1. Recebe o nome de um pacote
2. Valida se o bundle informado existe
     a. Caso contrário, apenas ignore e retorne zero
     b. Se houver, continue e percorra os itens necessários (consulte a etapa 3)
3. Verifica se o item solicitado é um pacote composto por outros itens
     a. Se sim, chame esta mesma validação voltando ao passo 1
     b. Caso contrário, verifique se o item está em estoque, calcule quantos podem ser usados e prossiga para o passo 4
4. Armazena quantos desses pacotes são possíveis de fazer com cada categoria de item e retorna o menor, para que um pacote incompleto não seja criado

# Sobre

### Autor
Henrique Matias

### Tecnologias usadas
- Linguagem: C#
- Estrutura: .NET Core 7
Tipo de aplicativo: Console
