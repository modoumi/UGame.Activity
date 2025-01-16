# 营销活动项目

## 营销活动列表

1. [x]  Tasks - 个人任务
2. [x]  Rebate - 返点返水
3. [x]  Redpack - 红包
4. [x]  TreasureBox - 宝箱


## 结构约定

### 方案一

> 简约项目，功能简单，独立

````
-- Rebate （解决方案文件夹及目录结构文件夹）
 | -- SActivity.Rebate.JOB
 | -- SActivity.Rebate.API
    | -- Annotations （注解：需则加）
    | -- Judgments   （断言-底层支持：需则加）
    | -- Repositories (数据持久)
    | -- Services     (业务逻辑)
    | -- Common       (公共方法)
    | -- Consumers    (消费端)
    | -- Events      （包含 IntegrationEvents）
    | -- Models       (request、response、枚举、常量、结构等定义)
       | -- Ipos
       | -- Dtos
       | -- Enums
          | -- RebateEnums.cs
    | -- Caching     （缓存）
       | -- DCache
       | -- DbCache
    | -- Extensions   (扩展)
    | -- RebateController.cs
    | -- RebateStartup.cs

  
````


## 结构简介

### Domain（领域）

> src/Domain 或 domain/ 目录通常包含与领域模型相关的核心业务逻辑和领域实体的定义。

- `Domain/Entities`: 包含领域实体类，如 `User.cs`, `Order.cs` 等。
- `Domain/ValueObjects`: 包含领域值对象，如 `Email.cs`, `Address.cs` 等。
- `Domain/Aggregates`: 包含聚合根的定义和实现，如 `OrderAggregate.cs`。
- `Domain/Repositories`: 包含领域仓库接口，如 `IUserRepository.cs`, `IOrderRepository.cs` 等。
- `Domain/Services`: 包含领域服务接口和实现，如 `IUserService.cs`, `UserServiceImpl.cs` 等。

### Application（应用层）

> src/Application 或 application/ 目录通常包含应用服务、应用层服务和用例的实现，负责协调领域对象和处理应用层逻辑。

- `Application/UseCases`: 包含用例类，如 `RegisterUserUseCase.cs`, `PlaceOrderUseCase.cs` 等。
- `Application/DTOs`: 包含数据传输对象，如 `UserDTO.cs`, `OrderDTO.cs` 等。
- `Application/Services`: 包含应用服务类，如 `UserService.cs`, `OrderService.cs` 等。

### Infrastructure（基础设施）

> src/Infrastructure 或 infrastructure/ 目录通常包含与基础设施相关的代码，如数据库访问、外部服务调用、消息队列等。

- `Infrastructure/Persistence`: 包含领域仓库的实际实现，如 `UserRepository.cs`, `OrderRepository.cs` 等。
- `Infrastructure/ExternalServices`: 包含与外部服务的交互，如 `PaymentGateway.cs`, `PayPalPaymentGateway.cs` 等。
- `Infrastructure/MessageQueue`: 包含消息队列的相关代码，如 `QueueService.cs`, `MessageHandler.cs` 等。
- `Infrastructure/Logging`: 包含日志记录相关的代码，如 `Logger.cs`。
- `Infrastructure/Security`: 包含安全性相关的代码，如 `AuthenticationService.cs`, `AuthorizationService.cs` 等。

### Presentation（表示层）

> src/Presentation 或 presentation/ 目录包含与用户界面或外部接口（如API）相关的代码。

- `Presentation/WebAPI`: 包含Web API的控制器和路由配置，如 `UserController.cs`, `OrderController.cs` 等。
- `Presentation/WebUI`: 包含Web应用程序的视图和前端代码，如 `views/`, `assets/` 等。
- `Presentation/CLI`: 包含命令行界面相关的代码，如 `CommandRunner.cs`, `Commands/` 等。

### Cross-cutting Concerns（横切关注点）

> src/Shared 或 shared/ 目录通常包含横切关注点的代码，如安全性、日志、缓存、验证等。

- `Shared/Security`: 包含通用的安全性组件，如 `SecurityGuard.cs`, `SecurityPolicy.cs` 等。
- `Shared/Logging`: 包含通用的日志记录组件，如 `LogWriter.cs`, `LogFormatter.cs` 等。
- `Shared/Caching`: 包含通用的缓存组件，如 `CacheManager.cs`, `CacheAdapter.cs` 等。
- `Shared/Validation`: 包含通用的数据验证组件，如 `Validator.cs`, `ValidationRules.cs` 等。

### Tests（测试）

> tests/ 目录包含单元测试、集成测试和端到端测试，以确保系统的正确性。通常与各个部分的目录结构保持一致，如 tests/Domain、tests/Application、tests/Infrastructure 等。

- `Tests/Domain`: 包含领域层的单元测试，如 `UserTest.cs`, `OrderTest.cs` 等。
- `Tests/Application`: 包含应用层的单元测试，如 `RegisterUserUseCaseTest.cs`, `PlaceOrderUseCaseTest.cs` 等。
- `Tests/Infrastructure`: 包含基础设施层的单元测试，如 `UserRepositoryTest.cs`, `PaymentGatewayTest.cs` 等。
- `Tests/Presentation`: 包含表示层的测试，如 `UserControllerTest.cs`, `OrderControllerTest.cs` 等。
