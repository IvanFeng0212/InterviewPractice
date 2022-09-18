using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewPractice
{
    [TestFixture]
    public class BinaryTreeDepth
    {
        [Test]
        public void GetDepth() 
        {
            var root = new BinaryNode(1);
            var level2_1 = new BinaryNode(2);
            var level2_2 = new BinaryNode(3);
            var level3_1 = new BinaryNode(4);
            var level3_2 = new BinaryNode(5);
            var level3_3 = new BinaryNode(6);
            var level4_1 = new BinaryNode(7);

            root.LeftNode = level2_1;
            root.RightNode = level2_2;
            level2_1.LeftNode = level3_1;
            level2_2.LeftNode = level3_2;
            level2_2.RightNode = level3_3;
            level3_2.LeftNode = level4_1;

            var recursion_Val = Recursion_GetDepth(root);
            var DFS_Val = DFS_GetDepth(root);

            Assert.AreEqual(4, recursion_Val);
            Assert.AreEqual(4, DFS_Val);
        }

        /// <summary>
        /// 遞迴法
        /// </summary>
        private int Recursion_GetDepth(BinaryNode node) 
        {
            if(node == null) return 0;

            int leftDepth = Recursion_GetDepth(node.LeftNode);
            int rightDepth = Recursion_GetDepth(node.RightNode);

            if(leftDepth >= rightDepth)
            {
                return leftDepth + 1;
            }

            return rightDepth + 1;
        }

        /// <summary>
        /// 深度優先
        /// </summary>
        private int DFS_GetDepth(BinaryNode root)
        {
            if (root == null) return 1;

            int depth = 1;

            List<BinaryNode> currentNodes = new List<BinaryNode>();
            List<BinaryNode> nextNodes = new List<BinaryNode>();
            List<BinaryNode> temp = new List<BinaryNode>();

            currentNodes.Add(root);

            while (true)
            {
                foreach(var node in currentNodes)
                {
                    if(node.LeftNode != null)
                    {
                        nextNodes.Add(node.LeftNode);
                    }

                    if(node.RightNode != null)
                    {
                        nextNodes.Add(node.RightNode);
                    }

                    if(nextNodes.Count > 0)
                    {
                        depth += 1;
                    }
                    else
                    {
                        return depth;
                    }
                }

                currentNodes.Clear();
                temp = currentNodes;

                currentNodes = nextNodes;
                nextNodes = temp;
            }
        }
    }

    internal class BinaryNode
    {
        public BinaryNode(int val)
        {
            this.Value = val;
        }

        public int Value { get; set; }

        public BinaryNode LeftNode { get; set; }

        public BinaryNode RightNode { get; set; }
    }
}
