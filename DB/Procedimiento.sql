USE [CRUD_N_CAPAS]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[Mostrar]

SELECT	'Return Value' = @return_value

GO
create proc  insertar
--variables
@ID int,
@Nombre varchar(250),
@Apellido varchar (250),
@Sexo varchar(12)
As

Insert Into PERSONAS values (@ID,@Nombre,@Apellido,@Sexo)
go

