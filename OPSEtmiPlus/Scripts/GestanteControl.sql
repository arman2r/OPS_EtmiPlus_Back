CREATE TABLE GestanteControl (
    IdGestanteControl INT PRIMARY KEY IDENTITY(1,1),
    IdGestante INT FOREIGN KEY REFERENCES Gestante(IdGestante),
    FechaControl DATETIME
);
