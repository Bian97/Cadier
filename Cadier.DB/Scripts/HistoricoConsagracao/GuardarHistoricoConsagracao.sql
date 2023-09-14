INSERT INTO [dbo].[HistoricoConsagracao_HCO]
           ([Cargo]
           ,[DataLiturgia]
           ,[Igreja]
           ,[Lugar]
           ,[NomeIndicou]
           ,[Obs]
           ,[IdPfi])
     VALUES
           (@Cargo
           ,@DataLiturgia
           ,@Igreja
           ,@Lugar
           ,@NomeIndicou
           ,@Obs
           ,@IdPfi)

SELECT @@IDENTITY