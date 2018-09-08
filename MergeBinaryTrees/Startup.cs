using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeBinaryTrees
{
    internal static class Startup
    {
        private static void Main()
        {
            #region INFO: Binary Search Tree & Merge Binary Trees
            // INFO: Binary Search Tree & Merge Binary Trees
            /*var firstTree = new Solution.TreeNode(1)
            {
                left = new Solution.TreeNode(3) {left = new Solution.TreeNode(5)}
            };
            firstTree.right = new Solution.TreeNode(2);

            var secondThree = new Solution.TreeNode(2)
            {
                left = new Solution.TreeNode(1), right = new Solution.TreeNode(3)
            };
            secondThree.left.right = new Solution.TreeNode(4);
            secondThree.right.right = new Solution.TreeNode(7);

            var mergedTreeRoot = Solution.MergeTrees(firstTree, secondThree);

            var foundResult = Solution.SearchBST(mergedTreeRoot, 7);*/

            /*var firstTree = new Solution.TreeNode(4);
            Solution.InsertData(ref firstTree, 2);
            Solution.InsertData(ref firstTree, 1);
            Solution.InsertData(ref firstTree, 3);
            Solution.InsertData(ref firstTree, 7);

            var foundResultBST = Solution.SearchBST(firstTree, 5);
            Console.WriteLine(foundResultBST);*/
            #endregion
            
            #region All Possible Paths Logic
            // INFO: resultTree - All Possible Paths
            var firstTree = new Solution.TreeNode(4);
            // Test Cases
            var Data = new List<int>
                {5, 10, 1, 2, 3, 6, 7, 11, 20, 12, 8, 44, 24, 17, 21, 77, 88, 99, 34, 45, 67, 41, 32, 38};
            Solution.InsertData(ref firstTree, Data);

            var resultTree = Solution.BinaryTreePaths(firstTree);
            foreach (var tree in resultTree) Console.WriteLine(@"Possible Path: " + tree);
            #endregion
        }
    }

    internal static class Solution
    {
        public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;
            t1.val += t2.val;
            t1.left = MergeTrees(t1.left, t2.left);
            t1.right = MergeTrees(t1.right, t2.right);
            return t1;
        }

        public static TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;
            if (root.val == val)
                return root;
            if (val < root.val && root.left != null)
                return SearchBST(root.left, val);
            if (val > root.val && root.right != null)
                return SearchBST(root.right, val);

            return null;
        }

        public static bool IsLeaf(TreeNode node)
        {
            return node.right == null && node.left == null;
        }

        private static void DFSHelper(TreeNode node, ref List<string> result, string partial)
        {
            if (node.left == null && node.right == null) result.Add(partial + node.val);

            if (node.left != null)
                DFSHelper(node.left, ref result, partial + node.val + " -> ");
            if (node.right != null)
                DFSHelper(node.right, ref result, partial + node.val + " -> ");
        }

        /// <summary>
        ///     Recursive DFS (Depth-First Search) [Pre-Order]
        /// </summary>
        /// <param name="root">TreeNode</param>
        public static IEnumerable<string> BinaryTreePaths(TreeNode root)
        {
            var result = new List<string>();
            if (root == null)
                return result;
            DFSHelper(root, ref result, "");
            return result;

            #region Old Methods

            /*if (!root.isParent)
            {
                Console.WriteLine(0);
                binaryTreePathsList.Add(0);
            }
            else
            {
                Console.WriteLine(root.val);
                binaryTreePathsList.Add(root.val);
            }

            if (root.left != null)
            {
                BinaryTreePaths(root.left);
            }
            if (root.right != null)
            {
                BinaryTreePaths(root.right);
            }*/


            /*Stack<TreeNodeChildren> s = new Stack<TreeNodeChildren>();
            s.Push(root);
            while (s.Count > 0)
            {
                var n = s.Pop();
                // Do Action
                Console.WriteLine(n.val);
                binaryTreePathsList.Add(n.val);
                foreach (var child in n.children.ToArray().Reverse())
                {
                    s.Push(child);
                    
                }
            }*/
            // Do action
            //Console.WriteLine(root.val);
            //binaryTreePathsList.Add(root.val);

            #endregion
        }

        public static void InsertData(ref TreeNode node, int data)
        {
            if (node == null)
                node = new TreeNode(data);
            else if (node.val < data)
                InsertData(ref node.right, data);

            else if (node.val > data) InsertData(ref node.left, data);
        }

        public static void InsertData(ref TreeNode node, IEnumerable<int> dataList)
        {
            foreach (var data in dataList)
            {
                if (node == null)
                    node = new TreeNode(data);
                else if (node.val < data)
                    InsertData(ref node.right, data);

                else if (node.val > data) InsertData(ref node.left, data);
            }
        }

        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public int val;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}