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
using Thundax.HierarchyChart.contracts;

namespace Thundax.HierarchyChart
{
    public class Node<T> : INode<T>
    {
        private T _data;
        private Collection<INode<T>> _children = new Collection<INode<T>>();

        public Node(T data)
        {
            _data = data;
        }

        public Collection<INode<T>> Children
        {
            get
            {
                return _children;
            }
        }

        public T Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }

        public string GetJson()
        {
            string result ="";
            result += _data.ToString();
            if (_children.Count > 0)
            {
                result += ", ";
                result += "\"children\": [";
                foreach (INode<T> element in _children)
                {
                    result += "{ " + element.GetJson() + " },";
                }
                result = result.Remove(result.Length - 1);
                result += " ]";
        }
            return result;
        }
    }
}
