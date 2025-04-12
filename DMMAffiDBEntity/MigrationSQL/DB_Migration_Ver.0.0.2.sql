START TRANSACTION;
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

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250412092152_DBMigration_Ver0.0.2', '9.0.4');

COMMIT;

