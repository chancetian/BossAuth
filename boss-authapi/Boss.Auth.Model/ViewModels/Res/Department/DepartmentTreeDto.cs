using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boss.Auth.Model.ViewModels.Res.Department
{
    public class DepartmentTreeDto
    {
        /// <summary>
        /// id
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Label { set; get; }
        /// <summary>
        /// 子部门
        /// </summary>
        public List<DepartmentTreeDto> Children { set; get; }
    }
}
