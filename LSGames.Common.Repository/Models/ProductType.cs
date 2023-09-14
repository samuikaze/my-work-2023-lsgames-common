using System;
using System.Collections.Generic;

namespace LSGames.Common.Repository.Models;

/// <summary>
/// 作品分類
/// </summary>
public partial class ProductType
{
    /// <summary>
    /// 作品分類 PK
    /// </summary>
    public long ProductTypeId { get; set; }

    /// <summary>
    /// 作品分類名稱
    /// </summary>
    public string ProductTypeName { get; set; } = null!;

    /// <summary>
    /// 作品分類建立時間
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// 作品分類最後更新時間
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
