using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttendanceTools
{
    /// <summary>
    ///     Excel导出
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property | AttributeTargets.Field)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute(string name, int index)
        {
            Name = name;
            Index = index;
        }

        public ExportAttribute(string name, int index, string commentSource)
        {
            Name = name;
            Index = index;
            CommentSource = commentSource;
        }

        /// <summary>
        ///     导出Excel的列名
        /// </summary>
        public string Name { get; set; }

        //列索引
        public int Index { get; set; }

        public string CommentSource { get; set; }
    }
}
