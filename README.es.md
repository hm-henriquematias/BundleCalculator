# Calculadora de paquetes (Calculadora de pacotes)


[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/Readme.md)

### ¿O qué es un pacote?
Antes de comenzar a descubrir una aplicación, es necesario definir cuál es un paquete o paquete.
Un pacote es un artículo composto por um ou mais itens. Por ejemplo, una bicicleta es composta de
rodas, pedais, entre outros itens.

### Descripción
Esta aplicación tiene como objetivo calcular el número de paquetes posibles a partir de un estoque.
disponível

### Dados
Data.json es un archivo que informa sobre registros de paquetes, artículos y cantidades respectivas

### División de la solución
La solución está dividida en dos proyectos, un proyecto principal, que es una aplicación de consola,
e um proyecto de prueba que contiene pruebas unitarias y pruebas de integración.

### ¿Por qué apenas un proyecto? (além de testículos)
Es común ver soluciones dotnet con múltiples proyectos para cada camada de aplicación.
está bem isolado, impidiendo el acoplamiento entre camadas y manteniendo boas prácticas.

Mas sejamos honestos, para efectos de esta aplicación, cualquer coisa que não seja a divisão em
pastas que temos aquí é apenas **exceso de ingeniería**.

### Sobre el algoritmo principal
1. Recibe el nombre de un paquete
2. Valida se o paquete informado existe
      a. Caso contrario, apenas ignora y regresa a cero
      b. Se hover, continue e percorra os itens necessários (consulte a etapa 3)
3. Verifique si el artículo solicitado es un paquete composto para otros artículos
      a. Se sim, chame esta mesma validação voltando ao passo 1
      b. Caso contrario, verifique si el artículo está en estoque, calcule cuántos podrían ser usados y prossiga para o passo 4
4. Armazena quantos desses pacotes são possíveis de fazer com cada categoría de artículo e retorna o menor, para que un pacote incompleto não seja criado

#Sobre

### Autor
Henrique Matías

### Tecnologías usadas
- Idioma: C#
- Estructura: .NET Core 7
Tipo de aplicación: Consola
