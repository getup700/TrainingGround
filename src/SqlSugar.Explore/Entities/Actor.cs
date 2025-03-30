namespace SqlSugar.Explore.Entities
{
    internal class Actor
    {
        [SugarColumn(ColumnName = "actor_id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "first_name", IsNullable = false)]
        public string FirstName { get; set; } = default!;

        [SugarColumn(ColumnName ="last_name",IsNullable =false)]
        public string LastName { get; set; } = default!;

        [SugarColumn(ColumnName ="last_update",IsNullable = false)]
        public DateTime LastUpdate { get; set; }
    }

}
