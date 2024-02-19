CREATE TABLE HB_TratamientoSeguimientoGestante (
    IdTratamientoSeguimiento INT PRIMARY KEY IDENTITY(1,1),
    IdDiagnosticoGestante INT FOREIGN KEY REFERENCES HB_DiagnosticoGestante(IdDiagnosticoGestante),
    RecibioTratamientoAntesEmbarazoActual INT,
    RequiereTratamientoAntesEmbarazoActual INT,
    EdadGestacionalRecibioTratamientoAntesSemana INT,
    RequiereTratamientoDuranteEmbarazoActual INT,
    EdadGestacionalRecibioTratamientoDuranteSemana INT,
    NombreMedicamentoTratamiento NVARCHAR(MAX),
    IdSituacionGestante INT
);