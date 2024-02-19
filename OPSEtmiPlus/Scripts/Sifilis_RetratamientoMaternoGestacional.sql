CREATE TABLE Sifilis_RetratamientoMaternoGestacional (
    IdRetratamientoMaternoGestacional INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT FOREIGN KEY REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    RequirioTratamiento INT,
    IdCausaRetratamiento INT,
    AplicaronPenicilinaBenzatinica INT
);

