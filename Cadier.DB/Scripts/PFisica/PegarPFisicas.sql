 SELECT pf.IdPFisica, pf.Nome, pf.Email, pj.Nome as NomeIgreja, en.Bairro, en.Estado, en.Cidade,
        inf.Cpf, sc.Condicao, sc.EFiliado, sc.IdAtendente
    FROM PessoaFisica_PFI pf (nolock)
    LEFT JOIN Endereco_END en (nolock) on en.IdPFisica = pf.IdPFisica 
    LEFT JOIN InfosPessoas_INF inf (nolock) on pf.IdPFisica = inf.IdPFisica 
    LEFT JOIN SituacaoCadastral_SIT sc (nolock) on sc.IdPFisica = pf.IdPFisica 
    LEFT JOIN PessoaJuridica_PJU pj (nolock) ON pf.IdPJuridica = pj.IdPJuridica 
    WHERE (@Condicao IS NULL OR  sc.Condicao = @Condicao)
    GROUP BY pf.IdPFisica;