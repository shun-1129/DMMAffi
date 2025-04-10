START TRANSACTION;
CREATE TABLE t_product (
    id bigserial NOT NULL,
    product_content jsonb NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "t_product_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE t_product IS '商品テーブル';
COMMENT ON COLUMN t_product.id IS '商品ID:【値例】1';
COMMENT ON COLUMN t_product.product_content IS '商品内容:【値例】';
COMMENT ON COLUMN t_product.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN t_product.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN t_product.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN t_product.update_program IS '更新プログラム:【値例】System';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250410141258_DBMigration_Ver0.0.2', '9.0.4');

COMMIT;

