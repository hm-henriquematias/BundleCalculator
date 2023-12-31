# Bundle Calculator (Calculadora de pacotes)

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/Readme.md)

### O que é um pacote?
Antes de começar a descrever a aplicação, é necessário definir o que é um bundle ou pacote.
Um pacote é um item composto por um ou mais itens. Por exemplo, uma bicicleta é composta de
rodas, pedais, entre outros itens.

### Descrição
Esta aplicação tem como objectivo calcular o número de pacotes possíveis a partir de um estoque 
disponível

### Dados
Data.json é um ficheiro que informa as regras para pacotes, itens e suas respetivas quantidades

### Divisão da solução
A solução está dividida em dois projectos, um projecto principal, que é uma aplicação de console,
e um projecto de teste que contém testes unitários e testes de integração.

### Por que apenas um projecto? (além de testes)
É comum ver soluções dotnet com múltiplos projectos para que cada camada da aplicação
está bem isolado, a evitar acoplamento entre camadas e a manter boas práticas.

Mas sejamos honestos, para efeitos desta aplicação, qualquer coisa que não seja a divisão em
pastas que temos aqui é apenas **excesso de engenharia**.

### Sobre o algoritmo principal
1. Recebe o nome de um pacote
2. Valida se o bundle informado existe
     a. Caso contrário, apenas ignore e retorne zero
     b. Se houver, continue e percorra os itens necessários (consulte a etapa 3)
3. Verifica se o item solicitado é um pacote composto por outros itens
     a. Se sim, chame esta mesma validação a retornar ao passo 1
     b. Caso contrário, verifique se o item está em estoque, calcule quantos podem ser usados e prossiga para o passo 4
4. Armazena quantos desses pacotes são possíveis de fazer com cada categoria de item e retorna o menor, para que um pacote incompleto não seja criado

# Sobre

### Autor
Henrique Matias

### Tecnologias usadas
- Linguagem: C#
- Estrutura: .NET Core 7
Tipo de aplicativo: Console
