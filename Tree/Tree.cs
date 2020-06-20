using System;
using System.Collections.Generic;

namespace Labb4
{
    public class Tree : ITree
    {
        //Creating a property to get the count
        public int Count
        {
            get; set;
        }

        //Reference for RootNode
        public Node rootNode;
        //Adding the node
        public void Add(string key, int value)
        {
            //Creating a new node and assigning values
            Node newNode = new Node();
            newNode.Key = key;
            newNode.Value = value;
            //If there isn't any node already
            if (rootNode == null)
                rootNode = newNode;
            //Else
            else
            {
                Node currentNode = rootNode;
                Node LeafNode = null;
                //Finding the empty node
                while (true)
                {
                    //LeafNode to hold the most immediate parent
                    LeafNode = currentNode;
                    //Comparing for the right and left
                    if (key.CompareTo(LeafNode.Key) < 0)
                    {
                        //Finding the left and if there isn't any left. 
                        //Add the node there and break
                        currentNode = currentNode.Left;
                        if (currentNode == null)
                        {
                            LeafNode.Left = newNode;
                            break;
                        }
                    }
                    //If it is right
                    else
                    {
                        currentNode = currentNode.Right;
                        //If currentNode is null
                        if (currentNode == null)
                        {
                            //Set te rigt node
                            LeafNode.Right = newNode;
                            //Break
                            break;
                        }
                    }
                }
            }
            //Add one into the count
            this.Count++;
        }

        public bool Contains(string key)
        {
            //Getting te currentNode
            Node currentNode = rootNode;
            //Calling the Containsmethod with the rootNode
            return Contains(key, ref currentNode);
        }

        private bool Contains(string key, ref Node binarySearchTree)
        {
            //If the tree is null
            if (binarySearchTree == null)
            {
                return false;
            }

            //If there is only one element
            if (binarySearchTree.Key == key)
            {
                return true;
            }

            //Compare and start with the left sub tree
            if (key.CompareTo(binarySearchTree.Key) < 0)
            {
                //Recursively call the function
                return Contains(key, ref binarySearchTree.Left);
            }
            //Compare and start with the right sub tree
            if (key.CompareTo(binarySearchTree.Key) > 0)
            {
                //Recursively call the function with right subtree
                return Contains(key, ref binarySearchTree.Right);
            }
            //otherwise return false;
            return false;
        }


        //Method to get the value of certain key
        public int Get(string key)
        {
            //Getting the current node
            Node currentNode = rootNode;
            //If the key is not matcheds
            while (currentNode.Key != key)
            {
                //if there isn't any element
                if (currentNode != null)
                {
                    //Compare the key for going right or let
                    if (key.CompareTo(currentNode.Key) < 0)
                    {
                        if (currentNode.Left != null)
                            currentNode = currentNode.Left;
                        else
                        {
                            currentNode = null;
                            break;
                        }
                    }
                    else if (key.CompareTo(currentNode.Key) > 0)
                    {
                        if (currentNode.Right != null)
                            currentNode = currentNode.Right;
                        else
                        {
                            currentNode = null;
                            break;
                        }
                    }
                }
            }
            //After above code, if the current node is null , throw keyNotFoundException
            if (currentNode == null)
                throw new KeyNotFoundException();
            else
                //Return the value
                return currentNode.Value;
        }

        public int Height()
        {
            //getting the root node
            Node currentNode = rootNode;
            //calling the height method
            return DetermineHeightOfTheBinarySearchTree(currentNode);
        }

        int DetermineHeightOfTheBinarySearchTree(Node rootNode)
        {
            //if there isn't any element: return negative
            if (rootNode == null)
            {
                return -1;
            }

            //Recursively calling the functions to determine the height
            int leftSubTreeheight = DetermineHeightOfTheBinarySearchTree(rootNode.Left);
            int RightSubTreeHeight = DetermineHeightOfTheBinarySearchTree(rootNode.Right);

            //If the left sub tree has a greater height return that else return the height of right subtree
            if (leftSubTreeheight > RightSubTreeHeight)
            {
                return leftSubTreeheight + 1;
            }
            else
            {
                return RightSubTreeHeight + 1;
            }
        }

