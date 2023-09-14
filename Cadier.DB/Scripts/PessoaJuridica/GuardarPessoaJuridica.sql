--DECLARE @UltimoId INT = (SELECT MAX(IdPju) FROM [PessoaJuridica_PJU]) + 1

INSERT INTO [dbo].[PessoaJuridica_PJU]
           ([IdPju]
           ,[Nome]
           ,[DataFundacao]
           ,[Email]
           ,[Cnpj]
           ,[IdEnd]
           ,[IdSit])
     VALUES
           (@IdPJuridica
           ,@Nome
           ,@DataFundacao
           ,@Email
           ,@Cnpj
           ,@IdEndereco
           ,@IdSituacaoCadastral)

SELECT @IdPJuridica