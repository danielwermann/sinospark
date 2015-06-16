/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/*INSERT ALUNOS*/
INSERT INTO [dbo].[Aluno]
           ([CPF]
           ,[Matricula]
           ,[Nome]
           ,[ValorSaldo])
     VALUES

('80527856770','1','Jacinto Sandro Rosa'			,0),
('26143315205','2','Josias Anabela Telinhos'		,0),
('88226710235','3','Amélia Plácido Leite'		,0),
('31551506882','4','Pandora Mariano Cipriano'	,0),
('21242763600','5','Gina Minervina Parracho'		,0),
('06507289477','6','Conceição Camilo Gentil'		,0),
('37312814301','7','Flávio Alípio Vilaça'		,0),
('37312814301','8','Quintiliana Cátia Varela'	,0),
('24814010699','9','Leopoldo Flamínia Loio'		,0),
('23030701123','10','Almor Frederico Canela'		,0),
('17711210418','11','Querubim Josefina Portugal'	,0),
('68982366369','12','Artur Simão Alvim'			,0),
('85674664587','13','Aldonça Delfim Carrasqueira'	,0),
('48588936690','14','Xerxes Belchior Boeira'		,0),
('62333614439','15','Maria Vítor Bulhosa'			,0)

GO

/*INSERT FUNCIONARIOS*/
INSERT INTO [dbo].[Funcionario]
           ([Nome]
           ,[CPF]
           ,[isGerente]
           ,[Email])
     VALUES

('Danilo Juliana Pinhal'	   ,'72603336185',0,'daniel@sinospark.com.br'),
('Érico Vivaldo Galindo'	   ,'48351862576',0,'erico@sinospark.com.br'),
('Gualdim Alípio Sarmento'  ,'38782279497',0,'gualdim@sinospark.com.br'),
('Olívio Paulina Alencastre','13785526873',1,'olivio@sinospark.com.br'),
('Amélia Gabriela Meneses'  ,'88668269526',0,'amelia@sinospark.com.br')
GO

/*INSERT MODELO DE VEICULOS*/
INSERT INTO [dbo].[VeiculoModelo]
           ([Descricao]
           ,[isAtivo]
           ,[isMoto])
     VALUES
