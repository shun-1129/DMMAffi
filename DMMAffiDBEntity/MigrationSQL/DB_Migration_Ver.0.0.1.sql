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

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250410135351_DBMigration_Ver0.0.1', '9.0.4');

COMMIT;