        //Method to remove the node
        public void Remove(string key)
        {
            rootNode = RemoveFromBinarySearchTree(rootNode, key);
        }


        Node RemoveFromBinarySearchTree(Node root, string key)
        {
            /* Base Case: If the tree is empty */
            if (root == null) return root;

            /* Otherwise, recur down the tree */
            if (key.CompareTo(root.Key) < 0)
                root.Left = RemoveFromBinarySearchTree(root.Left, key);
            else if (key.CompareTo(root.Key) > 0)
                root.Right = RemoveFromBinarySearchTree(root.Right, key);

            // if key is same as root's key, then This is the node 
            // to be deleted 
            else
            {
                // node with only one child or no child 
                if (root.Left == null)
                {
                    if (root.Key == key)
                    {
                        Count--;
                        return root.Right;
                    }
                }
                else if (root.Right == null)
                {
                    if (root.Key == key)
                    {
                        Count--;
                        return root.Left;
                    }
                }
                //if there are two children: Call the FindTheMinimumChild
                root.Key = FindTheMinimumCild(root.Right);
                // Delete the Child
                root.Right = RemoveFromBinarySearchTree(root.Right, root.Key);
            }
            //If the key is found: reduce the count
            if (root.Key == key) Count--;
            //Return the root
            return root;
        }
        string FindTheMinimumCild(Node root)
        {
            string SmallerChild = root.Key;
            //It's obvious tthat the values on left will be smaller. Therefore, only going towards left
            while (root.Left != null)
            {
                SmallerChild = root.Left.Key;
                root = root.Left;
            }
            return SmallerChild;
        }


        public void Set(string key, int value)
        {
            //Getting current node
            Node currentNode = rootNode;
            do
            {
                //If there are elements in the tree
                if (currentNode != null)
                {
                    //Comparing with the left
                    if (key.CompareTo(currentNode.Key) < 0)
                    {
                        //Setting the current node to left
                        if (currentNode.Left != null)
                            currentNode = currentNode.Left;
                        else
                        {
                            currentNode = null;
                            break;
                        }
                    }
                    //Comparing with the Right
                    else if (key.CompareTo(currentNode.Key) > 0)
                    {
                        //Setting the currentNode to Right
                        if (currentNode.Right != null)
                            currentNode = currentNode.Right;
                        else
                        {
                            currentNode = null;
                            break;
                        }
                    }
                }
                //While the key is not found
            } while (currentNode.Key != key);
            //Setting the value 
            if (currentNode == null)
                throw new KeyNotFoundException();
            else
                //When found, set the value
                currentNode.Value = value;
        }

        public List<KeyValuePair<string, int>> Traverse(SortOrder order)
        {
            //Initializing a new List of KeyValuePair
            List<KeyValuePair<string, int>> bstElements = new List<KeyValuePair<string, int>>();

            //If the sorting is InOrder
            if (order == SortOrder.In)
            {
                var list = Inorder(rootNode, bstElements);
                return list;
            }
            //If the sorting is PreOrder
            else if (order == SortOrder.Pre)
            {
                var list = Preorder(rootNode, bstElements);
                return list;
            }
            //If the sorting is PostOrder
            else if (order == SortOrder.Post)
            {
                var list = PostOrder(rootNode, bstElements);
                return list;
            }
            return null;
        }

        public List<KeyValuePair<string, int>> PostOrder(Node Root, List<KeyValuePair<string, int>> list)
        {
            //If there are any elements in the binary search tree
            if (Root != null)
            {
                //Recursively call the PostOrder Method for Left and Right Sub Tree
                PostOrder(Root.Left, list);
                PostOrder(Root.Right, list);
                //Adding the nodes and their values into list
                list.Add(new KeyValuePair<string, int>(Root.Key, Root.Value));
            }
            return list;
        }

