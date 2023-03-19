create database DB_Mary;
use DB_Mary;

create table producto
(
codigo int identity(1,1)primary key,
nombre varchar(20) not null,
caracteristicas varchar(80) not null,
valor float,
cantidad int
)

insert into producto(nombre,caracteristicas,valor,cantidad)values('esmalte','vinotinto',6000,'20')
insert into producto(nombre,caracteristicas,valor,cantidad)values('labial','rosa',18000,'35')
insert into producto(nombre,caracteristicas,valor,cantidad)values('sombra','dorada',25000,'12')
insert into producto(nombre,caracteristicas,valor,cantidad)values('rubor','piel',12000,'40')
insert into producto(nombre,caracteristicas,valor,cantidad)values('pestañina','negra',15000,'20')

create procedure usp_guardar_producto

@nombre varchar(20),
@caracteristicas varchar(80),
@valor float,
@cantidad int
as
begin
insert into producto (nombre,caracteristicas,valor,cantidad)
values(@nombre,@caracteristicas,@valor,@cantidad)
end

--actualizar
create procedure usp_Actualizar_producto
@codigo int,
@nombre varchar(20),
@caracteristicas varchar(80),
@valor float,
@cantidad int
as
begin
update producto set nombre=@nombre,caracteristicas=@caracteristicas,valor=@valor,cantidad=@cantidad
where codigo=@codigo
end

execute usp_guardar_producto 'delineador','negro',9000,'10'
execute usp_Actualizar_producto  1,'base','piel',12000,'12'

create procedure usp_eliminar_producto
@codigo int
as
begin
delete from producto
where codigo=@codigo 
end

create procedure usp_consultar_producto
@codigo int
as
begin
select * from producto 
where codigo=@codigo
end

create procedure usp_listar_producto
as
begin
select * from producto
end






