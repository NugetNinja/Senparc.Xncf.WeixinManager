﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Senparc.Ncf.Core.Models;
using Senparc.Ncf.Database;
using Senparc.Ncf.Database.MultipleMigrationDbContext;
using Senparc.Ncf.XncfBase.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Senparc.Xncf.WeixinManager.Models
{
    /// <summary>
    /// 用于生成 SQLite 数据库 Migration 信息的类，请勿修改
    /// </summary>
    [MultipleMigrationDbContext(MultipleDatabaseType.Sqlite, typeof(Register))]
    public class WeixinSenparcEntities_Sqlite : WeixinSenparcEntities, IMultipleMigrationDbContext
    {
        public WeixinSenparcEntities_Sqlite(DbContextOptions<WeixinSenparcEntities_Sqlite> dbContextOptions) : base(dbContextOptions)
        {
        }
    }

    /// <summary>
    /// 设计时 DbContext 创建（仅在开发时创建 Code-First 的数据库 Migration 使用，在生产环境不会执行）
    /// <para>1、切换至 Debug 模式</para>
    /// <para>2、运行：PM> add-migration [更新名称] -C WeixinSenparcEntities_SqlServer -o Migrations/Migrations.SqlServer </para>
    /// </summary>
    public class SenparcDbContextFactory_Sqlite : SenparcDesignTimeDbContextFactoryBase<WeixinSenparcEntities_Sqlite, Register>
    {
        protected override Action<IServiceCollection> ServicesAction => services =>
        {
            //指定其他数据库
            services.AddDatabase("Senparc.Ncf.Database.Sqlite", "Senparc.Ncf.Database.Sqlite", "SqliteMemoryDatabaseConfiguration");
        };

        public SenparcDbContextFactory_Sqlite()
            : base(
                 /* Debug模式下项目根目录
                 /* 用于寻找 App_Data 文件夹，从而找到数据库连接字符串配置信息 */
                 Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\"))
        {

        }
    }
}