('Chevrolet A-10'		,1,0),
('Chevrolet A-20'		,1,0),
('Chevrolet Astra'		,1,0),
('Chevrolet Blazer'		,1,0),
('Chevrolet Bonanza'	,1,0),
('Chevrolet Brasinca'	,1,0),
('Chevrolet C-10'		,1,0),
('Chevrolet C-20'		,1,0),
('Chevrolet Calibra'	,1,0),
('Chevrolet Caprice'	,1,0),
('Chevrolet Captiva'	,1,0),
('Chevrolet Caravan'	,1,0),
('Chevrolet Cavalier'	,1,0),
('Chevrolet Celta'		,1,0),
('Chevrolet Chevette'	,1,0),
('Chevrolet Chevy'		,1,0),
('Chevrolet Cheynne'	,1,0),
('Chevrolet Corsa'		,1,0),
('Chevrolet Corvette'	,1,0),
('Chevrolet D-10'		,1,0),
('Chevrolet D-20'		,1,0),
('Chevrolet Ipanema'	,1,0),
('Chevrolet Kadett'		,1,0),
('Chevrolet Lumina'		,1,0),
('Chevrolet Marajo'		,1,0),
('Chevrolet Meriva'		,1,0),
('Chevrolet Montana'	,1,0),
('Chevrolet Monza'		,1,0),
('Chevrolet Omega'		,1,0),
('Chevrolet Opala'		,1,0),
('Chevrolet Prisma'		,1,0),
('Chevrolet S10'		,1,0),
('Chevrolet Saturn'		,1,0),
('Chevrolet Sierra'		,1,0),
('Chevrolet Silverado'	,1,0),
('Chevrolet Spacevan'	,1,0),
('Chevrolet Ss10'		,1,0),
('Chevrolet Suburban'	,1,0),
('Chevrolet Suprema'	,1,0),
('Chevrolet Syclone'	,1,0),
('Chevrolet Tigra'		,1,0),
('Chevrolet Tracker'	,1,0),
('Chevrolet Trafic'		,1,0),
('Chevrolet Vectra'		,1,0),
('Chevrolet Veraneio'	,1,0),
('Chevrolet Zafira'		,1,0),
('Citroen Ax'			,1,0),
('Citroen Berlingo'		,1,0),
('Citroen Bx'			,1,0),
('Citroen C3'			,1,0),
('Citroen C4'			,1,0),
('Citroen C5'			,1,0),
('Citroen C6'			,1,0),
('Citroen C8'			,1,0),
('Citroen Evasion'		,1,0),
('Citroen Jumper'		,1,0),
('Citroen Xantia'		,1,0),
('Citroen Xm'			,1,0),
('Citroen Xsara'		,1,0),
('Citroen Zx'			,1,0),
('Fiat 147'				,1,0),
('Fiat Brava'			,1,0),
('Fiat Bravo'			,1,0),
('Fiat Cinqquecento'	,1,0),
('Fiat Coupe'			,1,0),
('Fiat Doblo'			,1,0),
('Fiat Ducato'			,1,0),
('Fiat Duna'			,1,0),
('Fiat Elba'			,1,0),
('Fiat Fiorino'			,1,0),
('Fiat Idea'			,1,0),
('Fiat Linea'			,1,0),
('Fiat Marea'			,1,0),
('Fiat Oggi'			,1,0),
('Fiat Palio'			,1,0),
('Fiat Panorama'		,1,0),
('Fiat Premio'			,1,0),
('Fiat Punto'			,1,0),
('Fiat Siena'			,1,0),
('Fiat Stilo'			,1,0),
('Fiat Strada'			,1,0),
('Fiat Tempra'			,1,0),
('Fiat Tipo'			,1,0),
('Fiat Uno'				,1,0),
('Ford Aerostar'		,1,0),
('Ford Aspire'			,1,0),
('Ford Belina'			,1,0),
('Ford Club'			,1,0),
('Ford Contour'			,1,0),
('Ford Corcel'			,1,0),
('Ford Courier'			,1,0),
('Ford Crown'			,1,0),
('Ford Del'				,1,0),
('Ford Ecosport'		,1,0),
('Ford Edge'			,1,0),
('Ford Escort'			,1,0),
('Ford Expedition'		,1,0),
('Ford Explorer'		,1,0),
('Ford F-100'			,1,0),
('Ford F-1000'			,1,0),
('Ford F-150'			,1,0),
('Ford F-250'			,1,0),
('Ford Fiesta'			,1,0),
('Ford Focus'			,1,0),
('Ford Fusion'			,1,0),
('Ford Ka'				,1,0),
('Ford Mondeo'			,1,0),
('Ford Mustang'			,1,0),
('Ford Pampa'			,1,0),
('Ford Probe'			,1,0),
('Ford Ranger'			,1,0),
('Ford Royale'			,1,0),
('Ford Taurus'			,1,0),
('Ford Thunderbird'		,1,0),
('Ford Transit'			,1,0),
('Ford Verona'			,1,0),
('Ford Versailles'		,1,0),
('Ford Windstar'		,1,0),
('Honda Accord'			,1,0),
('Honda City'			,1,0),
('Honda Civic'			,1,0),
('Honda Cr-V'			,1,0),
('Honda Fit'			,1,0),
('Honda Odyssey'		,1,0),
('Honda Passport'		,1,0),
('Honda Prelude'		,1,0),
('Peugeot 106'			,1,0),
('Peugeot 205'			,1,0),
('Peugeot 206'			,1,0),
('Peugeot 207'			,1,0),
('Peugeot 306'			,1,0),
('Peugeot 307'			,1,0),
('Peugeot 405'			,1,0),
('Peugeot 406'			,1,0),
('Peugeot 407'			,1,0),
('Peugeot 504'			,1,0),
('Peugeot 505'			,1,0),
('Peugeot 605'			,1,0),
('Peugeot 607'			,1,0),
('Peugeot 806'			,1,0),
('Peugeot 807'			,1,0),
('Peugeot Boxer'		,1,0),
('Peugeot Partner'		,1,0),
('Renault 19'			,1,0),
('Renault 21'			,1,0),
('Renault Clio'			,1,0),
('Renault Express'		,1,0),
('Renault Kangoo'		,1,0),
('Renault Laguna'		,1,0),
('Renault Logan'		,1,0),
('Renault Master'		,1,0),
('Renault Megane'		,1,0),
('Renault Safrane'		,1,0),
('Renault Sandero'		,1,0),
('Renault Scénic'		,1,0),
('Renault Symbol'		,1,0),
('Renault Trafic'		,1,0),
('Renault Twingo'		,1,0),
('Toyota Avalon'		,1,0),
('Toyota Band.'			,1,0),
('Toyota Band.Jipe'		,1,0),
('Toyota Band.Picape'	,1,0),
('Toyota Camry'			,1,0),
('Toyota Celica'		,1,0),
('Toyota Corola'		,1,0),
('Toyota Corolla'		,1,0),
('Toyota Corona'		,1,0),
('Toyota Hilux'			,1,0),
('Toyota Land'			,1,0),
('Toyota Mr-2'			,1,0),
('Toyota Paseo'			,1,0),
('Toyota Previa'		,1,0),
('Toyota Rav4'			,1,0),
('Toyota Supra'			,1,0),
('Toyota T-100'			,1,0),
('Volkswagen Apolo'		,1,0),
('Volkswagen Bora'		,1,0),
('Volkswagen Caravelle'	,1,0),
('Volkswagen Corrado'	,1,0),
('Volkswagen Crossfox'	,1,0),
('Volkswagen Eos'		,1,0),
('Volkswagen Eurovan'	,1,0),
('Volkswagen Fox'		,1,0),
('Volkswagen Fusca'		,1,0),
('Volkswagen Gol'		,1,0),
('Volkswagen Golf'		,1,0),
('Volkswagen Grand'		,1,0),
('Volkswagen Jetta'		,1,0),
('Volkswagen Kombi'		,1,0),
('Volkswagen Logus'		,1,0),
('Volkswagen New'		,1,0),
('Volkswagen Parati'	,1,0),
('Volkswagen Passat'	,1,0),
('Volkswagen Pointer'	,1,0),
('Volkswagen Polo'		,1,0),
('Volkswagen Quantum'	,1,0),
('Volkswagen Santana'	,1,0),
('Volkswagen Saveiro'	,1,0),
('Volkswagen Spacefox'	,1,0),
('Volkswagen Tiguan'	,1,0),
('Volkswagen Touareg'	,1,0),
('Volkswagen Voyage'	,1,0);

