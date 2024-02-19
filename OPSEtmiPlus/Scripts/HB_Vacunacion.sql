CREATE TABLE HB_Vacunacion (
    IdVacuna INT PRIMARY KEY IDENTITY(1,1),
    IdSeguimientoNinoExpuesto INT FOREIGN KEY REFERENCES HB_SeguimientoNinoExpuesto(IdSeguimientoNinoExpuesto),
    IdDosisVacuna INT,
    FechaAplicacion DATETIME
);