        //Same explanation as of PostOrder with the difference of being the order of the display
        public List<KeyValuePair<string, int>> Preorder(Node Root, List<KeyValuePair<string, int>> list)
        {
            if (Root != null)
            {
                list.Add(new KeyValuePair<string, int>(Root.Key, Root.Value));
                Preorder(Root.Left, list);
                Preorder(Root.Right, list);
            }
            return list;
        }
        //Same explanation as of PostOrder with the difference of being the order of the display
        public List<KeyValuePair<string, int>> Inorder(Node Root, List<KeyValuePair<string, int>> list)
        {
            if (Root.Left != null)
            {
                Inorder(Root.Left, list);
            }
            list.Add(new KeyValuePair<string, int>(Root.Key, Root.Value));
            if (Root.Right != null)
            {
                Inorder(Root.Right, list);
            }
            return list;
        }
        //Counting the frequency of each word
        public Node CountingFrequenciesOfEachWord(Node root, string data)
        {
            //If there are not elements, than add one in the Tree
            if (root == null)
            {
                return AddNewNodeForCountingFrequencies(data);
            }

            // Use the queue data structure 
            // and push the root of tree to Queue 
            //to maintain an inorder display
            List<Node> QueueForBinarySearchTree = new List<Node>();
            //Adding the node to the Queue 
            QueueForBinarySearchTree.Add(root);

            //Checking to see if there are any elements
            while (QueueForBinarySearchTree.Count != 0)
            {
                //Getting the rood node
                Node NodeForCountingFrequency = QueueForBinarySearchTree[0];
                QueueForBinarySearchTree.RemoveAt(0);
                // If the word to be 
                // inserted is present, 
                // update the value
                if (NodeForCountingFrequency.Key == data)
                {
                    NodeForCountingFrequency.Value++;
                    break;
                }
                // If the left child is 
                // empty add a new node 
                // as the left child 
                if (NodeForCountingFrequency.Left == null)
                {
                    NodeForCountingFrequency.Left = AddNewNodeForCountingFrequencies(data);
                    break;
                }
                else
                {
                    // If the character is present 
                    // as a left child, update the 
                    // value and exit the loop 
                    if (NodeForCountingFrequency.Left.Key == data)
                    {
                        NodeForCountingFrequency.Left.Value++;
                        break;
                    }

                    // Add the left child to 
                    // the queue for further 
                    // processing 
                    QueueForBinarySearchTree.Add(NodeForCountingFrequency.Left);
                }

                // If the right child is empty, 
                // add a new node to the right 
                if (NodeForCountingFrequency.Right == null)
                {
                    NodeForCountingFrequency.Right = AddNewNodeForCountingFrequencies(data);
                    break;
                }
                else
                {
                    // If the word is present 
                    // as a right child, update the 
                    // value and exit the loop 
                    if (NodeForCountingFrequency.Right.Key == data)
                    {
                        NodeForCountingFrequency.Right.Value++;
                        break;
                    }

                    // Add the right child to 
                    // the queue for further 
                    // processing 
                    QueueForBinarySearchTree.Add(NodeForCountingFrequency.Right);
                }
            }
            return root;
        }

        //Creating another newNode method for counting frequencies as returning the node was necessary
        //and without it, the interface could have raised the error
        Node AddNewNodeForCountingFrequencies(string data)
        {
            //Creat a new node and return the value
            Node rootNode = new Node();
            rootNode.Key = data;
            rootNode.Value = 1;
            rootNode.Left = rootNode.Right = null;
            return rootNode;
        }

        //Method for displaying frequencies
        public List<KeyValuePair<string,int>> DisplayFrequencies(Node Root)
        {
            var bst = new List<KeyValuePair<string, int>>();
            var list = Inorder(Root, bst);
            return list;
        }
    }
}