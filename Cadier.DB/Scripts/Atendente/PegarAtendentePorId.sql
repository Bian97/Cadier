 SELECT ate.IdAte, ate.Nome, ate.Telefone, ate.DocumentoIdentificacaoSocial, ate.Rg, ate.IdEnd
    FROM Atendente_ATE ate (nolock)
    WHERE ate.IdAte = @Id