using System;
using System.Collections.Generic;

namespace LSGames.Common.Repository.Models;

/// <summary>
/// 作品與平台
/// </summary>
public partial class ProductPlatformMapper
{
    /// <summary>
    /// 作品與平台 PK
    /// </summary>
    public long ProductPlatformMapperId { get; set; }

    /// <summary>
    /// 作品 PK
    /// </summary>
    public long ProductId { get; set; }

    /// <summary>
    /// 作品平台 PK
    /// </summary>
    public long ProductPlatformId { get; set; }

    /// <summary>
    /// 建立時間
    /// </summary>
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// 最後更新時間
    /// </summary>
    public DateTime? UpdatedAt { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual ProductPlatform ProductPlatform { get; set; } = null!;
}
