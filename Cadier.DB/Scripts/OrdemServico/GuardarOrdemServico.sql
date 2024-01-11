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
           ,[IdPfi]
           ,[IdAte])
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
           ,@IdPessoaJuridica
           ,@IdPessoaFisica
           ,@IdAtendente)

SELECT @@IDENTITY