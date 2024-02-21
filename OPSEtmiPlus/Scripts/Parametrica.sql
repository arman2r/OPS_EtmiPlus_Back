CREATE TABLE Parametrica (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(MAX) NOT NULL,
	Valor NVARCHAR(MAX) NOT NULL,
    Descripcion NVARCHAR(MAX)
);

--NACIONALIDAD
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('NACIONALIDAD', 'Colombiana', 'Ciudadano perteneciente a Colombia.'),
    ('NACIONALIDAD', 'Extranjera', 'Ciudadano no perteneciente a Colombia.');

--TIPO_DOCUMENTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_DOCUMENTO', 'TI', 'TI: Tarjeta de identidad'),
    ('TIPO_DOCUMENTO', 'MS', 'MS: Menor sin identificaci�n'),
    ('TIPO_DOCUMENTO', 'AS', 'AS: Adulto sin identificaci�n'),
    ('TIPO_DOCUMENTO', 'CC', 'CC: C�dula ciudadan�a'),
    ('TIPO_DOCUMENTO', 'PA', 'PA: Pasaporte'),
    ('TIPO_DOCUMENTO', 'SV', 'SV: Salvoconducto'),
    ('TIPO_DOCUMENTO', 'PE', 'PE: Permiso Especial de Permanencia'),
    ('TIPO_DOCUMENTO', 'CE', 'CE: C�dula de extranjer�a');

-- REGIMEN_SALUD
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('REGIMEN_SALUD', 'Excepci�n', 'Excepci�n: Descripci�n de Excepci�n'),
    ('REGIMEN_SALUD', 'Contributivo', 'Contributivo: Descripci�n de Contributivo'),
    ('REGIMEN_SALUD', 'Subsidiado', 'Subsidiado: Descripci�n de Subsidiado'),
    ('REGIMEN_SALUD', 'Especial', 'Especial: Descripci�n de Especial'),
    ('REGIMEN_SALUD', 'No asegurado', 'No asegurado: Descripci�n de No asegurado');

--PERTENENCIA_ETNICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PERTENENCIA_ETNICA', 'Palenquera', 'Palenquera: Descripci�n de Palenquera'),
    ('PERTENENCIA_ETNICA', 'Afrocolombiana', 'Afrocolombiana: Descripci�n de Afrocolombiana'),
    ('PERTENENCIA_ETNICA', 'Ind�gena', 'Ind�gena: Descripci�n de Ind�gena'),
    ('PERTENENCIA_ETNICA', 'Rom', 'Rom: Descripci�n de Rom'),
    ('PERTENENCIA_ETNICA', 'Otro', 'Otro: Descripci�n de Otro'),
    ('PERTENENCIA_ETNICA', 'Raizal (del Archipi�lago de San Andr�s y Providencia)', 'Raizal: Descripci�n de Raizal (del Archipi�lago de San Andr�s y Providencia)');

--GRUPO_POBLACIONAL
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GRUPO_POBLACIONAL', 'Migrante', 'Migrante: Descripci�n de Migrante'),
    ('GRUPO_POBLACIONAL', 'Desplazada', 'Desplazada: Descripci�n de Desplazada'),
    ('GRUPO_POBLACIONAL', 'Carcelaria', 'Carcelaria: Descripci�n de Carcelaria'),
    ('GRUPO_POBLACIONAL', 'Otros grupos', 'Otros grupos: Descripci�n de Otros grupos'),
    ('GRUPO_POBLACIONAL', 'Habitante de calle', 'Habitante de calle: Descripci�n de Habitante de calle'),
    ('GRUPO_POBLACIONAL', 'Discapacitada', 'Discapacitada: Descripci�n de Discapacitada'),
    ('GRUPO_POBLACIONAL', 'Centro psiqui�trico', 'Centro psiqui�trico: Descripci�n de Centro psiqui�trico'),
    ('GRUPO_POBLACIONAL', 'V�ctima de violencia armada', 'V�ctima de violencia armada: Descripci�n de V�ctima de violencia armada');

