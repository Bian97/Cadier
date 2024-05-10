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
        (@IdPFisica IS NULL OR pf.[IdPfi] = @IdPFisica)
        AND (@DocumentoIdentificacaoSocial IS NULL OR pf.[DocumentoIdentificacaoSocial] LIKE '%' + @DocumentoIdentificacaoSocial + '%')
        AND (@IdPJuridica = 0 OR pf.[IdPju] = @IdPJuridica)
        AND (@NomePessoaJuridica IS NULL OR pj.[Nome] LIKE '%' + @NomePessoaJuridica + '%')
        AND (@Cidade IS NULL OR en.Cidade LIKE '%' + @Cidade + '%')
        AND (@Estado IS NULL OR en.Estado LIKE '%' + @Estado + '%')
        AND (@Pais IS NULL OR en.Pais LIKE '%' + @Pais + '%')
        AND (@Condicao IS NULL OR sc.Condicao = @Condicao)
        AND (@Filiado IS NULL OR sc.EFiliado = @Filiado)
    ORDER BY pf.Nome
    --LEFT JOIN InfosPessoas_INF inf (nolock) on pf.IdPFisica = inf.IdPFisica 
    
    --LEFT JOIN PessoaJuridica_PJU pj (nolock) ON pf.IdPJuridica = pj.IdPJuridica 
    --WHERE (@Condicao IS NULL OR  sc.Condicao = @Condicao)
    --GROUP BY pf.IdPFisica;