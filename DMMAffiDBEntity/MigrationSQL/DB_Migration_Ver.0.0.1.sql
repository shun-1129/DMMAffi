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
    id serial NOT NULL,
    m_site_id integer NOT NULL,
    m_service_id integer NOT NULL,
    floor_id integer NOT NULL,
    floor_name character varying(128) NOT NULL,
    floor_code character varying(128) NOT NULL,
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
COMMENT ON COLUMN m_floor.id IS 'フロアマスタID';
COMMENT ON COLUMN m_floor.m_site_id IS 'サイトマスタID:【値例】1';
COMMENT ON COLUMN m_floor.m_service_id IS 'サービスマスタID:【値例】1';
COMMENT ON COLUMN m_floor.floor_id IS 'フロアID:【値例】1';
COMMENT ON COLUMN m_floor.floor_name IS 'フロア名:【値例】';
COMMENT ON COLUMN m_floor.floor_code IS 'フロアコード:【値例】';
COMMENT ON COLUMN m_floor.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_floor.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_floor.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_floor.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_floor.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_floor.update_program IS '更新プログラム:【値例】System';

CREATE TABLE m_genre (
    id serial NOT NULL,
    m_floor_id integer NOT NULL,
    genre_id integer NOT NULL,
    name character varying(128) NOT NULL,
    ruby character varying(128) NOT NULL,
    list_url character varying(1024) NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_genre_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE m_genre IS 'ジャンルマスタ';
COMMENT ON COLUMN m_genre.id IS 'ジャンルマスタID:【値例】1';
COMMENT ON COLUMN m_genre.m_floor_id IS 'フロアマスタID:【値例】1';
COMMENT ON COLUMN m_genre.genre_id IS 'ジャンルID';
COMMENT ON COLUMN m_genre.name IS 'ジャンル名称';
COMMENT ON COLUMN m_genre.ruby IS 'ジャンル名称(読み仮名)';
COMMENT ON COLUMN m_genre.list_url IS 'リストページURL:アフィリエイトID付き';
COMMENT ON COLUMN m_genre.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_genre.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_genre.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_genre.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_genre.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_genre.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_genre.update_program IS '更新プログラム:【値例】System';

CREATE TABLE m_service (
    id serial NOT NULL,
    service_name character varying(128) NOT NULL,
    service_code character varying(128) NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_service_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE m_service IS 'サービスマスタ';
COMMENT ON COLUMN m_service.id IS 'サービスマスタID:【値例】1';
COMMENT ON COLUMN m_service.service_name IS 'サービス名称:【値例】AKBグループ';
COMMENT ON COLUMN m_service.service_code IS 'サービスコード:【値例】';
COMMENT ON COLUMN m_service.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_service.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_service.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_service.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_service.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_service.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_service.update_program IS '更新プログラム:【値例】System';

CREATE TABLE m_site (
    id serial NOT NULL,
    site_name character varying(128) NOT NULL,
    site_code character varying(128) NOT NULL,
    is_deleted boolean NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "m_site_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE m_site IS 'サイトマスタ';
COMMENT ON COLUMN m_site.id IS 'サイトマスタID:【値例】1';
COMMENT ON COLUMN m_site.site_name IS 'サイト名称';
COMMENT ON COLUMN m_site.site_code IS 'サイトコード';
COMMENT ON COLUMN m_site.is_deleted IS '論理削除:【値例】false：未削除 , true：削除済み';
COMMENT ON COLUMN m_site.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_site.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN m_site.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN m_site.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN m_site.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN m_site.update_program IS '更新プログラム:【値例】System';

CREATE TABLE t_master_management (
    id integer NOT NULL,
    master_change_date timestamp without time zone NOT NULL,
    created_date timestamp without time zone NOT NULL,
    create_user character varying(128),
    create_program character varying(128) NOT NULL,
    update_date timestamp without time zone NOT NULL,
    update_user character varying(128),
    update_program character varying(128) NOT NULL,
    CONSTRAINT "t_mastar_management_PKC" PRIMARY KEY (id)
);
COMMENT ON TABLE t_master_management IS 'マスタ管理テーブル';
COMMENT ON COLUMN t_master_management.id IS 'マスタ管理ID:【値例】1';
COMMENT ON COLUMN t_master_management.master_change_date IS 'マスタ更新日時:【値例】2025/04/01 00:00:00';
COMMENT ON COLUMN t_master_management.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_master_management.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN t_master_management.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN t_master_management.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_master_management.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN t_master_management.update_program IS '更新プログラム:【値例】System';

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
    content_id character varying(128) NOT NULL,
    product_id character varying(128) NOT NULL,
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
COMMENT ON COLUMN t_product_detail.content_id IS '商品ID:【値例】15dss00145';
COMMENT ON COLUMN t_product_detail.product_id IS '品番ID:【値例】15dss00145dl';
COMMENT ON COLUMN t_product_detail.title IS 'タイトル:【値例】タイトル';
COMMENT ON COLUMN t_product_detail.created_date IS '作成日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product_detail.create_user IS '作成者:【値例】System';
COMMENT ON COLUMN t_product_detail.create_program IS '作成プログラム:【値例】System';
COMMENT ON COLUMN t_product_detail.update_date IS '更新日時:【値例】2025/01/01 00:00:00';
COMMENT ON COLUMN t_product_detail.update_user IS '更新者:【値例】System';
COMMENT ON COLUMN t_product_detail.update_program IS '更新プログラム:【値例】System';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250413143421_DBMigration_Ver0.0.1', '9.0.4');

COMMIT;

