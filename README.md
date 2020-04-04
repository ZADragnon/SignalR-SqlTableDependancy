# SignalR and SqlTableDependency

Shows how the new SignalR Core works with hubs and sockets, also how it can integrate with SqlTableDependency API.

## Prerequisites and Installation Requirements
+ [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

## Instructions
1. Clone this repository.
2. Compile it.
3. In order to use the SQL Broker,  you must be sure to enable Service Broker for the database. You can use the following command: `ALTER DATABASE SignalRCore SET ENABLE_BROKER`
4. Make sure your SQL user has db owner access rights `EXEC sp_changedbowner 'sa'`
5. Create Products table:
```sql
CREATE TABLE [dbo].[Release]
(
    [Id] [int] NOT NULL,
    [Description] [varchar](max) NULL,
    [Version] [int] NULL,
    [VersionUpdate] [datetime] NULL,
    CONSTRAINT [PK_Release] PRIMARY KEY CLUSTERED 
    (
        [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
```
6. Execute the SignalRCore.Web project.