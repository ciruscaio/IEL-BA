--TABELA HORARIO_TRABALHO
--	Dia da Semana	
--	Hora Início	
--	Hora Fim	
--	Tempo de Descanso (h)	
--	Carga Horária (h)


--CRIA
CREATE TABLE horario_trabalho
(
	  codigo					int IDENTITY(1,1)	NOT NULL
	, funcionario_codigo		int					NOT NULL
	, dia_semana				tinyint				NOT NULL
	, hora_ini					time(7)				NOT NULL
	, hora_fim					time(7)				NOT NULL
	, tempo_descanso			time(7)				NOT NULL
	, ch						tinyint				NOT NULL

	CONSTRAINT PK_horario_trabalho PRIMARY KEY CLUSTERED 
	(
		codigo ASC
	) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON PRIMARY
) ON PRIMARY

ALTER TABLE dbo.horario_trabalho  WITH CHECK ADD  CONSTRAINT FK_horario_trabalho_funcionario FOREIGN KEY(funcionario_codigo)
REFERENCES dbo.funcionario (codigo)

ALTER TABLE dbo.horario_trabalho CHECK CONSTRAINT FK_horario_trabalho_funcionario


--DA CARGA
INSERT INTO horario_trabalho 
		 (				  			
				  funcionario_codigo
				, dia_semana		
				, hora_ini			
				, hora_fim			
				, tempo_descanso	
				, ch			
		 )
VALUES	
		     (1, 2, '08:00:00', '18:00:00', '02:00:00', 8)
		   , (1, 3, '08:00:00', '18:00:00', '02:00:00', 8)
		   , (1, 4, '08:00:00', '18:00:00', '02:00:00', 8)
		   , (1, 5, '08:00:00', '18:00:00', '02:00:00', 8)
		   , (1, 6, '08:00:00', '18:00:00', '02:00:00', 8)

-- VENDO A CARGA
SELECT * FROM horario_trabalho