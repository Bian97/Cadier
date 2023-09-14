INSERT INTO [HistoricoCurso_HCU]
           ([Curso]
           ,[DataFormatura]
           ,[DataLevouCertificado]
           ,[DataUltimoPagamento]
           ,[Periodo]
           ,[Obs]
           ,[RestaPagar]
           ,[IdPfi])
     VALUES
           (@Curso
           ,@DataFormatura
           ,@DataLevouCertificado
           ,@DataUltimoPagamento
           ,@Periodo
           ,@Obs
           ,@RestaPagar
           ,@IdPfi)

SELECT @@IDENTITY