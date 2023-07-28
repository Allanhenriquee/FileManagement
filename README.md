# FileManagement

O FileManagement é um projeto desenvolvido para ler arquivos nos formatos xlsx ou csv e realizar o processamento dos mesmos. 
Ele foi implementado utilizando o padrão Factory para criar instâncias das classes de leitura com base na extensão do arquivo e o header,
além de utilizar o padrão Visitor para realizar o processamento dos registros.

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

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/a4b1baa5-69c9-4554-96b7-0db78c11d609)

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/4f59d4cb-6fc5-4eb3-9dd2-10fa17f8fde9)

**BaseFileHeader** - Ele basicamente consiste nas propriedades que todos os arquivos compartilham. Ex: Product, Customer.

**CarHeader** - Consiste nas propriedades especificas para um arquivo do tipo carro.

**BikeHeader** - Consiste nas propriedes especificas para um arquivo do tipo bike.

------------------------------------------
**2**. Adicione uma constante no arquivo HeaderUtils que represente o nome que deve constar no arquivo, adicione uma condição no switch da classe FileHeaderFactory para instanciar o header desejado.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/d9b28ce8-212c-4907-a863-52709c6fb8e6)
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/5ff8f0f8-24dd-4809-886b-bf7624bcf52a)
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/f105278d-fc25-424a-9341-c6a4ec1f28ff)

------------------------------------------
**3**. Adicione um novo metodo na interface ISendQuotationVisitor para representar o visitor daquele produto especifico.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/22b7f772-b628-4f4c-8273-488708669a40)

------------------------------------------

**4**. Na classe header nova adicionada, implemente a interface IBaseVisitor e o seu metodo Accept.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/664d2255-d1b9-4fbe-bfdd-a62efa8b90a8)

------------------------------------------

**5**. Na classe QuotationServiceVisitor você deve implementar o metodo criado no step 3.

**Exemplo**:

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/a114ab5e-8a65-4c57-b557-45e7c2c9ec70)

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

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/ba1ab2f1-ed94-4ecd-8128-901e98c0dc11)

------------------------------------------

### Upload e requisição do postman  
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/27b956fd-0fde-4dbb-9bb1-1f64fc87ebcb)

------------------------------------------

### Resultado
![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/3334ad9e-4150-4d5d-864d-26f405979686)



## Arquitetura do Projeto

![image](https://github.com/Allanhenriquee/FileManagement/assets/52016301/ad48f1b4-91e6-4432-ae05-7fc79a7e04fc)

