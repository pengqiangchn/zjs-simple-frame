

# zjs-simple-frame

## 介绍
因之前做了个blog框架太过于复杂,很多东西想的太多,以至于需要的实际开发的东西都没有了.  
现在制作一个简单的框架,方便快速开发,后期在开发的过程中,有什么好的优化,就在这里面进行添加完善.

## 说明
### 框架结构
```
|--zjs.WebApi           --API 或 UI
|--zjs.Application      --应用层
    |--DTOs             --DTO
    |--Profiles         --AutoMapper使用
    |--Services         --AppService
|--zjs.Module           --模块、数据层
    |--DataContext      --上下文
    |--Entities         --实体类
    |--Migrations       --EF迁移
    |--Repositories     --仓储,持久化
|--zjs.SeedWork         --简单框架集合
    |--Attributes       --自定义属性
    |--Enum             --自定义枚举
    |--Extensions       --自定义扩展    

```


### 使用到的技术支持
目前使用
* EF Core
* AutoMapper
* 使用自带的IOC容器
   
