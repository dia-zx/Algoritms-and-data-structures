﻿/*
## Урок 4. Структуры данных дерево и хэш-таблица

Необходимо превратить собранное на семинаре дерево поиска в полноценное левостороннее красно-черное дерево. И реализовать в нем метод добавления новых элементов с балансировкой.

Красно-черное дерево имеет следующие критерии:
-Каждая нода имеет цвет (красный или черный)
-Корень дерева всегда черный
- Новая нода всегда красная
- Красные ноды могут быть только левым ребенком
- У краной ноды все дети черного цвета

Соответственно, чтобы данные условия выполнялись, после добавления элемента в дерево необходимо произвести балансировку,
благодаря которой все критерии выше станут валидными.
Для балансировки существует 3 операции – левый малый поворот, правый малый поворот и смена цвета.
*/


using BlackRedTree;

BlackRedTree<int> tree = new();

//заполним дерево случайными элементами и проверим сбалансированность
for (int i = 0; i < 100_000; i++)
    tree.Add(Random.Shared.Next(1000_000));

Console.WriteLine($"Всего элементов в дереве: {BlackRedTree.BlackRedTree<int>.GetNodesCount(tree.Root)}");
Console.WriteLine($"Всего элементов в дереве слева от root: {BlackRedTree.BlackRedTree<int>.GetNodesCount(tree.Root.Children_left)}");
Console.WriteLine($"Всего элементов в дереве справа от root: {BlackRedTree.BlackRedTree<int>.GetNodesCount(tree.Root.Children_right)}");
