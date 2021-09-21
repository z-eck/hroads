--DQL
USE SENAI_HROADS_TARDE;
GO

-- Selecionar todos os personagens:
SELECT * FROM PERSONAGEM;
GO

-- Selecionar todas as classes:
SELECT * FROM CLASSE;
GO

-- Selecionar somente o nome das classes:
SELECT nomeClasse FROM CLASSE;
GO

-- Selecionar todas as habilidadees:
SELECT * FROM HABILIDADE;
GO

-- Realizar a contagem de quantas habilidades estão cadastradas:
SELECT COUNT(idHabilidade) FROM HABILIDADE;
GO

-- Selecionar somente os id’s das habilidades classificando-os por ordem crescente:
SELECT idHabilidade FROM HABILIDADE
ORDER BY idHabilidade ASC
GO

-- Selecionar todos os tipos de habilidades:
SELECT * FROM TIPOHABILIDADE;
GO

-- Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte:
SELECT nomeHabilidade Habilidade, nomeTipoHabilidade [Tipo de Habilidade] FROM HABILIDADE H
INNER JOIN TIPOHABILIDADE TH
ON H.idTipoHabilidade = TH.idTipoHabilidade;
GO

-- Selecionar todos os personagens e suas respectivas classes:
SELECT * FROM PERSONAGEM P 
INNER JOIN CLASSE C
ON P.idClasse = C.idClasse;
GO

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens:
SELECT * FROM PERSONAGEM P
RIGHT JOIN CLASSE C
ON P.idClasse = C.idClasse;
GO

-- Selecionar todas as classes e suas respectivas habilidades:
SELECT nomeClasse Classe, nomeHabilidade Habilidade FROM CLASSE C
LEFT JOIN CLASSEHABILIDADE CH
ON C.idClasse = CH.idClasse
LEFT JOIN HABILIDADE H
ON CH.idHabilidade = H.idHabilidade
GO

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência):
SELECT nomeHabilidade Habilidade, nomeClasse Classe FROM HABILIDADE H
INNER JOIN CLASSEHABILIDADE CH
ON H.idHabilidade = CH.idHabilidade
INNER JOIN CLASSE C
ON CH.idClasse = C.idClasse
GO

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência:
SELECT nomeHabilidade Habilidade, nomeClasse Classe FROM HABILIDADE H
FULL OUTER JOIN CLASSEHABILIDADE CH
ON H.idHabilidade = CH.idHabilidade
FULL OUTER JOIN CLASSE C
ON CH.idClasse = C.idClasse
GO