--AREA_OCURRENCIA_CASO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('AREA_OCURRENCIA_CASO', 'Cabecera municipal', 'Cabecera municipal: Descripci�n de Cabecera municipal'),
    ('AREA_OCURRENCIA_CASO', 'Centro poblado', 'Centro poblado: Descripci�n de Centro poblado'),
    ('AREA_OCURRENCIA_CASO', 'Rural disperso', 'Rural disperso: Descripci�n de Rural disperso');

--MOMENTO_DIAGNOSTICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MOMENTO_DIAGNOSTICO', 'Antes del embarazo actual', 'Antes del embarazo actual: Descripci�n de Antes del embarazo actual'),
    ('MOMENTO_DIAGNOSTICO', 'Durante el embarazo actual', 'Durante el embarazo actual: Descripci�n de Durante el embarazo actual'),
    ('MOMENTO_DIAGNOSTICO', 'Posterior al parto', 'Posterior al parto: Descripci�n de Posterior al parto');

--PRUEBA_DIAGNOSTICO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PRUEBA_DIAGNOSTICO_VIH', 'Carga viral', 'Carga viral: Descripci�n de Carga viral'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Western Blot', 'Western Blot: Descripci�n de Western Blot'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Prueba r�pida', 'Prueba r�pida: Descripci�n de Prueba r�pida'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'ELISA', 'ELISA: Descripci�n de ELISA'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Quimioluminiscencia', 'Quimioluminiscencia: Descripci�n de Quimioluminiscencia');

--TIPO_ALIMENTACION_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'F�rmula l�ctea desde el nacimiento - GPC', 'F�rmula l�ctea desde el nacimiento - GPC: Descripci�n de F�rmula l�ctea desde el nacimiento - GPC'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Lactancia materna exclusiva', 'Lactancia materna exclusiva: Descripci�n de Lactancia materna exclusiva'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentaci�n mixta: lactancia materna + f�rmula l�ctea', 'Alimentaci�n mixta: lactancia materna + f�rmula l�ctea: Descripci�n de Alimentaci�n mixta: lactancia materna + f�rmula l�ctea'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentaci�n parental', 'Alimentaci�n parental: Descripci�n de Alimentaci�n parental'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentaci�n parental + f�rmula l�ctea', 'Alimentaci�n parental + f�rmula l�ctea: Descripci�n de Alimentaci�n parental + f�rmula l�ctea');

--RESULTADO_PRUEBA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA', 'Positivo', 'Positivo: Descripci�n de Positivo'),
    ('RESULTADO_PRUEBA', 'Reactivo', 'Reactivo: Descripci�n de Reactivo');

--GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'La gestante ven�a recibiendo TAR para VIH antes de iniciar el embarazo actual', 'La gestante ven�a recibiendo TAR para VIH antes de iniciar el embarazo actual: Descripci�n de La gestante ven�a recibiendo TAR para VIH antes de iniciar el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'Si la respuesta es NO �la gestante inicio TAR durante el embarazo actual', 'Si la respuesta es NO �la gestante inicio TAR durante el embarazo actual: Descripci�n de Si la respuesta es NO �la gestante inicio TAR durante el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato', 'Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato: Descripci�n de Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato');

--GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO', 'Recibi� TAR para VIH durante el embarazo actual', 'Recibi� TAR para VIH durante el embarazo actual: Descripci�n de Recibi� TAR para VIH durante el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO', 'Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato', 'Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato: Descripci�n de Si la respuesta es SI, a partir de que semana gestacional lo recibi�. Registre el dato');

--MEDICAMENTOS_ARV_SUMINISTRADOR
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Lamivudina', 'Lamivudina: Descripci�n de Lamivudina'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Abacavir', 'Abacavir: Descripci�n de Abacavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Emtricitabina', 'Emtricitabina: Descripci�n de Emtricitabina'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Tenofovir disoproxil Fumarato', 'Tenofovir disoproxil Fumarato: Descripci�n de Tenofovir disoproxil Fumarato'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Efavirez', 'Efavirez: Descripci�n de Efavirez'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Atazanavir', 'Atazanavir: Descripci�n de Atazanavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Darunavir', 'Darunavir: Descripci�n de Darunavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Lopinavir', 'Lopinavir: Descripci�n de Lopinavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Ritonavir', 'Ritonavir: Descripci�n de Ritonavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Raltegravir', 'Raltegravir: Descripci�n de Raltegravir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Dolutegravir', 'Dolutegravir: Descripci�n de Dolutegravir');

