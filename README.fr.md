# Calculateur de bundle

[![en](https://img.shields.io/badge/lang-en-red.svg)](https://github.com/hm-henriquematias/BundleCalculator/blob/main/Readme.md)

### Qu'est-ce qu'un bundle ?
Avant de commencer à décrire l’application, il est nécessaire de définir ce qu’est un bundle.
Un lot est un élément composé d'un ou plusieurs éléments. Par exemple, un vélo est composé de
roues, pédales, entre autres.

### Description
Cette application a pour objectif de calculer le nombre de bundles possibles à partir d'un stock de disponibles
articles

### Données
Data.json est un fichier qui renseigne les règles pour les lots, les articles et leurs quantités respectives

### Division de la solution

La solution est divisée en deux projets, un projet principal, qui est une application console,
et un projet de test qui contient des tests unitaires et des tests d'intégration.

### Pourquoi un seul projet ? (outre les tests)
Il est fréquent de voir des solutions dotnet comportant plusieurs projets afin que chaque couche de l'application
est bien isolé, en évitant les couplages entre les couches et en maintenant de bonnes pratiques.

Mais soyons honnêtes, aux fins de cette application, tout autre chose que la division en
les dossiers que nous avons ici ne sont qu'une **suringénierie**.

### À propos de l'algorithme principal
1. Reçoit le nom d'un bundle
2. Valide si le bundle informé existe
     a. Si ce n'est pas le cas, ignorez-le et renvoyez zéro
     b. Si tel est le cas, continuez et faites défiler les éléments requis (voir étape 3)
3. Vérifie si l'article demandé est un lot composé d'autres articles
     a. Si c'est le cas, appelez cette même validation en revenant à l'étape 1
     b. Si ce n'est pas le cas, vérifiez si l'article est en stock, calculez combien peut être utilisé et passez à l'étape 4.
4. Stocke le nombre de ces lots qu'il est possible de créer avec chaque catégorie d'articles et renvoie le plus petit, afin qu'un lot incomplet ne soit pas créé.

# À propos
### Auteur
Henrique Matias

### Technologies utilisées
- Langage : C#
- Framework : .NET Core 7
-Type d'application : Console
