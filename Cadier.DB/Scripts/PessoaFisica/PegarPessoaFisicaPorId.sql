 SELECT pf.IdPfi, pf.Nome, pf.Email, pf.DocumentoIdentificacaoSocial
        --pj.Nome as NomeIgreja, 
        --en.Bairro, en.Estado, en.Cidade,
        --inf.Cpf, sc.Condicao, sc.EFiliado, sc.IdAtendente
    FROM PessoaFisica_PFI pf (nolock) WHERE pf.IdPfi = @Id