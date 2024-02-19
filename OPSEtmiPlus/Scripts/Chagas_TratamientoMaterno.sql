CREATE TABLE Chagas_TratamientoMaterno (
    IdTratamientoMaterno INT PRIMARY KEY IDENTITY(1,1),
    IdAlgoritmo INT FOREIGN KEY REFERENCES Chagas_Algoritmo(IdAlgoritmo),
    BenznidazolX60Dias INT,
    FechaInicioTratamiento DATETIME,
    NufurtimoxX60Dias INT,
    IdNufurtimoxControlesMedicos INT,
    FinalizacionLactanciaMaterna INT,
    MetodoAnticonceptivoUtilizadoDuranteTratamiento NVARCHAR(MAX) DEFAULT ''
);