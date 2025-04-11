CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE TABLE m_affiliate_user (
    id integer NOT NULL,
    api_id character varying(128) NOT NULL,
    affiliate_id character varying(128) NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_affiliate_user_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE m_affiliate_user IS 'アフィリエイトユーザマスタ';
COMMENT ON COLUMN m_affiliate_user.id IS 'アフィリエイトユーザマスタID:【値例】1';
COMMENT ON COLUMN m_affiliate_user.api_id IS 'APIID:【値例】';
COMMENT ON COLUMN m_affiliate_user.affiliate_id IS 'アフィリエイトID:【値例】';
COMMENT ON COLUMN m_affiliate_user.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_affiliate_user.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_affiliate_user.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_affiliate_user.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_affiliate_user.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_affiliate_user.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_affiliate_user.update_program IS '更新プログラム:【値例】System';

CREATE TABLE m_floor (
    id integer NOT NULL,
    dmm_site_name character varying(128) NOT NULL,
    dmm_site_code character varying(128) NOT NULL,
    content jsonb NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_floor_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE m_floor IS 'フロアマスタ';
COMMENT ON COLUMN m_floor.id IS 'フロアマスタID:【値例】1';
COMMENT ON COLUMN m_floor.dmm_site_name IS 'DMM サイト名';
COMMENT ON COLUMN m_floor.dmm_site_code IS 'DMM サイトコード';
COMMENT ON COLUMN m_floor.content IS 'コンテンツ:【値例】';
COMMENT ON COLUMN m_floor.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_floor.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_floor.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_floor.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_floor.update_program IS '更新プログラム:【値例】System';

CREATE TABLE m_floor_detail (
    m_floor_id integer NOT NULL,
    dmm_floor_id integer NOT NULL,
    dmm_service_name character varying(128) NOT NULL,
    dmm_service_code character varying(128) NOT NULL,
    dmm_floor_name character varying(128),
    dmm_floor_code character varying(128) NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_floor_detail_PKC" PRIMARY KEY (m_floor_id, dmm_floor_id, dmm_service_name)
);
COMMENT ON TABLE m_floor_detail IS 'フロア詳細マスタ';
COMMENT ON COLUMN m_floor_detail.m_floor_id IS 'フロアマスタID';
COMMENT ON COLUMN m_floor_detail.dmm_floor_id IS 'DMM フロアID';
COMMENT ON COLUMN m_floor_detail.dmm_service_name IS 'DMM サービス名';
COMMENT ON COLUMN m_floor_detail.dmm_service_code IS 'DMM サービスコード';
COMMENT ON COLUMN m_floor_detail.dmm_floor_name IS 'DMM フロア名';
COMMENT ON COLUMN m_floor_detail.dmm_floor_code IS 'DMM フロアコード';
COMMENT ON COLUMN m_floor_detail.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_floor_detail.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor_detail.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_floor_detail.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_floor_detail.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor_detail.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_floor_detail.update_program IS '更新プログラム:【値例】System';

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
VALUES ('20250411121908_DBMigration_Ver0.0.1', '9.0.4');

COMMIT;

