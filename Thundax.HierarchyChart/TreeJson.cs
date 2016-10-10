//The MIT License (MIT)

//Copyright (c) 2016 Jordi Corbilla

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in
//all copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//THE SOFTWARE.

using System.Collections.ObjectModel;
using System.Linq;
using Thundax.HierarchyChart.contracts;

namespace Thundax.HierarchyChart
{
    public static class TreeJson
    {
        public static Tree<IUserNode> Build(Collection<IUserNode> nodes)
        {
            IUserNode root = nodes.FirstOrDefault(user => user.ManagerId == -1);
            Tree<IUserNode> tree = new Tree<IUserNode>(root);
            if (root != null) BuildRecursively(tree.Root, nodes, root.Id);
            return tree;
        }

        public static void BuildRecursively(INode<IUserNode> root, Collection<IUserNode> nodes, int managerId)
        {
            var children = from node in nodes
                           where node.ManagerId == managerId
                           select node;

            foreach (IUserNode child in children)
            {
                INode<IUserNode> p = new Node<IUserNode>(child);
                root.Children.Add(p);
                BuildRecursively(p, nodes, child.Id);
            }
        }
    }
}
