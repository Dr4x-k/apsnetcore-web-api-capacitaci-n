# Script para la base de datos

Creación de la base de datos
> [!NOTE]
> El nombre en el ejemplo es capacitacion sin acento, pero el nombre esta a elección del estudiante
```sql
create database capacitacion;
```

Tabla de usuarios
```sql
create table usuario (
  idUsuario serial primary key not null,
  nombres varchar not null,
  usuario varchar not null,
  contrasena varchar not null
);
```

Vista de usuarios
```sql
create or replace view view_usuario as
  select * from usuario;
```

Función para crear un usuario
```sql
create or replace function fun_user_create (
  in p_nombres varchar,
  in p_usuario varchar,
  in p_contrasena varchar
) returns setof view_usuario
language plpgsql as
$function$
declare
  newUserId int;
begin
  insert into usuario (nombres, usuario, contrasena) values (p_nombres, p_usuario, p_contrasena)
    returning idUsuario into newUserId;

  return query select * from view_usuario where idUsuario = newUserId;
end
$function$
```

Función para actualizar un usuario
```sql
create or replace function fun_user_update (
  in p_idUsuario int,
  in p_nombres varchar default null,
  in p_usuario varchar default null,
  in p_contrasena varchar default null
) returns setof view_usuario
language plpgsql as
$function$
begin
  update usuario set
    nombres = coalesce(p_nombres, nombres),
    usuario = coalesce(p_usuario, usuario),
    contrasena = coalesce(p_contrasena, contrasena)
  where idUsuario = p_idUsuario;

  return query select * from view_usuario where idUsuario = p_idUsuario;
end
$function$
```

Función para eliminar un usuario
```sql
create or replace function fun_user_remove (
  in p_idUsuario int
) returns setof view_usuario
language plpgsql as
$function$
begin
  create temp table usuarioEliminado on commit drop
    as select * from view_usuario where idUsuario = p_idUsuario;
  
  delete from usuario where idUsuario = p_idUsuario;

  return query select * from usuarioEliminado;
end
$function$
```
