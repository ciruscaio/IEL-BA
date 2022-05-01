EXEC SP_PUT_responsavel_depto 
	  @codigo = null
	, @nome = 'Caio Barbosa'
	, @login = 'caio.barbosa'
	, @email = 'ciruscaio@gmail.com';

select * from responsavel_depto