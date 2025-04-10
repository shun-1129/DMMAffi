# DMMAffiDBEntity

## マイグレーション事前準備

### コメントアウト

```
public ApplicationDbContext ( string connectionStrings ) => _connectionStrings = connectionStrings;
```

```
optionsBuilder.UseNpgsql ( _connectionStrings );
```

### コメントアウト解除

```
//optionsBuilder.UseNpgsql ( "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;" );
```

## DB マイグレーション

```
dotnet ef migrations add DBMigration_Ver0.0.1
```

## データベース更新

```
dotnet ef database update
```

## マイグレーション SQL 作成

```
dotnet ef migrations script 0 DBMigration_Ver0.0.1 -o .\MigrationSQL\DB_Migration_Ver.0.0.1.sql
```

```
dotnet ef migrations script DBMigration_Ver0.0.1 DBMigration_Ver0.0.2 -o .\MigrationSQL\DB_Migration_Ver.0.0.2.sql
```
