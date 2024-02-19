CREATE TABLE HB_ClasificacionNinoExpuesto (
    IdClasificacionNinoExpuesto INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES HB_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    ResultadoAntiHBsAg INT,
    FechaResultadoAntiHBsAg DATETIME,
    ResultadoAntiHBs INT,
    FechaResultadoAntiHBs DATETIME,
    IdCondicionFinal INT,
    IdClasificacionFinal INT
);

