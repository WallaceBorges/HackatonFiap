select * from Usuario
select * from Agenda
alter table Agenda add EspecialidadeMedicaId int null
select * from MedicoEspecialidade
select * from EspecialidadeMedica
update usuario set email=wallace.c.borges@hotmail.com where id=1
insert into Agenda(Medico_Id,DataAtendimento)values(1,'2024-10-05 21:40:00')