--MEDICAMENTOS_ARV
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MEDICAMENTOS_ARV', 'Lamivudina', 'Lamivudina: Descripci�n de Lamivudina'),
    ('MEDICAMENTOS_ARV', 'Abacavir', 'Abacavir: Descripci�n de Abacavir'),
    ('MEDICAMENTOS_ARV', 'Emtricitabina', 'Emtricitabina: Descripci�n de Emtricitabina'),
    ('MEDICAMENTOS_ARV', 'Tenofovir disoproxil Fumarato', 'Tenofovir disoproxil Fumarato: Descripci�n de Tenofovir disoproxil Fumarato'),
    ('MEDICAMENTOS_ARV', 'Efavirez', 'Efavirez: Descripci�n de Efavirez'),
    ('MEDICAMENTOS_ARV', 'Atazanavir', 'Atazanavir: Descripci�n de Atazanavir'),
    ('MEDICAMENTOS_ARV', 'Darunavir', 'Darunavir: Descripci�n de Darunavir'),
    ('MEDICAMENTOS_ARV', 'Lopinavir', 'Lopinavir: Descripci�n de Lopinavir'),
    ('MEDICAMENTOS_ARV', 'Ritonavir', 'Ritonavir: Descripci�n de Ritonavir'),
    ('MEDICAMENTOS_ARV', 'Raltegravir', 'Raltegravir: Descripci�n de Raltegravir'),
    ('MEDICAMENTOS_ARV', 'Dolutegravir', 'Dolutegravir: Descripci�n de Dolutegravir');

--SITUACION_GESTANTE
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SITUACION_GESTANTE', 'Aborto', 'Aborto: Descripci�n de Aborto'),
    ('SITUACION_GESTANTE', 'IVE', 'IVE: Descripci�n de IVE'),
    ('SITUACION_GESTANTE', 'Mortalidad Materna', 'Mortalidad Materna: Descripci�n de Mortalidad Materna'),
    ('SITUACION_GESTANTE', 'Parto', 'Parto: Descripci�n de Parto');

--ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO', 'SI', 'SI: Descripci�n de SI'),
    ('ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO', 'NO', 'NO: Descripci�n de NO');

--ESQUEMA_ARV_INTRAPARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ESQUEMA_ARV_INTRAPARTO', 'Zidovudina', 'Zidovudina: Descripci�n de Zidovudina'),
    ('ESQUEMA_ARV_INTRAPARTO', 'Nevirapina', 'Nevirapina: Descripci�n de Nevirapina');


--CONDICION_RECIEN_NACIDO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CONDICION_RECIEN_NACIDO', 'Vivo', 'Vivo: Descripci�n de Vivo'),
    ('CONDICION_RECIEN_NACIDO', 'Mortinato', 'Mortinato: Descripci�n de Mortinato');

--NUMERO_PRODUCTOS_NACIMIENTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('NUMERO_PRODUCTOS_NACIMIENTO', '�nico', '�nico: Descripci�n de �nico'),
    ('NUMERO_PRODUCTOS_NACIMIENTO', 'M�ltiple (2 o m�s reci�n nacidos)', 'M�ltiple (2 o m�s reci�n nacidos): Descripci�n de M�ltiple (2 o m�s reci�n nacidos)');

--SEXO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SEXO', 'Hombre', 'Hombre: Descripci�n de Hombre'),
    ('SEXO', 'Mujer', 'Mujer: Descripci�n de Mujer'),
    ('SEXO', 'Intersexual', 'Intersexual: Descripci�n de Intersexual');

