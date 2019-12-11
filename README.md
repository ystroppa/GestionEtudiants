# GestionEtudiants
Projet de gestion d'un établissement de formation. 

Idée est de génèrer une application permettant de gèrer les activités d'enseignement d'un établissement de formation. Un établissement de formation est organisé en filière (DEV, Network ,...). Les étudiants s'inscrivent dan une filière pour une année dans laquelle est organisée tout un processus de formation autour d'un ensemble de matières de type Mathématiques, Français, Informatique .... 
La mise en place et la définition d'une matière au sein d'une flière se fait à travers une description :
    -- du contenu da la matière : Mathématiques -- Algèbres Linéaires 
    -- en nombre d'heures: 10h 
    -- avec un coefficient: 3
    -- statut  obligatoire ou optionnel 
Ces unités d'enseignement sont ensuite affectée à un enseignant qui prendra en charge la dispense de ce cours et les notes associés aux étudiants. 
Les étudiants dans une filière doivent avoir au moins une note dans chaque unité d'enseignement obligatoire. Les enseignants peuvent être affectés à une ou plusieurs unités d'enseignement sur une ou plusieurs filières. 
L'appliocation doit permettre de saisir toute la configuration nécessaire piur définir la structuration interne de cet établissement et permettre  de saisir les notes de chaque étudiant et d'éditer leur bulletin ...de saisir les affectations des enseignants et éditer leur service ....   
    
    jeu de données pour test 

------------------------------------------------------------
Petit jeu de données pour tester votre application si besoin 
Développement C# 
EPSI 2019 
------------------------------------------------------------

Debut du programme
Recapitulatif des filières: (pour chaque service: id Matiere description coef nb_heures)
Filiere DEV
	0:MATH -- Mathématiques analyse  3 ; 10
	1:MATH -- Géométrie  3 ; 10
	2:INFORMATIQUE -- Langage Java  3 ; 16
	3:INFORMATIQUE -- Langage C#  5 ; 20
	4:ANGLAIS -- Apprentissage langue   6 ; 20

Filiere NETWORK
	5:MATH -- Géométrie  2 ; 12
	6:RESEAU -- Routeur & switchs  3 ; 16

// saisie des étudiants 
Etu1 affecté dans la filière DEV
Etu2 affecté dans la filière NETWORK

// Saisie des notes pour l'étudiant etu1
Service enseigné : Mathématiques analyse
	 Note: 12/01/2019 00:00:00  12,3
	 Note: 12/01/2019 00:00:00  12,3
Service enseigné : Géométrie
	 Note: 12/01/2019 00:00:00  15,3
Service enseigné : Langage Java
	 Note: 12/01/2019 00:00:00  9,3
Service enseigné : Langage C#
	 Note: 12/02/2019 00:00:00  19,3
// Avec en moyenne 
14,358823776245117

// Saisie des notes pour l'étudiant etu2
Service enseigné : Géométrie
	 Note: 12/01/2019 00:00:00  12,3
Service enseigné : Routeur & switchs
	 Note: 12/01/2019 00:00:00  9,3
	 Note: 12/02/2019 00:00:00  9,3
// Avec en moyenne 
10,050000190734863

// Saisie des enseignants et affectation aux services à enseigner
// récap des services à effectuer 
Pour l'enseignant : stroppa  yvan
	DEV  MATH    Mathématiques analyse  10
	NETWORK  MATH    Géométrie  12
	NETWORK  RESEAU    Routeur & switchs  16

Pour l'enseignant : wicker  nicolas
	DEV  INFORMATIQUE    Langage C#  20
	DEV  INFORMATIQUE    Langage Java  16
	DEV  MATH    Géométrie  10
    
