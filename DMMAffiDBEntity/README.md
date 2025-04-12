# DMMAffiDBEntity

## 本 DBEntity の使用方法について

1. DB へのアクセスを行う DBAccessor などのクラスを作成し、Select や Insert、Delete のメソッドを作成してください。
2. Update については、Select にて取得したレコードのデータを直接編集し、SaveChange()を使用すると、直接的に DB を更新するようなコードを記述しなくとも DB は更新されます。<br>
   → 内部で編集したデータを DB に反映したくない場合には、Select 時に AsNoTracking ()を使用することで、DB への反映を自身で実行するように出来ます。
3. Serial 型や BigSerial 型で定義されたカラムは、SaveChange()を使用して DB へ反映せずとも、Insert メソッドを使用すると自動的に採番されて、生成したデータに適応されます。

<br>
<br>
Entityに任せられる部分は、自身でコードを記述せずEntityに任せましょう。<br>
筆者は、Entityに任せることで無駄な不具合を抑えることができると考えます。

## DB マイグレーションについて

### マイグレーション事前準備

###### コメントアウト

```
public ApplicationDbContext ( string connectionStrings ) => _connectionStrings = connectionStrings;
```

```
optionsBuilder.UseNpgsql ( _connectionStrings );
```

###### コメントアウト解除

```
//optionsBuilder.UseNpgsql ( "Host=localhost;Port=5433;Database=dmm_affi;Username=postgres;Password=postgres;" );
```

<br>
事前準備を行わないと、マイグレーションに失敗します。

### DB マイグレーション

```
dotnet ef migrations add DBMigration_Ver0.0.1
```

DBMigration_Ver0.0.1 はマイグレーション名なので、好きな名称で良いです。<br>
筆者は、バージョン管理のために「DBMigration_Ver0.0.1」のような命名をしています。<br>
<br>
2 回目からは、前回との差分を自動的に抽出してマイグレーションしてくれます。

### データベース更新

```
dotnet ef database update
```

実データベースとマイグレーションの差分のみが、データベースに反映されます。

### マイグレーション SQL 作成

```
dotnet ef migrations script 0 DBMigration_Ver0.0.1 -o .\MigrationSQL\DB_Migration_Ver.0.0.1.sql
```

マイグレーション SQL の生成コマンドです。<br>
このコマンドの場合、DB 初期状態から DBMigration_Ver0.0.1 までの差分を SQL にしてくれます。

```
dotnet ef migrations script DBMigration_Ver0.0.1 DBMigration_Ver0.0.2 -o .\MigrationSQL\DB_Migration_Ver.0.0.2.sql
```

「0」を「DBMigration_Ver0.0.1」にし、「DBMigration_Ver0.0.1」を「DBMigration_Ver0.0.2」にすると、その差分を SQL で出力してくれます。<br>
<br>
<br>
「DBMigration_Ver0.0.1」や「DBMigration_Ver0.0.2」は自身で命名したマイグレーション名に置き換えてください。
