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

using Thundax.HierarchyChart.contracts;
using Thundax.HierarchyChart.extensions;

namespace Thundax.HierarchyChart
{
    public class UserNode : IUserNode
    {
        public string Department { get; set; }
        public string Location { get; set; }
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string DisplayName { get; set; }
        public string Title { get; set; }
        public int ManagerId { get; set; }
        public bool IsManager { get; set; }
        public bool IsDepartment { get; set; }

        public override string ToString()
        {
            var name = DisplayName.ReplaceFirst(" ", "<br>");
            string newTitle = Title;
            if (Title.Length > 14)
                newTitle = Title.ReplaceLast(" ", "<br>");
            newTitle = newTitle.Replace("Senior", "Sr.");
            if (!newTitle.Contains("<br>"))
                newTitle = newTitle + "<br>";

            if (!IsDepartment)
            {
                string locationFormat = string.Format("<span class=\\\"badgeLocation{0}\\\">{1}</span>",
                    Location.Replace(" ", "").Trim().ToLower(CultureInfo.CurrentCulture), Location);
                return string.Format(
                        "\"id\" : \"{0}\", \"name\": \"{1}\", \"title\": \"<b>{2}</b><br>{3}\", \"ismanager\": \"{4}\", \"employeeid\": \"{5}\"",
                        Id, name, newTitle, locationFormat, IsManager, EmployeeId); //<i>{3}</i><br>Department
            }
            string spanDepartment = name;
            if (!name.Contains("<br>"))
                spanDepartment = string.Format("<span class=\\\"spanDepartment\\\">{0}</span>", name);
            return string.Format("\"id\" : \"{0}\", \"name\": \"{1}\", \"title\": \"{2}\", \"ismanager\": \"{3}\"",
                Id, spanDepartment, "", IsManager);
        }
    }
}
