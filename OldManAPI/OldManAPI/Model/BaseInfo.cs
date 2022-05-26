namespace OldManAPI.Model
{
    public class BaseInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string? Name { get; set ; }
        /// <summary>
        /// 图片
        /// </summary>
        public string? Image { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string? Content { get; set; }
    }
}
