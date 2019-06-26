namespace CodeFirst数据迁移问题
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sys_ItemsDetail
    {
        [Key]
        [StringLength(50)]
        public string F_Id { get; set; }

        [StringLength(50)]
        public string F_ItemId { get; set; }

        [StringLength(50)]
        public string F_ParentId { get; set; }

        [StringLength(50)]
        public string F_ItemCode { get; set; }

        [StringLength(50)]
        public string F_ItemName { get; set; }

        [StringLength(500)]
        public string F_SimpleSpelling { get; set; }

        public bool? F_IsDefault { get; set; }

        public int? F_Layers { get; set; }

        public int? F_SortCode { get; set; }

        public bool? F_DeleteMark { get; set; }

        public bool? F_EnabledMark { get; set; }

        [StringLength(500)]
        public string F_Description { get; set; }

        public DateTime? F_CreatorTime { get; set; }

        [StringLength(50)]
        public string F_CreatorUserId { get; set; }

        public DateTime? F_LastModifyTime { get; set; }

        [StringLength(50)]
        public string F_LastModifyUserId { get; set; }

        public DateTime? F_DeleteTime { get; set; }

        [StringLength(50)]
        public string F_DeleteUserId { get; set; }
    }
}
