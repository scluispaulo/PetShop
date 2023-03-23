FROM mysql:8.0-oracle

COPY utils/scriptInitialMysql.sql /docker-entrypoint-initdb.d/