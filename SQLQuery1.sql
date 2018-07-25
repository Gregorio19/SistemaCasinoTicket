select * from casino_valesusados where iduser = 270 and turnoafectado = 1;

delete casino_valesusados

select * from casino_histvalesusados;

select * from USERINFO;

select * from ACTimeZones;

select distinct usr.name, dpto.DEPTNAME
from USERINFO usr,
	 DEPARTMENTS dpto
where usr.userid = 270
and usr.DEFAULTDEPTID = dpto.DEPTID;


select * from USERINFO where ssn = '10011071-7';

defeaultdeptid;

ALTER TABLE casino_valesusados  
DROP CONSTRAINT PK_casino_valesusados;

select * from DEPARTMENTS;

select * from casino order by fecha desc;


select distinct CONVERT(varchar(100),max(fecha),112), 
			    CONVERT(TIME(0),max(fecha)), 
				CONVERT(varchar(100),max(fecha),120),
				CONVERT(varchar(100),max(fecha),110)
from casino
where sn not in ('MANUAL')

select * from casino where CONVERT(varchar(100),fecha,120) = '2018-05-04 11:45:44';

--Obtiene dia de la semana
select DATEPART(dw, (select distinct CONVERT(varchar(100),max(fecha),112) from casino));
select DATEPART(dw, (CONVERT(varchar(100),'2018-05-05 00:03:45',112)));

select * from ACTimeZones;

select cs.iduser, cs.idservicio, CONVERT(TIME(0),fristart), CONVERT(TIME(0),friend)
from casino_servicioasig cs,
	 ACTimeZones act
where cs.iduser = 270
and cs.idservicio = act.TimeZoneID;

select CONVERT(TIME(0),max(fristart)), CONVERT(TIME(0),max(friend)) from ACTimeZones where TimeZoneID = 2;

select distinct CONVERT(varchar(100),max(fecha),112) from casino;

select distinct CONVERT(TIME(0),max(fecha)) from casino;

delete casino
where CONVERT(varchar(100),fecha,112) > '20170619';

insert into casino(iduser, fecha, servicio, sn) values (270, GETDATE(), 1,2233354);

insert into casino(iduser, fecha, sn) values (270, GETDATE(),2233354);

select * from casino order by fecha desc;


select distinct act.TimeZoneID, CONVERT(TIME(0),SatStart), CONVERT(TIME(0),SatEnd)
from casino_servicioasig cs,
     ACTimeZones act
where cs.iduser = 270
and cs.idservicio = act.TimeZoneID

select * from casino_servicioasig where iduser = 270

delete casino_servicioasig where iduser = 270 and idservicio in (3, 4);


USE [TotalPack]
GO

INSERT INTO [dbo].[ASISTENCIA_RELOJ_IMP]
           ([ipreloj]
           ,[impresora])
     VALUES
           ('192.168.0.202',
           '192.168.0.116');

select * from Machines;

select * from Casino where servicio = null;

update casino
set servicio 1
where iduser = 270
and fecha = xx
and sn = xx

select distinct ari.impresora
from Machines m,
	 ASISTENCIA_RELOJ_IMP ari
where m.sn = '6641172300640'
and m.ip = ari.ipreloj;