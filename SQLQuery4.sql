select * from Usuario
select * from Agenda
alter table Agenda add EspecialidadeMedicaId int null
select * from MedicoEspecialidade
select * from EspecialidadeMedica
update Agenda set Especialidade_Id=1 where DataAtendimento<'2024-10-14'
insert into Agenda(Medico_Id,DataAtendimento)values(1,'2024-10-05 21:40:00')