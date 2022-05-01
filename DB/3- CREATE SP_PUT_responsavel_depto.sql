--2.	Ap�s constru��o da tabela, desenvolva uma Stored Procedure que fa�a as seguintes instru��es:
-- 	- Cadastre (insert) o departamento (c�digo) e os dados do seu respons�vel (nome, login, e-mail) na tabela criada anteriormente;
-- 	- Caso, j� exista um cadastro para esse departamento, atualizar (update) os dados do respons�vel (nome, login, email);
-- 	- Esta procedure dever� receber os par�metros: c�digo do departamento, nome do respons�vel, login do respons�vel e e-mail;

CREATE PROCEDURE SP_PUT_responsavel_depto

		  @codigo					AS int
		, @nome						AS nvarchar(50)			
		, @login					AS nvarchar(20)			= NULL
		, @email					nvarchar(50)			= NULL

AS
BEGIN
	SET NOCOUNT ON;

	--Verificando a exist�ncia do registro
	IF NOT EXISTS (select codigo from responsavel_depto where codigo = @codigo)
		
		--N�o e existe, logo inclui
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

