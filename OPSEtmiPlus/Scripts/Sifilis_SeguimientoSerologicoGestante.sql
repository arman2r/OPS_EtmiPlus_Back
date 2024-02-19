CREATE TABLE Sifilis_SeguimientoSerologicoGestante (
    IdSeguimientoSerologicoGestante INT PRIMARY KEY IDENTITY(1,1),
    IdTratamientoMaternoEstadioClinico INT FOREIGN KEY REFERENCES Sifilis_TratamientoMaternoEstadioClinico(IdTratamientoMaternoEstadioClinico),
    IdTipoPruebaNoTreponemicaDuranteGestacion INT,
    FechaResultadoPruebaNoTreponemica DATETIME,
    IdDilucionesPruebaNoTreponemicaEsReactiva INT,
    EdadGestacionalRealizacionPruebaNoTreponemica INT
);
