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

