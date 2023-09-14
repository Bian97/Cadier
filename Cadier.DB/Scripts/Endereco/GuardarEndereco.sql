INSERT INTO [dbo].[Endereco_END]
           ([Rua]
           ,[Bairro]
           ,[Cidade]
           ,[Estado]
           ,[Pais]
           ,[Cep]
           ,[Latitude]
           ,[Longitude])
     VALUES
           (@Rua
           ,@Bairro
           ,@Cidade
           ,@Estado
           ,@Pais
           ,@Cep
           ,@Latitude
           ,@Longitude)

SELECT @@IDENTITY