using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
    Given a binary tree, find the lowest common ancestor (LCA) of two given nodes in the tree.

    According to the definition of LCA on Wikipedia: “The lowest common ancestor is defined between two nodes v and w as the lowest node in T that has both v and w as descendants (where we allow a node to be a descendant of itself).”

            _______3______
           /              \
        ___5__          ___1__
       /      \        /      \
       6      _2       0       8
             /  \
             7   4
    For example, the lowest common ancestor (LCA) of nodes 5 and 1 is 3. Another example is LCA of nodes 5 and 4 is 5, since a node can be a descendant of itself according to the LCA definition.
    */
    class LCAofBinaryTree
    {
        TreeNode lca = null;
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            lcaInternal(root, p, q);

            return lca;
        }

        int lcaInternal(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return 0;
            if (lca != null) return 2; //found already

            int ret = 0;
            if (root == p || root == q)
            { 
                ret++;
            }
            ret += lcaInternal(root.left, p, q);

            if (ret == 2)
            {
                lca = lca == null ? root : lca;
                return 2;
            } else
            {
                ret += lcaInternal(root.right, p, q);
            }
                
            lca = ret == 2 ? (lca == null ? root : lca) : null;

            return ret;
        }

    }

    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
