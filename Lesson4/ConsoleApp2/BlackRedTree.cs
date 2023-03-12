namespace BlackRedTree
{
    /// <summary>
    /// Реализация левостороннего красно-черного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class BlackRedTree<T> where T : IComparable
    {
        public enum EColor
        {
            Black, Red
        }
        public class Node<T>
        {
            public T Value;
            public Node<T> Children_left;
            public Node<T> Children_right;
            public EColor Color;
            public override string ToString() => $"Node[Value = {Value}; Color = {Color}]";
        }

        private Node<T> _root;

        /// <summary>
        /// Добавление нового элемента
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Add(T value)
        {
            if (_root == null)
            {
                _root = new Node<T>()
                {
                    Color = EColor.Black,
                    Value = value
                };
                return true;
            }
            else
            {
                bool res = AddNode(_root, value);
                _root = Rebalance(_root);
                _root.Color = EColor.Black;
                return res;
            }
        }

        /// <summary>
        /// корень дерева
        /// </summary>
        public Node<T> Root => _root;

        /// <summary>
        /// подсчет дочерних элементов в узле (включительно)
        /// </summary>
        /// <typeparam name="T2"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        public static int GetNodesCount<T2>(Node<T2> node)
        {
            if (node == null) return 0;
            return 1 + GetNodesCount(node.Children_left) + GetNodesCount(node.Children_right);
        }

        /// <summary>
        /// Добавление нового узла
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool AddNode(Node<T> node, T value)
        {
            if (value.CompareTo(node.Value) == 0)
                return false; //такой элемент уже есть!

            bool res;
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Children_left != null)
                {
                    res = AddNode(node.Children_left, value);
                    node.Children_left = Rebalance(node.Children_left);
                    return res;
                }
                else
                {
                    node.Children_left = new()
                    {
                        Value = value,
                        Color = EColor.Red //новые ноды при создании имеют красный цвет!                       
                    };
                    return true;
                }
            }
            else
            {
                if (node.Children_right != null)
                {
                    res = AddNode(node.Children_right, value);
                    node.Children_right = Rebalance(node.Children_right);
                    return res;
                }
                else
                {
                    node.Children_right = new()
                    {
                        Value = value,
                        Color = EColor.Red //новые ноды при создании имеют красный цвет!
                    };
                    return true;
                }
            }

        }
        /// <summary>
        /// Балансировка
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node<T> Rebalance(Node<T> node)
        {
            Node<T> ret = node;
            bool needRebalnce;
            do
            {
                needRebalnce = false;
                if (ret.Children_right?.Color == EColor.Red && ret.Children_left?.Color != EColor.Red)
                {//слева черный, справа - красный
                    needRebalnce = true;
                    ret = RightSwap(ret);
                }
                if (ret.Children_left?.Color == EColor.Red && ret.Children_left.Children_left?.Color == EColor.Red)
                {//2 красных слева подряд
                    needRebalnce = true;
                    ret = LeftSwap(ret);
                }
                if (ret.Children_left?.Color == EColor.Red && ret.Children_right?.Color == EColor.Red)
                {
                    needRebalnce = true;
                    ColorSwap(ret);
                }

            } while (needRebalnce);
            return ret;
        }
        /// <summary>
        /// Правый поворот
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node<T> RightSwap(Node<T> node)
        {
            Node<T> right = node.Children_right;
            Node<T> between = right.Children_left;
            right.Children_left = node;
            node.Children_right = between;
            right.Color = node.Color;
            node.Color = EColor.Red;
            return right;
        }
        /// <summary>
        /// Левый поворот
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private Node<T> LeftSwap(Node<T> node)
        {
            Node<T> left = node.Children_left;
            Node<T> between = left.Children_right;
            left.Children_right = node;
            node.Children_left = between;
            left.Color = node.Color;
            node.Color = EColor.Red;
            return left;
        }
        /// <summary>
        /// Смена цвета
        /// </summary>
        /// <param name="node"></param>
        private void ColorSwap(Node<T> node)
        {
            node.Color = EColor.Red;
            node.Children_left.Color = EColor.Black;
            node.Children_right.Color = EColor.Black;
        }
    }
}