--TIPO_PARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PARTO', 'Ces�rea', 'Ces�rea: Descripci�n de Ces�rea'),
    ('TIPO_PARTO', 'Vaginal', 'Vaginal: Descripci�n de Vaginal');

--TIPO_REGIMEN_SALUD
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_REGIMEN_SALUD', 'Excepci�n', 'Excepci�n: Descripci�n de Excepci�n'),
    ('TIPO_REGIMEN_SALUD', 'Contributivo', 'Contributivo: Descripci�n de Contributivo'),
    ('TIPO_REGIMEN_SALUD', 'Subsidiado', 'Subsidiado: Descripci�n de Subsidiado'),
    ('TIPO_REGIMEN_SALUD', 'Especial', 'Especial: Descripci�n de Especial'),
    ('TIPO_REGIMEN_SALUD', 'No asegurado', 'No asegurado: Descripci�n de No asegurado');

--TIPO_DOCUMENTO_NINO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_DOCUMENTO_NINO', 'RC', 'RC: Registro Civil'),
    ('TIPO_DOCUMENTO_NINO', 'CNV', 'CNV: Certificado de nacido vivo'),
    ('TIPO_DOCUMENTO_NINO', 'MS', 'MS: Menor sin identificaci�n');

--CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO', 'Bajo riesgo', 'Bajo riesgo: Descripci�n de Bajo riesgo'),
    ('CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO', 'Alto riesgo', 'Alto riesgo: Descripci�n de Alto riesgo');

--PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Zidovudina por 4 semanas', 'Zidovudina por 4 semanas: Descripci�n de Zidovudina por 4 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Zidovudina por 6 semanas', 'Zidovudina por 6 semanas: Descripci�n de Zidovudina por 6 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Lamivudina por 6 semanas', 'Lamivudina por 6 semanas: Descripci�n de Lamivudina por 6 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Nevirapina por 4 semanas', 'Nevirapina por 4 semanas: Descripci�n de Nevirapina por 4 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Raltegravir por 6 semanas', 'Raltegravir por 6 semanas: Descripci�n de Raltegravir por 6 semanas');

--OTRAS_PRUEBAS_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Prueba r�pida', 'Prueba r�pida: Descripci�n de Prueba r�pida'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'ELISA', 'ELISA: Descripci�n de ELISA'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Quimioluminiscencia', 'Quimioluminiscencia: Descripci�n de Quimioluminiscencia'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Western Blot', 'Western Blot: Descripci�n de Western Blot');

--RESULTADO_NINO_EXPUESTO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Reactivo', 'Reactivo: Descripci�n de Reactivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'No reactivo', 'No reactivo: Descripci�n de No reactivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Positivo', 'Positivo: Descripci�n de Positivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Negativo', 'Negativo: Descripci�n de Negativo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Indeterminado', 'Indeterminado: Descripci�n de Indeterminado');

--PARACLINICO_REALIZADO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PARACLINICO_REALIZADO', 'Carga viral', 'Carga viral: Descripci�n de Carga viral'),
    ('PARACLINICO_REALIZADO', 'Conteo de linfocitos T CD4', 'Conteo de linfocitos T CD4: Descripci�n de Conteo de linfocitos T CD4');    

--ALIMENTACION_NINO_EXPUESTO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'F�rmula l�ctea desde el nacimiento', 'F�rmula l�ctea desde el nacimiento: Descripci�n de F�rmula l�ctea desde el nacimiento'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Lactancia materna exclusiva', 'Lactancia materna exclusiva: Descripci�n de Lactancia materna exclusiva'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentaci�n mixta: lactancia materna + f�rmula l�ctea', 'Alimentaci�n mixta: lactancia materna + f�rmula l�ctea: Descripci�n de Alimentaci�n mixta: lactancia materna + f�rmula l�ctea'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentaci�n parenteral', 'Alimentaci�n parenteral: Descripci�n de Alimentaci�n parenteral'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentaci�n parenteral + f�rmula l�ctea', 'Alimentaci�n parenteral + f�rmula l�ctea: Descripci�n de Alimentaci�n parenteral + f�rmula l�ctea');

