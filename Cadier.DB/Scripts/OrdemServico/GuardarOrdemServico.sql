INSERT INTO [OrdemServico_ORD]
           ([Servico]
           ,[TipoServico]
           ,[Valor]
           ,[Pago]
           ,[Deposito]
           ,[CreditoAnterior]
           ,[Mensalidade]
           ,[DataPedido]
           ,[DataFeito]
           ,[DataEntregue]
           ,[Obs]
           ,[IdPju]
           ,[IdPfi])
     VALUES
           (@Servico
           ,@TipoServico
           ,@Valor
           ,@Pago
           ,@Deposito
           ,@CreditoAnterior
           ,@Mensalidade
           ,@DataPedido
           ,@DataFeito
           ,@DataEntregue
           ,@Obs
           ,@IdPju
           ,@IdPfi)

SELECT @@IDENTITY