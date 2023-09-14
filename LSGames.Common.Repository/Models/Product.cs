using System;
using System.Collections.Generic;

namespace LSGames.Common.Repository.Models;

/// <summary>
/// 作品一覽
/// </summary>
public partial class Product
{
    /// <summary>
    /// 作品 PK
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// 作品名稱
    /// </summary>
    public string ProductTitle { get; set; } = null!;

    /// <summary>
    /// 作品視覺圖
    /// </summary>
    public string VisualImage { get; set; } = null!;

    /// <summary>
    /// 作品說明
    /// </summary>
    public string Description { get; set; } = null!;

    /// <summary>
    /// 作品連結
    /// </summary>
    public string? ProductUrl { get; set; }

    /// <summary>
    /// 作品分類 PK
    /// </summary>
    public long ProductTypeId { get; set; }

    /// <summary>
    /// 作品釋出日期
    /// </summary>
    public DateTime? ReleaseDate { get; set; }

    /// <summary>
    /// 作品建立時間
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// 作品最後更新時間
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<ProductPlatformMapper> ProductPlatformMappers { get; set; } = new List<ProductPlatformMapper>();

    public virtual ProductType ProductType { get; set; } = null!;
}
