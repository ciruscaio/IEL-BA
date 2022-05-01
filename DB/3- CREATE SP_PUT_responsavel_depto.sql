--2.	Após construção da tabela, desenvolva uma Stored Procedure que faça as seguintes instruções:
-- 	- Cadastre (insert) o departamento (código) e os dados do seu responsável (nome, login, e-mail) na tabela criada anteriormente;
-- 	- Caso, já exista um cadastro para esse departamento, atualizar (update) os dados do responsável (nome, login, email);
-- 	- Esta procedure deverá receber os parâmetros: código do departamento, nome do responsável, login do responsável e e-mail;

CREATE PROCEDURE SP_PUT_responsavel_depto

		  @codigo					AS int
		, @nome						AS nvarchar(50)			
		, @login					AS nvarchar(20)			= NULL
		, @email					nvarchar(50)			= NULL

AS
BEGIN
	SET NOCOUNT ON;

	--Verificando a existência do registro
	IF NOT EXISTS (select codigo from responsavel_depto where codigo = @codigo)
		
		--Não e existe, logo inclui
		INSERT INTO  responsavel_depto
				 (					
					  nome								
					, login					
					, email
				 )
				VALUES
				(
					  @nome
					, @login
					, @email
				)

	ELSE
		--Existe, logo altera
		UPDATE responsavel_depto
			SET
				  nome		= @nome
				, login		= ISNULL(@login, login)
				, email		= ISNULL(@email, email)

			WHERE
				codigo = @codigo

	IF @@error <> 0
	RETURN

END

