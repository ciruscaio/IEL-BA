--1.	Construa (create) uma tabela que contenha os seguintes campos: 
--	c�digo do departamento, 
--	nome do respons�vel pelo departamento, 
--  login do respons�vel, 
--	e-mail do respons�vel;


CREATE TABLE responsavel_depto 
(
			codigo	int				NOT NULL	IDENTITY(1,1)	
		,	nome	nvarchar(50)	NOT NULL
		,	login	nvarchar(20)	NULL
		,	email	nvarchar(50)	NULL

	CONSTRAINT [PK_responsavel_depto] PRIMARY KEY CLUSTERED 
	(
		[Codigo] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
)