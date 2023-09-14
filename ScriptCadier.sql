CREATE DATABASE Cadier;

USE Cadier

CREATE TABLE Endereco_END (IdEnd int PRIMARY KEY identity(1,1) NOT NULL, Rua varchar(255) NULL, Bairro varchar(255) NULL, Cidade varchar(50) NULL, Estado varchar(20) NULL, Pais varchar(20) NULL, Cep int NULL, Latitude decimal(36,18) NULL, Longitude decimal(36,18) NULL)

CREATE TABLE Atendente_ATE (IdAte int PRIMARY KEY identity(1,1) NOT NULL, Nome varchar(255) NOT NULL, Telefone int NULL, IdEnd int NULL FOREIGN KEY (IdEnd) REFERENCES Endereco_END(IdEnd))

CREATE TABLE SituacaoCadastral_SIT (IdSit int PRIMARY KEY identity(1,1) NOT NULL, Condicao int NOT NULL, DataAtualizado date NOT NULL, DataEntrou date NOT NULL, DataUltimaVisita date NOT NULL, EFiliado bit NOT NULL, Obs text NULL)

CREATE TABLE PessoaJuridica_PJU (IdPju int PRIMARY KEY NOT NULL, Nome VARCHAR(255) NOT NULL, DataFundacao date NULL, Email varchar(255) NULL, 
	IdEnd int NULL FOREIGN KEY (IdEnd) REFERENCES Endereco_END(IdEnd), 
	IdSit int NULL FOREIGN KEY (IdSit) REFERENCES SituacaoCadastral_SIT(IdSit),
	Cnpj varchar(30) null
--	IdPfiPresidente int NULL FOREIGN KEY (IdPfiPresidente) REFERENCES PessoaFisica_PFI(IdPfi), IdPfiVice int NULL FOREIGN KEY (IdPfiVice) REFERENCES PessoaFisica_PFI(IdPfi)
	)

CREATE TABLE TipoMembro_TME (IdTme int PRIMARY KEY IDENTITY(1,1) NOT NULL, Tipo varchar(50) NOT NULL)

CREATE TABLE PessoaFisica_PFI(IdPfi int PRIMARY KEY NOT NULL, Nome VARCHAR(255) NOT NULL, Profissao VARCHAR(255) NULL, Sexo bit NULL, Telefone1 int NULL, Telefone2 int NULL, Indicacao VARCHAR(255) NULL, Cargo int NULL, Conjuge VARCHAR(255) NULL, DataNascimento date NULL, Email VARCHAR(255) NULL, Foto text NULL,  	
	IdEnd int NULL FOREIGN KEY (IdEnd) REFERENCES Endereco_END(IdEnd), 
	IdSit int NULL FOREIGN KEY (IdSit) REFERENCES SituacaoCadastral_SIT(IdSit), 
	IdPju int NULL FOREIGN KEY (IdPju) REFERENCES PessoaJuridica_PJU(IdPju),
	IdTme int NULL FOREIGN KEY (IdTme) REFERENCES TipoMembro_TME(IdTme),
	Cpf varchar(15) NULL, Rg varchar(15) NULL)

--CREATE TABLE PessoaFisicaJuridica_PFJ (IdPfj int PRIMARY KEY IDENTITY(1,1) NOT NULL, IdMembro int NULL FOREIGN KEY (IdMembro) REFERENCES PessoaFisica_PFI(IdPfi),
--	IdPresidente int NULL FOREIGN KEY (IdPresidente) REFERENCES PessoaFisica_PFI(IdPfi),
--	IdVicePresidente int NULL FOREIGN KEY (IdVicePresidente) REFERENCES PessoaFisica_PFI(IdPfi))

CREATE TABLE OrdemServico_ORD (IdOrd int PRIMARY KEY identity(1,1) NOT NULL, Servico VARCHAR(255) NOT NULL, TipoServico VARCHAR(255), Valor decimal(36,2) NULL, Pago decimal(36,2) NULL, Deposito decimal(36,2) NULL, CreditoAnterior decimal(36,2) NULL, Mensalidade Date NULL, DataPedido Date NULL, DataFeito Date NULL, DataEntregue Date NULL, Obs text NULL,
	IdPju int NULL FOREIGN KEY (IdPju) REFERENCES PessoaJuridica_PJU(IdPju), IdPfi int NULL FOREIGN KEY (IdPfi) REFERENCES PessoaFisica_PFI(IdPfi))

CREATE TABLE HistoricoCurso_HCU (IdHcu int PRIMARY KEY identity(1,1) NOT NULL, Curso VARCHAR(255) NOT NULL, DataFormatura date NULL, DataLevouCertificado date NULL, DataUltimoPagamento Date NULL, Periodo VARCHAR(255) NULL, Obs text NULL, RestaPagar decimal(20,2), IdPfi int NULL FOREIGN KEY (IdPfi) REFERENCES PessoaFisica_PFI(IdPfi))

CREATE TABLE HistoricoConsagracao_HCO (IdHco int PRIMARY KEY identity(1,1) NOT NULL, Cargo int NOT NULL, DataLiturgia date NOT NULL, Igreja VARCHAR(255) NOT NULL, Lugar VARCHAR(255) NOT NULL, NomeIndicou VARCHAR(255) NULL, Obs text NULL, IdPfi int NULL FOREIGN KEY (IdPfi) REFERENCES PessoaFisica_PFI(IdPfi))