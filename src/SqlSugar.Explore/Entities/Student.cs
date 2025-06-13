using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlSugar.Explore.Entities;

[SugarTable("student")]
internal class Student
{
    [SugarColumn(ColumnName = "id")]
    public int Id { get; set; }

    [SugarColumn(ColumnName = "student_name")]
    public string Name { get; set; }

    [SugarColumn(ColumnName = "subject_name")]
    public string Subject { get; set; }

    [SugarColumn(ColumnName = "score")]
    public int Score { get; set; }

    [SugarColumn(ColumnName = "father_id")]
    public int FatherId { get; set; }
}
