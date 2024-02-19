CREATE TABLE Chagas_TratamientoSeguimientoNino (
    IdTratamientoSeguimientoNino INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES Chagas_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    BenznidazolX60Dias INT,
    FechaInicioTratamiento DATETIME,
    NufurtimoxX60Dias INT,
    IdNufurtimoxControlesMedicos INT,
    EsAntigenosTotales6Meses INT,
    EsAntigenosRecombinantes6Meses INT,
    ResultadoPruebaSerologica6Meses NVARCHAR(MAX) DEFAULT '',
    EsAntigenosTotales12Meses INT,
    EsAntigenosRecombinantes12Meses INT,
    ResultadoPruebaSerologica12Meses NVARCHAR(MAX) DEFAULT '',
    EsNinoCuradoChagas INT
);
