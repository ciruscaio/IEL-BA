--TABELA FUNCIONARIOO
--	Nome
--	CPF
--	E-mail
--	Telefone
--	Habilitação
--	Categoria
--	Língua Estrangeira
--	Estado
--	Cidade
--	CEP
--	Logradouro
--	Número
--	Complemento
--	Cargo
--	Salário Proposto

--Para lebrar dos tipos:
--select * from sys.types

--CRIA
CREATE TABLE funcionario
(
			codigo			int					NOT NULL	IDENTITY(1,1)	
		,	nome			nvarchar(50)		NOT NULL
		,	cpf				nchar(11)			NULL
		,	email			nvarchar(50)		NULL
		,	telefone		nvarchar(11)		NULL
		,	habilitacao		bit					NULL
		,	categoria		nvarchar(5)			NULL
		,	ligua			nvarchar(20)		NULL
		,	estado			nchar(2)			NULL
		,	cidade			nvarchar(30)		NULL
		,	cep				nchar(8)			NULL
		,	logradouro		nvarchar(50)		NULL
		,	numero			nvarchar(10)		NULL
		,	complemento		nvarchar(20)		NULL
		,	cargo			nvarchar(20)		NULL
		,	salario			decimal(7,2)		NULL


	CONSTRAINT [PK_funcionario] PRIMARY KEY CLUSTERED 
	(
		[Codigo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)

----DA CARGA
INSERT INTO funcionario 
		 (						
				nome		
			,	cpf			
			,	email		
			,	telefone	
			,	habilitacao	
			,	categoria	
			,	ligua		
			,	estado		
			,	cidade		
			,	cep			
			,	logradouro	
			,	numero		
			,	complemento	
			,	cargo		
			,	salario		
		 )
VALUES	
		   ('Caio Barbosa', '70734095090', 'ciruscaio@gmail.com', '81986370000', 1, 'AB','PT','PE','Recife','52040180','Rua A','1','NH','Diretor',15000.00)
		 , ('Fulano de Tal', '03986173099', 'fulano@email.com', '81098709870', 1, 'A','PT','PE','Recife','52040180','Rua B','1','NH','Gerente',10000.00)
		 , ('Sicrano de Tal', '65607758010', 'sicrano@email.com', '81123412335', 0, '','PT','PE','Recife','52040180','Rua C','1','NH','Coordadnador',8000.00)
		 , ('Beltrano de Tal', '45267849073', 'beltrano@email.com', '81456745677', 0, '','PT','PE','Recife','52040180','Rua D','1','NH','Desenvolvedor',5000.00)

-- VENDO A CARGA
SELECT * FROM funcionario


