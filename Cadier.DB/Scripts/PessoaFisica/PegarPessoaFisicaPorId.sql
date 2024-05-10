 SELECT pf.[IdPfi] as IdPFisica
      ,pf.[Nome]
      ,pf.[Profissao]
      ,pf.[Sexo]
      ,pf.[Telefone1]
      ,pf.[Telefone2]
      ,pf.[Indicacao]
      ,pf.[Cargo]
      ,pf.[Conjuge]
      ,pf.[DataNascimento]
      ,pf.[Email]
      ,pf.[Foto]
      ,pf.[DocumentoIdentificacaoSocial]
      ,pf.[Rg]
      ,pf.[IdTme] as IdTipoMembro
      ,pf.[IdEnd] as IdEndereco
      ,en.[Rua] as Rua
      ,en.[Bairro] as Bairro
      ,en.[Cidade] as Cidade
      ,en.[Estado] as Estado
      ,en.[Pais] as Pais
      ,en.[Cep] as Cep
      ,pf.[IdSit] as IdSituacaoCadastral
      ,sc.[EFiliado]
      ,pf.[IdPju] as IdPJuridica
      ,pj.[Nome] as Nome      
      ,pf.[IdAte] as IdAtendente
    FROM PessoaFisica_PFI pf (nolock)
    LEFT JOIN PessoaJuridica_PJU pj (nolock) ON pj.[IdPju] = pf.[IdPju]
    LEFT JOIN Endereco_END en (nolock) on en.[IdEnd] = pf.[IdEnd]
    LEFT JOIN SituacaoCadastral_SIT sc (nolock) on sc.[IdSit] = pf.[IdSit]
    WHERE 
        pf.IdPfi = @Id