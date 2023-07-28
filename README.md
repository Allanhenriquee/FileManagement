# FileManagement

O FileManagement é um projeto desenvolvido em para ler arquivos nos formatos xlsx ou csv e realizar o processamento dos dados.
Ele foi implementado utilizando o padrão Factory para criar instâncias das classes de leitura com base na extensão do arquivo e o header,
além de utilizar o padrão Visitor para realizar o processamento dos registros.

## Tecnologias e Bibliotecas
- [.NET 7](https://dotnet.microsoft.com/pt-br/download)
- [CsvHelper](https://joshclose.github.io/CsvHelper/)
- [ClosedXML](https://docs.closedxml.io/en/latest/)

## Design Patterns
 - Factory Method
 - Visitor

## Qual é o problema resolvido?
Pense em um cenário onde você precisa implementar leituras de arquivos dinamicamentes com base na extensão do arquivo e nome do arquivo.

O problema que será resolvido basicamente é não precisar ficar criando métodos para leitura do arquivo X, Y ou Z. 

## Funcionalidades

**1**. Leitura de arquivos xlsx ou csv: O sistema pode ler arquivos tanto no formato xlsx (Excel) quanto no formato csv (valores separados por vírgula).

**2**. Criação dinâmica de instâncias: Com base na extensão do arquivo fornecido, o sistema utiliza o padrão Factory para criar a instância adequada da classe de leitura correspondente.

**3**. Criação de Factory para o header: O sistema também utiliza o padrão Factory para criar a instância do Factory que irá processar o header do arquivo.

**4**. Processamento dos dados: Após a leitura do arquivo e a criação dos objetos adequados, o sistema utiliza o padrão Visitor para realizar o processamento dos dados contidos no arquivo, de acordo com o tipo de arquivo e suas características específicas.

## Como implementar a leitura de um arquivo com um header novo?
**1**. Crie uma classe header com as propriedades especificas do produto.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/26f338d5-bbe6-41c4-bc1a-54754f73c13e)

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/c51c0a7a-ed28-45df-916f-173c530a45af)

**BaseFileHeader** - Ele basicamente consiste nas propriedades que todos os arquivos compartilham. Ex: Product, Customer.

**CarHeader** - Consiste nas propriedades especificas para um arquivo do tipo carro.

**BikeHeader** - Consiste nas propriedes especificas para um arquivo do tipo bike.

------------------------------------------
**2**. Adicione uma constante no arquivo HeaderUtils que represente o nome que deve constar no arquivo, adicione uma condição no switch da classe FileHeaderFactory para instanciar o header desejado.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/de1a837e-1412-4cfc-8eef-f02d3aa85e88)
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/4d16ccd2-e725-49d0-a5e4-f9a2588f0339)
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/a5fdee27-0505-4300-90c9-7c33946afc40)

------------------------------------------
**3**. Adicione um novo metodo na interface ISendQuotationVisitor para representar o visitor daquele header específico.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/e71f5d2a-0130-44ec-8f3b-b26c961ed5b9)

------------------------------------------

**4**. Na classe header nova adicionada, implemente a interface IBaseVisitor e o seu metodo Accept.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/0d03b81c-f686-4d17-9b89-b68d567fc289)

------------------------------------------

**5**. Na classe QuotationServiceVisitor você deve implementar o metodo criado no step 3.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/4b5b391a-07ac-476e-adb4-ac2fb8005b58)

**Nessa implementação final é onde você pode realizar o mapeamento do objeto para uma API externa por exemplo, mapear para sua entidade de dominio e salvar no banco de dados, ou outro processamento que deseja realizar.**

------------------------------------------

## Como realizar um teste?
1. Clone o repositório do GitHub:
```
https://github.com/Allanhenriquee/FileManagement.git
```
2. Abra o projeto em sua IDE de prefêrencia e execute.

3. Com o projeto em execução abra o postman, insomnia ou swagger da aplicação faça upload do arquivo e a requisição para o endpoint.
 
------------------------------------------

### Arquivos de exemplo

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/cce30130-1c74-4a35-8125-17cd6a5142e3)

------------------------------------------

### Upload e requisição do postman  
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/09b6e237-0dbb-455e-be6e-317351da3c62)

------------------------------------------

### Resultado
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/2ea8d770-cbbe-4f2c-b1ae-ef1d51f1ee3f)

------------------------------------------

## Arquitetura do Projeto

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/bde95098-8212-404b-ae8f-9eadaa9270d9)

------------------------------------------

