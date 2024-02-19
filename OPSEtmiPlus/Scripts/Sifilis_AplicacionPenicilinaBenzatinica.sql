CREATE TABLE Sifilis_AplicacionPenicilinaBenzatinica (
    IdAplicacionPenicilinaBenzatinica INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT,
    IdRetratamientoMaternoGestacional INT,
    IdSeguimientoContactoSexual INT,
    EsRetratamiento INT DEFAULT 0,
    IdDosisPenicilinaBenzatinica INT,
    FechaAplicacionPenicilinaBenzatinica DATETIME,
    EdadGestionalAplicacionPenicilinaBenzatinicaSemanas INT,
    FOREIGN KEY (IdTratamientoMaternoEstadioClinico) REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    FOREIGN KEY (IdRetratamientoMaternoGestacional) REFERENCES Sifilis_RetratamientoMaternoGestacional(IdRetratamientoMaternoGestacional),
    FOREIGN KEY (IdSeguimientoContactoSexual) REFERENCES Sifilis_SeguimientoContactoSexual(IdSeguimientoContactoSexual)
);