CREATE TABLE Sifilis_SeguimientoContactoSexual (
    IdSeguimientoContactoSexual INT PRIMARY KEY IDENTITY(1,1),
    IdGestanteControl INT FOREIGN KEY REFERENCES GestanteControl(IdGestanteControl),
    SeNotifico INT,
    SeRealizoTratamiento INT,
    SeAplicoPenicilinaBenzatinica INT,
    IdDosisPenicilinaBenzatinica INT,
    FechaAplicacionPenicilinaBenzatinica DATETIME,
    NombreMedicamentoDiferentePenicilinaBenzatinica NVARCHAR(MAX)
);
