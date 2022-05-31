using System;

namespace Algorithms.BinaryTree
{
    /// <summary>
    /// Для хранения узлов дерева
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }
        public TNode Value { get; private set; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }

        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}
