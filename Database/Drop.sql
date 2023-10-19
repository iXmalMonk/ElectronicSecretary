truncate table es.phone_book restart identity cascade;
truncate table es.task_manager restart identity cascade;

drop table if exists es.phone_book cascade;
drop table if exists es.task_manager cascade;

drop schema if exists es cascade;