GO

/*INSERT ESTACIONAMENTO*/
INSERT INTO [dbo].[Estacionamento]
           ([Nome]
           ,[isAtivo]
           ,[QuantidadeMaxima])
     VALUES
('Estacionamento A', 1, 200),
('Estacionamento B', 1, 400),
('Estacionamento C', 1, 180),
('Estacionamento D', 1, 250);
GO

/*INSERT PAGAMENTO TIPOS*/
INSERT INTO [dbo].[PagamentoTipo]
           ([Descricao]
           ,[isAtivo])
     VALUES
('CARTAO CREDITO VISA',1),
('CARTAO CREDITO MASTERCARD',1),
('DINHEIRO',1),
('CARTAO UNIVERSIDADE',1);
GO


/*INSERT PRECO*/
INSERT INTO [dbo].[Preco]
           ([Tempo]
           ,[Valor]
           ,[isMoto]
           ,[isAtivo])
     VALUES
('00:01:00',7,0,1),
('00:02:00',14,0,1),
('00:03:00',20,0,1),
('00:04:00',25,0,1),
('00:05:00',30,0,1),
('00:06:00',35,0,1),
('00:01:00',2.5, 1,1),
('00:02:00',7,1,1),
('00:03:00',10,1,1),
('00:04:00',14,1,1),
('00:05:00',18,1,1),
('00:06:00',20,1,1);
GO