--SITUACION_NINO_EXPUESTO_REFERENCIA_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Infecci�n por VIH confirmada', 'Infecci�n por VIH confirmada: Descripci�n de Infecci�n por VIH confirmada'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Infecci�n por VIH descartada', 'Infecci�n por VIH descartada: Descripci�n de Infecci�n por VIH descartada'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Falleci� sin clasificaci�n', 'Falleci� sin clasificaci�n: Descripci�n de Falleci� sin clasificaci�n'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Sin clasificaci�n', 'Sin clasificaci�n: Descripci�n de Sin clasificaci�n');

--TIEMPO_APLICACION_VACUNA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIEMPO_APLICACION_VACUNA_HB', 'En las primeras 12 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB en las primeras 12 horas'),
    ('TIEMPO_APLICACION_VACUNA_HB', 'Mayor a 12 y hasta 24 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB mayor a 12 y hasta 24 horas'),
    ('TIEMPO_APLICACION_VACUNA_HB', 'Despu�s de 24 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB despu�s de 24 horas');

--APLICACION_VACUNA_CONTRA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('APLICACION_VACUNA_CONTRA_HB', 'Dosis al reci�n nacido', 'Valor relacionado con la dosis al reci�n nacido'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Primera dosis', 'Valor relacionado con la primera dosis'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Segunda dosis', 'Valor relacionado con la segunda dosis'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Tercera dosis', 'Valor relacionado con la tercera dosis');

--TIEMPO_APLICACION_INMUNOGLOBULINA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'En las primeras 12 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB en las primeras 12 horas'),
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'Mayor a 12 y hasta 24 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB mayor a 12 y hasta 24 horas'),
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'Despu�s de 24 horas', 'Valor relacionado con el tiempo de aplicaci�n de la vacuna HB despu�s de 24 horas');

--CONDICION_FINAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CONDICION_FINAL_NINO_EXPUESTO', 'Vivo', 'Valor relacionado con la condici�n final de un ni�o expuesto que est� vivo'),
    ('CONDICION_FINAL_NINO_EXPUESTO', 'Muerto', 'Valor relacionado con la condici�n final de un ni�o expuesto que est� muerto');

--CLASIFICACION_FINAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Infecci�n por HB confirmada', 'Valor relacionado con la clasificaci�n final de un ni�o expuesto con infecci�n por HB confirmada'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Infecci�n por HB descartada', 'Valor relacionado con la clasificaci�n final de un ni�o expuesto con infecci�n por HB descartada'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Falleci� sin clasificaci�n', 'Valor relacionado con la clasificaci�n final de un ni�o expuesto que falleci� sin clasificaci�n'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Sin clasificaci�n', 'Valor relacionado con la clasificaci�n final de un ni�o expuesto sin clasificaci�n');

--TIPO_PRUEBA_TRIPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba R�pida', 'Descripci�n para Prueba R�pida'),
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba TPHA', 'Descripci�n para Prueba TPHA'),
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba TPPA', 'Descripci�n para Prueba TPPA');

--RESULTADO_PRUEBA_TREPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA_TREPONEMICA', 'Reactiva', 'Descripci�n para Reactiva'),
    ('RESULTADO_PRUEBA_TREPONEMICA', 'No reactiva', 'Descripci�n para No reactiva');

--TIPO_PRUEBA_NO_TRIPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PRUEBA_NO_TREPONEMICA', 'VDRL', 'Descripci�n para VDRL'),
    ('TIPO_PRUEBA_NO_TREPONEMICA', 'RPR', 'Descripci�n para RPR');

--RESULTADO_PRUEBA_NO_TREPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA_NO_TREPONEMICA', 'Reactiva', 'Descripci�n para Reactiva'),
    ('RESULTADO_PRUEBA_NO_TREPONEMICA', 'No reactiva', 'Descripci�n para No reactiva');

--DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '1', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 1'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '2', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 2'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '4', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 4'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '8', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 8'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '16', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 16'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '32', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 32'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '64', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 64'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '128', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 128'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '256', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 256'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '512', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 512'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '1024', 'Descripci�n para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 1024');
    
--CLASIFICACION_ESTADIO_CLINICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_ESTADIO_CLINICO', 'Temprana', 'Descripci�n para Temprana'),
    ('CLASIFICACION_ESTADIO_CLINICO', 'Tard�a', 'Descripci�n para Tard�a'),
    ('CLASIFICACION_ESTADIO_CLINICO', 'Duraci�n desconocida', 'Descripci�n para Duraci�n desconocida');

--DOSIS_PENICILINA_BENZATINICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('DOSIS_PENICILINA_BENZATINICA', 'Primera dosis', 'Descripci�n para Primera dosis'),
    ('DOSIS_PENICILINA_BENZATINICA', 'Segunda dosis', 'Descripci�n para Segunda dosis'),
    ('DOSIS_PENICILINA_BENZATINICA', 'Tercera dosis', 'Descripci�n para Tercera dosis');

--MANEJO_RESULTADO_SIFILIS_GESTACIONAL
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MANEJO_RESULTADO_SIFILIS', 'Adecuado', 'Descripci�n para Adecuado'),
    ('MANEJO_RESULTADO_SIFILIS', 'Inadecuado', 'Descripci�n para Inadecuado');

--CAUSA_RETRATAMIENTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CAUSA_RETRATAMIENTO', 'Tratamiento inadecuado', 'Descripci�n para Tratamiento inadecuado'),
    ('CAUSA_RETRATAMIENTO', 'Reinfecci�n', 'Descripci�n para Reinfecci�n');

--CRITERIO_UTILIZADO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CRITERIO_UTILIZADO', 'Nexo epidemiol�gico', 'Descripci�n para Nexo epidemiol�gico'),
    ('CRITERIO_UTILIZADO', 'Criterio serol�gico', 'Descripci�n para Criterio serol�gico'),
    ('CRITERIO_UTILIZADO', 'Criterio cl�nico', 'Descripci�n para Criterio cl�nico'),
    ('CRITERIO_UTILIZADO', 'Diagn�stico directo', 'Descripci�n para Diagn�stico directo'),
    ('CRITERIO_UTILIZADO', 'Criterio paracl�nico', 'Descripci�n para Criterio paracl�nico');

--MOMENTO_DIAGNOSTICO_CHAGAS
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Embarazo', 'Embarazo: Descripci�n de Embarazo'),
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Parto', 'Parto: Descripci�n de Parto'),
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Puerperio', 'Puerperio: Descripci�n de Puerperio');

--NUFURTIMOX_CONTROL_MEDICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('NUFURTIMOX_CONTROL_MEDICO', 'D�a 10', 'D�a 10: Descripci�n de D�a 10'),
    ('NUFURTIMOX_CONTROL_MEDICO', 'D�a 30', 'D�a 30: Descripci�n de D�a 30'),
    ('NUFURTIMOX_CONTROL_MEDICO', 'D�a 60', 'D�a 60: Descripci�n de D�a 60');

--BENZNIDAZOL_CONTROL_MEDICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('BENZNIDAZOL_CONTROL_MEDICO', 'D�a 10', 'D�a 10: Descripci�n de D�a 10'),
    ('BENZNIDAZOL_CONTROL_MEDICO', 'D�a 30', 'D�a 30: Descripci�n de D�a 30'),
    ('BENZNIDAZOL_CONTROL_MEDICO', 'D�a 60', 'D�a 60: Descripci�n de D�a 60');

--INSERT INTO Parametrica (Nombre, Valor, Descripcion)
--VALUES 
--    ('PRUEBA_SEROLOGICA', 'Antigenos totales', 'Antigenos totales: Descripci�n de Antigenos totales'),
--    ('PRUEBA_SEROLOGICA', 'Antigenos recombinantes', 'Antigenos recombinantes: Descripci�n de Antigenos recombinantes')
