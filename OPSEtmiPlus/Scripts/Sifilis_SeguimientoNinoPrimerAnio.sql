CREATE TABLE Sifilis_SeguimientoNinoPrimerAnio (
    IdSeguimientoNinoPrimerAnio INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoEIntervencionNino INT FOREIGN KEY REFERENCES Sifilis_DiagnosticoEIntervencionNino(IdDiagnosticoEIntervencionNino),
    SeRealizoSeguimiento INT,
    IdTipoPruebaNoTreponemica INT,
    FechaResultado DATETIME,
    IdDilucionesPruebaNoTreponemica INT,
    CumpleCriteriosCuracion INT
);
