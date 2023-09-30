﻿
public class BinarySearchTree<T> : IBinarySearchTree<T>
    where T : IComparable<T>
{

    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public T Value { get; private set; }
    }

    private Node root;
    public BinarySearchTree()
    {

    }
    public BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    private void PreOrderCopy(Node node)
    {
        if (node is null)
        {
            return;
        }
        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }

    public bool Contains(T element)
    {
        if (this.root == null)
        {
            return false;
        }
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) == 0)
            {
                return true;
            }
            else if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
        }
        return false;


    }



    public void EachInOrder(Action<T> action)
    {

        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (this.root == null)
        {
            return;
        }
        if (node.Left != null)
        {

            this.EachInOrder(node.Left, action);
        }

        action.Invoke(node.Value);
        if (node.Right != null)
        {
            this.EachInOrder(node.Right, action);

        }

    }

    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }
        return node;


    }

    public IBinarySearchTree<T> Search(T element)
    {
        var node = this.FindNode(element);
        if(node == null)
        {
            return null;
        }
        

        return new BinarySearchTree<T>(node);
       
    }

    private Node FindNode(T element)
    {
        var node = this.root;

        while(node != null)
        {
            if(element.CompareTo(node.Value) < 0)
            {
                node = node.Left;
            }
            else if(element.CompareTo(node.Value) > 0)
            {
                node = node.Right;
            }
            else
            {
                break;
            }
        }
        return node;
      
    }
}

