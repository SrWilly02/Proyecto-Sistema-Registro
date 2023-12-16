create database DBProject
go

use DBProject
go

create table clientes(
codigo varchar(5),
nombre varchar(50),
correo varchar(50),
telefono int,
edad int,
DNI int
);
go

create proc ListarClientes
as
select * from clientes order by codigo
go

create proc BuscarClientes
@nombre varchar(50)
as
select codigo, nombre, correo, telefono, edad, DNI from clientes where nombre like @nombre + '%'
go

create proc MantenimientoClientes
@codigo varchar(5),
@nombre varchar(50),
@correo varchar(50),
@telefono int,
@edad int,
@DNI int,
@accion varchar(50) output
as
if (@accion = '1')
begin
	declare @codnuevo varchar(5), @codmax varchar(5)
	set @codmax = (select max(codigo) from clientes)
	set @codmax = isnull(@codmax, 'A0000')
	set @codnuevo = 'A' + RIGHT(RIGHT(@codmax,4)+10001,4)
	insert into clientes(codigo, nombre, correo, telefono, edad, DNI)
	values(@codnuevo, @nombre, @correo, @telefono, @edad, @DNI)
	set @accion = 'Se generó el código: ' + @codnuevo
end
else if (@accion = '2')
begin
	update clientes set nombre=@nombre, correo=@correo, telefono=@telefono, edad=@edad, DNI=@DNI
	set @accion = 'Se modificó el código: ' + @codigo
end
else if (@accion = '3')
begin
	delete from clientes where codigo=@codigo
	set @accion = 'Se borró el código: ' + @codigo
end
go