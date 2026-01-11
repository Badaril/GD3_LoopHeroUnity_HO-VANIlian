# GD3_LoopHeroUnreal_HO-VANIlian
# Devoir 12/01 : Loop Hero V1

# Consigne
Ce devoir doit vous mener à la première version de votre Loop Hero.
  
Comme d'habitude vous aurez des éléments minimum à réaliser et des bonus. Si vous réalisez des bonus non prévus, j'en prendrais compte et ils seront notés. Toute fois les bonus ne seront réellement pris en compte QUE si la base est là.
  
Demande de base :

- Un jeu de type loop hero avec un fonctionnement de déplacement par case. L'idée générale est de créer des "actions" sur les cases pour créer une logique de jeu. Il peut y avoir des cases neutres, qui n'ont pas d'actions associées.
- Le déplacement est à votre convenance : hasard avec un dé ou un autre système de hasard, ou contrôlé par le joueur.
- Une UI adaptée et compréhensible, suffisante pour pouvoir jouer à votre jeu.
- AU MINIMUM trois cases actions différentes, l'un d'entre elle déclenchera OBLIGATOIREMENT un dialogue. Les autres actions sont à votre convenance, il faut que chaque action, ou du moins son résultat soit compréhensible.
- Un système de dialogue linéaire cohérent. Avec une gestion du redémarrage du dialogue cohérente.
- Un système de victoire et de défaite ou de passage au niveau suivant le cas échéant. Les conditions sont à votre convenance.

# Notes d'intention
Le joueur incarne un héros qui doit s'améliorer en parcourant un plateau à l'aide de dés dans lequel il boucle. Ici, le joeur doit combattre et vaincre tous les ennemis de la première zone : une ferme.

Sur le HUD, le joueur peut voir ses PV et il possède 2 dés : 1 dé (6) et 1 dé (3). Le joueur peut décider de choisir son dé afin d'avancer du nombre de cases que le jet du dé. Il ne peut relancer les dés qu'une fois utilisé.
  
Il y a 4 cases différentes dans cette première zone : 
- 1 case noire "Dialogue" qui permet d'échanger avec le fermier
- 1 case rouge "Piège" qui fait perdre 3 PV au joueur s'il s'arrête dessus.
- 1 case rose "Soin" qui redonne 5 PV au joueur s'il s'arrête dessus.
- 1 case bleue "Combat" qui change le point de vue de la caméra et qu'il lance un combat entre le héros et le monstre présent sur la case. On a un plan rapproché du combat, avec la vie du monstre et une barre de STAMINA est apparu sur HUD du joueur. Pour pouvoir attaquer, le joueur doit appuyer sur son "Clic gauche" afin de remplir la barre de STAMINA. Une fois rempli à plus de 60, il inflige 3 dégâts toutes les secondes. Le monstre, ici un slime, quand à lui, attaque de 1 dégât toutes les secondes.
  
Le joueur commence sur la case "Dialogue" sur laquelle un fermier lui demande de tuer 3 slimes. S'il parvient à éliminer tous les monstres ET qu'il revienne parler au fermier sans mourir, le fermier donne une nouvelle arme en récompense. A la fin du dialogue, le joueur peut changer de zone. S'il meurt sur un piège ou au combat, le joueur doit recommencer la quête du début.
  
# Devoir 21/11 : Nature Morte – Unity Engine 6000.0.50f1

# Important
J'ai découvert aujourd'hui (21/11/25) qu'on pouvait exporter un level Unreal en FBX. Je ne sais pas si je pouvais utiliser cette technique donc j'ai fait une nouvelle scene utilisant cette technique. Tout se trouve dans ce dossier "Assets/NatureMorte/NatureMorteByExport"

# Consigne
Ce devoir à pour objectif d'évaluer votre compréhension des matières, lumières et post-process. Je vous demande de réaliser deux natures mortes, une dans chaque moteur de jeu. Elles devront contenir les éléments suivants :
- une matière opaque non-métallique.
- une matière opaque métallique
- une matière transparente
- une matière de type masked (bonus)
- la nature morte sera placée dans une pièce avec un accès extérieur.
- l'orientation et l'éclairage est à votre discrétion.
  
Le rendu devant ce faire sur les deux moteurs, j'évaluerais :
- le rendu sur unity (6pts)
- le rendu sur unreal (6pts)
- le fait que les deux rendus soient les plus proches possibles (6pts)
- l'idée ou la qualité graphique de l'ensemble (2pts)
  
Le rendu se fera par github pour les projets et vous rendrez aussi un screenshot de chaque moteur dans ce devoir. n'oubliez pas les liens github, je veux pouvoir voir les projets ! Relisez la première ligne de ce devoir histoire de pas oublier un des trois piliers du rendu.

# Notes d'intention
J'ai voulu reproduire une nature morte pensée et mis en scène par ma soeur pour un de ses devoirs en AG à Brassart. La référence sur trouve dans le dossier "Assets/NatureMorte/Pictures".

De part mes recherches d'assets peu concluantes, j'ai décidé de changer la composition globale de la nature morte. Enfin, j'ai remarqué en discutant avec d'autre étudiants qu'ils faisaient un rendu avec une lumière extérieur orange du crépuscule. J'ai décidé de faire un rendu de nuit pour me démarquer.  

Chaque asset utilisé se trouve dans leur dossier respectif. Les materials associés sont des materials recréés pour l'exercice.  

J'ai essayé de reproduire d'utiliser la refraction pour mon verre, comme sur Unreal, en utilisant un custom shader, mais en vain.

# Lien Github Unreal
Le projet Unreal associé est disponible ici : https://github.com/Badaril/GD3_LoopHeroUnreal_HO-VANIlian

# Retours Professeur
" Bon travail, compo interessante, des matières différentes un traitement identique, c'est très bien joué. Tes pommes font très plastique quand même. Sur le coup j'ai pensé que tu avais pris deux fois le rendu unreal. Donc un grand bravo. Tu peux être fier de toi. " 

Ce qui manque : plus de matériaux différents et plus de lumières
