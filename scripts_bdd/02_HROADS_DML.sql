USE SENAI_HROADS_TARDE;
GO

INSERT INTO CLASSE (nomeClasse)
VALUES ('Barbaro'), ('Monge'), ('Arcanista'), ('Necromancer'), ('Feiticeiro'), ('Cruzado'), ('Caçadora de Demônios');
GO

INSERT INTO TIPOHABILIDADE (nomeTipoHabilidade)
VALUES ('Ataque'), ('Defesa'), ('Cura'), ('Magia');
GO

INSERT INTO HABILIDADE (idTipoHabilidade, nomeHabilidade)
VALUES (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida');
GO

INSERT INTO PERSONAGEM (idClasse, nomePersonagem, ptsVida, ptsMana, dataCriacao, dataAtualizacao)
VALUES (1, 'DeuBug', 100, 80, '05/02/2021','10/08/2021'), (2, 'BitBug', 70, 100, '01/01/2020','10/08/2021'), (3, 'Fer7', 75, 60, '03/05/2020','10/08/2021'), (4, 'BDD', 85, 85, '29/07/2021','16/09/2021')
GO

INSERT INTO CLASSEHABILIDADE (idHabilidade, idClasse)
VALUES (1,1), (2,1), (2,2), (3,2), (NULL,3), (NULL,4), (3,5), (2,6), (1,7);
GO

INSERT INTO TIPOUSUARIO(titulo)
VALUES ('ADMINISTRADOR'), ('JOGADOR');
GO

INSERT INTO USUARIO(idTipoUsuario, email, senha)
VALUES (1, 'admin@admin.com', 'admin132'), (2, 'glima@jogador.com', 'glima132'), (2, 'zeck@jogador.com', 'erick132');
GO


SELECT * FROM USUARIO