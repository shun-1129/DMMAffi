START TRANSACTION;
CREATE TABLE t_product_detail (
    t_product_id bigint NOT NULL,
    dmm_content_id character varying(128) NOT NULL,
    dmm_product_id character varying(128) NOT NULL,
    title character varying(1024) NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "t_product_detail_PKC" PRIMARY KEY (t_product_id)
);
COMMENT ON TABLE t_product_detail IS '商品詳細テーブル';
COMMENT ON COLUMN t_product_detail.t_product_id IS '商品ID:【値例】1';
COMMENT ON COLUMN t_product_detail.dmm_content_id IS 'DMM 商品ID:【値例】15dss00145';
COMMENT ON COLUMN t_product_detail.dmm_product_id IS 'DMM 品番ID:【値例】15dss00145dl';
COMMENT ON COLUMN t_product_detail.title IS 'タイトル:【値例】タイトル';
COMMENT ON COLUMN t_product_detail.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product_detail.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN t_product_detail.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN t_product_detail.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product_detail.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN t_product_detail.update_program IS '更新プログラム:【値例】System';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250410144030_DBMigration_Ver0.0.3', '9.0.4');

COMMIT;

