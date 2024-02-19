CREATE TABLE Sifilis_TratamientoMaternoEstadioClinico (
    IdTratamientoMaternoEstadioClinico INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoMaterno INT FOREIGN KEY REFERENCES Sifilis_DiagnosticoMaterno(IdDiagnosticoMaterno),
    IdClasificacionEstadioClinico INT,
    AplicaronPenicilinaBenzatinica INT,
    IdResultadoManejoSifilisGestacional INT,
    SeRealizoDesensibilizacionAplicacionPenicilinaBenzatinica INT,
    IdResultadoPrevenirSifilisCongenita INT
);
