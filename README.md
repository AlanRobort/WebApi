##README
##刚开始学习webapi，只是学会了最基础的json的几个传输方式
##asp.net core 2.0 web api最基本的CRUD操作
#IoC和Dependency Injection （控制反转和依赖注入）

#日志服务
我用的是NLog(nuget安装nlog.extensions.logging)
一般情况下Nlog会在根目录中找NLog.config的配置文件
Nlog.conf可以自己配置
详细的配置可以看Nlog的官网，或者他的github：https://github.com/NLog/NLog/wiki/Tutorial
使用时，需要在startup中注册到ILoggerFactory，然后在配置
具体实现看代码
当运行Api后会在“WebApi\bin\Debug\netcoreapp2.2\logs”中有一个后缀为.log的文件记录你当前的服务运行状态

#依赖注入的三种生命周期
AddTransient，AddScoped和AddSingleton
AddTransient的services 是每次请求（不是指Http request）都会创建一次新的实例
Addscoped 的services是每次http请求都会创建一个实例
AddSingleton 的services是第一次请求后就会创建一个实例，以后也只是这个实例，或者说代码运行后创建一个唯一实例。

#EF 配置
EF Core 支持两种模式
CodeFirst :大概的理解是先在项目中创建Model类，然后生成数据库
Batabase First：先在数据库中建立表，然后生成C#Model
我用的是CodeFirst模式

首先我会先创建一个Entities的文件夹，建立Products

EFCore使用的是DbContext和数据打交道，他代表着和数据库之间的一个session，用来查询和保存我们的Entities.
创建后缀为DBContext的类，该项目中为Entities/ProductContext，用来访问数据库.
需要在startup中注册该服务(services.AddDbContext<ProductContext>();)这样我们才能使用它
数据库的连接在appsettings.json文件中
在下方添加
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  //数据库连接
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=Backstage;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
  "AllowedHosts": "*"
}

必须在"ConnectionStrings"下定义数据库连接，其中"DefaultConnection"名字是可以随便定义，而"ConnectionStrings"是不可以，因为在startup文件中ConfigureServices方法里面 


services.AddDbContext<ProductContext>(
                options => { options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")); }
            );
这段代码是与数据库连接上下文的，UseSqlServer方法中Configuration.GetConnectonString，GetConnectonString
摘要里写明了 Shorthand for GetSection("ConnectionStrings")[name].
在查找appsettings.json文件中的数据库连接时，它会找ConnectionStrings下的[DefaultConnection]

在Product类中有三个字段分别是Id,Name,Price
在生成数据库之前必须要给这三个字段进行限制，比如Id设置为主键，Name长度限制，Price的精度限制。

Product这个entity中的Id，根据约定（Id或者ProductId）会被视为映射表的主键，并且该主键是自增的。

如果不使用Id或者ProductId这两个名字作为主键的话，我们可以通过两种方式把该属性设置成为主键：Data Annotation注解和Fluet Api。我学的是Fluet Api.FluetApi官方文档：https://docs.microsoft.com/en-us/ef/core/modeling/

在项目中创建一个ProductConfiguration的类进行字段属性的限制。（代码自己看吧）

然后在ProductContext类中将ProductConfiguration中写的配置移动过来

protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

然后在程序包管理器控制台中输入Add-Migration [定义迁移名(可以自己定义)] :

Add-Migration ProductInfoInitalMigration

生成成功后会多出一个Migrations的文件夹

然后执行Update-database

就会看到数据库ProductDb


#EF CURD

















