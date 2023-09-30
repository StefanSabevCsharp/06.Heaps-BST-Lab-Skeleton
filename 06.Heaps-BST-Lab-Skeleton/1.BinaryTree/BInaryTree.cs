
using System.Runtime.CompilerServices;
using System.Text;

public class BinaryTree<T> : IAbstractBinaryTree<T>
{
    public BinaryTree(T element, IAbstractBinaryTree<T> left, IAbstractBinaryTree<T> right)
    {
        this.Value = element;
        this.LeftChild = left;
        this.RightChild = right;
    }

    public T Value { get; private set; }

    public IAbstractBinaryTree<T> LeftChild { get; private set; }

    public IAbstractBinaryTree<T> RightChild { get; private set; }

    public string AsIndentedPreOrder(int indent)
    {
        StringBuilder sb = new StringBuilder();

        this.PrintPreOrder(this, indent, sb);

        return sb.ToString().TrimEnd();
    }

    private void PrintPreOrder(IAbstractBinaryTree<T> binaryTree, int indent, StringBuilder sb)
    {

        sb.AppendLine($"{new string(' ', indent)}{binaryTree.Value.ToString()}");

        if (binaryTree.LeftChild != null)
        {
            this.PrintPreOrder(binaryTree.LeftChild, indent + 2, sb);
        }
        if (binaryTree.RightChild != null)
        {
            this.PrintPreOrder(binaryTree.RightChild, indent + 2, sb);
        }

    }

    public void ForEachInOrder(Action<T> action)
    {

        if (this.LeftChild != null)
        {
            this.LeftChild.ForEachInOrder(action);
        }
        action.Invoke(this.Value);
        if (this.RightChild != null)
        {
            this.RightChild.ForEachInOrder(action);
        }
    }

    public IEnumerable<IAbstractBinaryTree<T>> InOrder()
    {
        List<IAbstractBinaryTree<T>> result = new();

        if (this.LeftChild != null)
        {
            result.AddRange(this.LeftChild.InOrder());
        }
        result.Add(this);
        if (this.RightChild != null)
        {
            result.AddRange(this.RightChild.InOrder());
        }

        return result;
    }

    public IEnumerable<IAbstractBinaryTree<T>> PostOrder()
    {
        List<IAbstractBinaryTree<T>> result = new();

        if (this.LeftChild != null)
        {
            result.AddRange(this.LeftChild.PostOrder());
        }
        if (this.RightChild != null)
        {
            result.AddRange(this.RightChild.PostOrder());
        }

        result.Add(this);

        return result;
    }

    public IEnumerable<IAbstractBinaryTree<T>> PreOrder()
    {
        List<IAbstractBinaryTree<T>> result = new List<IAbstractBinaryTree<T>>();

        result.Add(this);

        if (this.LeftChild != null)
        {
            result.AddRange(this.LeftChild.PreOrder());

           
        }

        if (this.RightChild != null)
        {
            result.AddRange(this.RightChild.PreOrder());
        }

        return result;

    }
}

