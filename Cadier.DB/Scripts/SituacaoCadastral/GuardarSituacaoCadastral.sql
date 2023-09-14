INSERT INTO [SituacaoCadastral_SIT]
           ([Condicao]
           ,[DataAtualizado]
           ,[DataEntrou]
           ,[DataUltimaVisita]
           ,[EFiliado]
           ,[Obs])
     VALUES
           (@Condicao
           ,@DataAtualizado
           ,@DataEntrou
           ,@DataUltimaVisita
           ,@EFiliado
           ,@Obs)



SELECT @@IDENTITY