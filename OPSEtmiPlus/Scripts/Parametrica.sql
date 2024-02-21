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
    ('TIPO_DOCUMENTO', 'MS', 'MS: Menor sin identificación'),
    ('TIPO_DOCUMENTO', 'AS', 'AS: Adulto sin identificación'),
    ('TIPO_DOCUMENTO', 'CC', 'CC: Cédula ciudadanía'),
    ('TIPO_DOCUMENTO', 'PA', 'PA: Pasaporte'),
    ('TIPO_DOCUMENTO', 'SV', 'SV: Salvoconducto'),
    ('TIPO_DOCUMENTO', 'PE', 'PE: Permiso Especial de Permanencia'),
    ('TIPO_DOCUMENTO', 'CE', 'CE: Cédula de extranjería');

-- REGIMEN_SALUD
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('REGIMEN_SALUD', 'Excepción', 'Excepción: Descripción de Excepción'),
    ('REGIMEN_SALUD', 'Contributivo', 'Contributivo: Descripción de Contributivo'),
    ('REGIMEN_SALUD', 'Subsidiado', 'Subsidiado: Descripción de Subsidiado'),
    ('REGIMEN_SALUD', 'Especial', 'Especial: Descripción de Especial'),
    ('REGIMEN_SALUD', 'No asegurado', 'No asegurado: Descripción de No asegurado');

--PERTENENCIA_ETNICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PERTENENCIA_ETNICA', 'Palenquera', 'Palenquera: Descripción de Palenquera'),
    ('PERTENENCIA_ETNICA', 'Afrocolombiana', 'Afrocolombiana: Descripción de Afrocolombiana'),
    ('PERTENENCIA_ETNICA', 'Indígena', 'Indígena: Descripción de Indígena'),
    ('PERTENENCIA_ETNICA', 'Rom', 'Rom: Descripción de Rom'),
    ('PERTENENCIA_ETNICA', 'Otro', 'Otro: Descripción de Otro'),
    ('PERTENENCIA_ETNICA', 'Raizal (del Archipiélago de San Andrés y Providencia)', 'Raizal: Descripción de Raizal (del Archipiélago de San Andrés y Providencia)');

--GRUPO_POBLACIONAL
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GRUPO_POBLACIONAL', 'Migrante', 'Migrante: Descripción de Migrante'),
    ('GRUPO_POBLACIONAL', 'Desplazada', 'Desplazada: Descripción de Desplazada'),
    ('GRUPO_POBLACIONAL', 'Carcelaria', 'Carcelaria: Descripción de Carcelaria'),
    ('GRUPO_POBLACIONAL', 'Otros grupos', 'Otros grupos: Descripción de Otros grupos'),
    ('GRUPO_POBLACIONAL', 'Habitante de calle', 'Habitante de calle: Descripción de Habitante de calle'),
    ('GRUPO_POBLACIONAL', 'Discapacitada', 'Discapacitada: Descripción de Discapacitada'),
    ('GRUPO_POBLACIONAL', 'Centro psiquiátrico', 'Centro psiquiátrico: Descripción de Centro psiquiátrico'),
    ('GRUPO_POBLACIONAL', 'Víctima de violencia armada', 'Víctima de violencia armada: Descripción de Víctima de violencia armada');

--AREA_OCURRENCIA_CASO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('AREA_OCURRENCIA_CASO', 'Cabecera municipal', 'Cabecera municipal: Descripción de Cabecera municipal'),
    ('AREA_OCURRENCIA_CASO', 'Centro poblado', 'Centro poblado: Descripción de Centro poblado'),
    ('AREA_OCURRENCIA_CASO', 'Rural disperso', 'Rural disperso: Descripción de Rural disperso');

--MOMENTO_DIAGNOSTICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MOMENTO_DIAGNOSTICO', 'Antes del embarazo actual', 'Antes del embarazo actual: Descripción de Antes del embarazo actual'),
    ('MOMENTO_DIAGNOSTICO', 'Durante el embarazo actual', 'Durante el embarazo actual: Descripción de Durante el embarazo actual'),
    ('MOMENTO_DIAGNOSTICO', 'Posterior al parto', 'Posterior al parto: Descripción de Posterior al parto');

--PRUEBA_DIAGNOSTICO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PRUEBA_DIAGNOSTICO_VIH', 'Carga viral', 'Carga viral: Descripción de Carga viral'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Western Blot', 'Western Blot: Descripción de Western Blot'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Prueba rápida', 'Prueba rápida: Descripción de Prueba rápida'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'ELISA', 'ELISA: Descripción de ELISA'),
    ('PRUEBA_DIAGNOSTICO_VIH', 'Quimioluminiscencia', 'Quimioluminiscencia: Descripción de Quimioluminiscencia');

--TIPO_ALIMENTACION_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Fórmula láctea desde el nacimiento - GPC', 'Fórmula láctea desde el nacimiento - GPC: Descripción de Fórmula láctea desde el nacimiento - GPC'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Lactancia materna exclusiva', 'Lactancia materna exclusiva: Descripción de Lactancia materna exclusiva'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentación mixta: lactancia materna + fórmula láctea', 'Alimentación mixta: lactancia materna + fórmula láctea: Descripción de Alimentación mixta: lactancia materna + fórmula láctea'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentación parental', 'Alimentación parental: Descripción de Alimentación parental'),
    ('TIPO_ALIMENTACION_NINO_EXPUESTO', 'Alimentación parental + fórmula láctea', 'Alimentación parental + fórmula láctea: Descripción de Alimentación parental + fórmula láctea');

--RESULTADO_PRUEBA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA', 'Positivo', 'Positivo: Descripción de Positivo'),
    ('RESULTADO_PRUEBA', 'Reactivo', 'Reactivo: Descripción de Reactivo');

--GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'La gestante venía recibiendo TAR para VIH antes de iniciar el embarazo actual', 'La gestante venía recibiendo TAR para VIH antes de iniciar el embarazo actual: Descripción de La gestante venía recibiendo TAR para VIH antes de iniciar el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'Si la respuesta es NO ¿la gestante inicio TAR durante el embarazo actual', 'Si la respuesta es NO ¿la gestante inicio TAR durante el embarazo actual: Descripción de Si la respuesta es NO ¿la gestante inicio TAR durante el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_ANTES_EMBARAZO', 'Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato', 'Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato: Descripción de Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato');

--GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO', 'Recibió TAR para VIH durante el embarazo actual', 'Recibió TAR para VIH durante el embarazo actual: Descripción de Recibió TAR para VIH durante el embarazo actual'),
    ('GESTANTE_DIAGNOSTICO_VIH_DURANTE_EMBARAZO', 'Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato', 'Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato: Descripción de Si la respuesta es SI, a partir de que semana gestacional lo recibió. Registre el dato');

--MEDICAMENTOS_ARV_SUMINISTRADOR
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Lamivudina', 'Lamivudina: Descripción de Lamivudina'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Abacavir', 'Abacavir: Descripción de Abacavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Emtricitabina', 'Emtricitabina: Descripción de Emtricitabina'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Tenofovir disoproxil Fumarato', 'Tenofovir disoproxil Fumarato: Descripción de Tenofovir disoproxil Fumarato'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Efavirez', 'Efavirez: Descripción de Efavirez'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Atazanavir', 'Atazanavir: Descripción de Atazanavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Darunavir', 'Darunavir: Descripción de Darunavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Lopinavir', 'Lopinavir: Descripción de Lopinavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Ritonavir', 'Ritonavir: Descripción de Ritonavir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Raltegravir', 'Raltegravir: Descripción de Raltegravir'),
    ('MEDICAMENTOS_ARV_SUMINISTRADOR', 'Dolutegravir', 'Dolutegravir: Descripción de Dolutegravir');

--MEDICAMENTOS_ARV
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MEDICAMENTOS_ARV', 'Lamivudina', 'Lamivudina: Descripción de Lamivudina'),
    ('MEDICAMENTOS_ARV', 'Abacavir', 'Abacavir: Descripción de Abacavir'),
    ('MEDICAMENTOS_ARV', 'Emtricitabina', 'Emtricitabina: Descripción de Emtricitabina'),
    ('MEDICAMENTOS_ARV', 'Tenofovir disoproxil Fumarato', 'Tenofovir disoproxil Fumarato: Descripción de Tenofovir disoproxil Fumarato'),
    ('MEDICAMENTOS_ARV', 'Efavirez', 'Efavirez: Descripción de Efavirez'),
    ('MEDICAMENTOS_ARV', 'Atazanavir', 'Atazanavir: Descripción de Atazanavir'),
    ('MEDICAMENTOS_ARV', 'Darunavir', 'Darunavir: Descripción de Darunavir'),
    ('MEDICAMENTOS_ARV', 'Lopinavir', 'Lopinavir: Descripción de Lopinavir'),
    ('MEDICAMENTOS_ARV', 'Ritonavir', 'Ritonavir: Descripción de Ritonavir'),
    ('MEDICAMENTOS_ARV', 'Raltegravir', 'Raltegravir: Descripción de Raltegravir'),
    ('MEDICAMENTOS_ARV', 'Dolutegravir', 'Dolutegravir: Descripción de Dolutegravir');

--SITUACION_GESTANTE
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SITUACION_GESTANTE', 'Aborto', 'Aborto: Descripción de Aborto'),
    ('SITUACION_GESTANTE', 'IVE', 'IVE: Descripción de IVE'),
    ('SITUACION_GESTANTE', 'Mortalidad Materna', 'Mortalidad Materna: Descripción de Mortalidad Materna'),
    ('SITUACION_GESTANTE', 'Parto', 'Parto: Descripción de Parto');

--ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO', 'SI', 'SI: Descripción de SI'),
    ('ESQUEMA_ANTIRRETROVIRAL_INTRAPARTO', 'NO', 'NO: Descripción de NO');

--ESQUEMA_ARV_INTRAPARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ESQUEMA_ARV_INTRAPARTO', 'Zidovudina', 'Zidovudina: Descripción de Zidovudina'),
    ('ESQUEMA_ARV_INTRAPARTO', 'Nevirapina', 'Nevirapina: Descripción de Nevirapina');


--CONDICION_RECIEN_NACIDO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CONDICION_RECIEN_NACIDO', 'Vivo', 'Vivo: Descripción de Vivo'),
    ('CONDICION_RECIEN_NACIDO', 'Mortinato', 'Mortinato: Descripción de Mortinato');

--NUMERO_PRODUCTOS_NACIMIENTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('NUMERO_PRODUCTOS_NACIMIENTO', 'Único', 'Único: Descripción de Único'),
    ('NUMERO_PRODUCTOS_NACIMIENTO', 'Múltiple (2 o más recién nacidos)', 'Múltiple (2 o más recién nacidos): Descripción de Múltiple (2 o más recién nacidos)');

--SEXO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SEXO', 'Hombre', 'Hombre: Descripción de Hombre'),
    ('SEXO', 'Mujer', 'Mujer: Descripción de Mujer'),
    ('SEXO', 'Intersexual', 'Intersexual: Descripción de Intersexual');

--TIPO_PARTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PARTO', 'Cesárea', 'Cesárea: Descripción de Cesárea'),
    ('TIPO_PARTO', 'Vaginal', 'Vaginal: Descripción de Vaginal');

--TIPO_REGIMEN_SALUD
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_REGIMEN_SALUD', 'Excepción', 'Excepción: Descripción de Excepción'),
    ('TIPO_REGIMEN_SALUD', 'Contributivo', 'Contributivo: Descripción de Contributivo'),
    ('TIPO_REGIMEN_SALUD', 'Subsidiado', 'Subsidiado: Descripción de Subsidiado'),
    ('TIPO_REGIMEN_SALUD', 'Especial', 'Especial: Descripción de Especial'),
    ('TIPO_REGIMEN_SALUD', 'No asegurado', 'No asegurado: Descripción de No asegurado');

--TIPO_DOCUMENTO_NINO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_DOCUMENTO_NINO', 'RC', 'RC: Registro Civil'),
    ('TIPO_DOCUMENTO_NINO', 'CNV', 'CNV: Certificado de nacido vivo'),
    ('TIPO_DOCUMENTO_NINO', 'MS', 'MS: Menor sin identificación');

--CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO', 'Bajo riesgo', 'Bajo riesgo: Descripción de Bajo riesgo'),
    ('CLASIFICACION_RIESGO_TMI_NINO_EXPUESTO', 'Alto riesgo', 'Alto riesgo: Descripción de Alto riesgo');

--PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Zidovudina por 4 semanas', 'Zidovudina por 4 semanas: Descripción de Zidovudina por 4 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Zidovudina por 6 semanas', 'Zidovudina por 6 semanas: Descripción de Zidovudina por 6 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Lamivudina por 6 semanas', 'Lamivudina por 6 semanas: Descripción de Lamivudina por 6 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Nevirapina por 4 semanas', 'Nevirapina por 4 semanas: Descripción de Nevirapina por 4 semanas'),
    ('PROFILAXIS_ANTIRRETROVIRAL_NINO_EXPUESTO', 'Raltegravir por 6 semanas', 'Raltegravir por 6 semanas: Descripción de Raltegravir por 6 semanas');

--OTRAS_PRUEBAS_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Prueba rápida', 'Prueba rápida: Descripción de Prueba rápida'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'ELISA', 'ELISA: Descripción de ELISA'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Quimioluminiscencia', 'Quimioluminiscencia: Descripción de Quimioluminiscencia'),
    ('OTRAS_PRUEBAS_NINO_EXPUESTO', 'Western Blot', 'Western Blot: Descripción de Western Blot');

--RESULTADO_NINO_EXPUESTO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Reactivo', 'Reactivo: Descripción de Reactivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'No reactivo', 'No reactivo: Descripción de No reactivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Positivo', 'Positivo: Descripción de Positivo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Negativo', 'Negativo: Descripción de Negativo'),
    ('RESULTADO_NINO_EXPUESTO_VIH', 'Indeterminado', 'Indeterminado: Descripción de Indeterminado');

--PARACLINICO_REALIZADO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('PARACLINICO_REALIZADO', 'Carga viral', 'Carga viral: Descripción de Carga viral'),
    ('PARACLINICO_REALIZADO', 'Conteo de linfocitos T CD4', 'Conteo de linfocitos T CD4: Descripción de Conteo de linfocitos T CD4');    

--ALIMENTACION_NINO_EXPUESTO_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Fórmula láctea desde el nacimiento', 'Fórmula láctea desde el nacimiento: Descripción de Fórmula láctea desde el nacimiento'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Lactancia materna exclusiva', 'Lactancia materna exclusiva: Descripción de Lactancia materna exclusiva'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentación mixta: lactancia materna + fórmula láctea', 'Alimentación mixta: lactancia materna + fórmula láctea: Descripción de Alimentación mixta: lactancia materna + fórmula láctea'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentación parenteral', 'Alimentación parenteral: Descripción de Alimentación parenteral'),
    ('ALIMENTACION_NINO_EXPUESTO_VIH', 'Alimentación parenteral + fórmula láctea', 'Alimentación parenteral + fórmula láctea: Descripción de Alimentación parenteral + fórmula láctea');

--SITUACION_NINO_EXPUESTO_REFERENCIA_VIH
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Infección por VIH confirmada', 'Infección por VIH confirmada: Descripción de Infección por VIH confirmada'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Infección por VIH descartada', 'Infección por VIH descartada: Descripción de Infección por VIH descartada'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Falleció sin clasificación', 'Falleció sin clasificación: Descripción de Falleció sin clasificación'),
    ('SITUACION_NINO_EXPUESTO_REFERENCIA_VIH', 'Sin clasificación', 'Sin clasificación: Descripción de Sin clasificación');

--TIEMPO_APLICACION_VACUNA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIEMPO_APLICACION_VACUNA_HB', 'En las primeras 12 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB en las primeras 12 horas'),
    ('TIEMPO_APLICACION_VACUNA_HB', 'Mayor a 12 y hasta 24 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB mayor a 12 y hasta 24 horas'),
    ('TIEMPO_APLICACION_VACUNA_HB', 'Después de 24 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB después de 24 horas');

--APLICACION_VACUNA_CONTRA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('APLICACION_VACUNA_CONTRA_HB', 'Dosis al recién nacido', 'Valor relacionado con la dosis al recién nacido'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Primera dosis', 'Valor relacionado con la primera dosis'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Segunda dosis', 'Valor relacionado con la segunda dosis'),
    ('APLICACION_VACUNA_CONTRA_HB', 'Tercera dosis', 'Valor relacionado con la tercera dosis');

--TIEMPO_APLICACION_INMUNOGLOBULINA_HB
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'En las primeras 12 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB en las primeras 12 horas'),
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'Mayor a 12 y hasta 24 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB mayor a 12 y hasta 24 horas'),
    ('TIEMPO_APLICACION_INMUNOGLOBULINA_HB', 'Después de 24 horas', 'Valor relacionado con el tiempo de aplicación de la vacuna HB después de 24 horas');

--CONDICION_FINAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CONDICION_FINAL_NINO_EXPUESTO', 'Vivo', 'Valor relacionado con la condición final de un niño expuesto que está vivo'),
    ('CONDICION_FINAL_NINO_EXPUESTO', 'Muerto', 'Valor relacionado con la condición final de un niño expuesto que está muerto');

--CLASIFICACION_FINAL_NINO_EXPUESTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Infección por HB confirmada', 'Valor relacionado con la clasificación final de un niño expuesto con infección por HB confirmada'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Infección por HB descartada', 'Valor relacionado con la clasificación final de un niño expuesto con infección por HB descartada'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Falleció sin clasificación', 'Valor relacionado con la clasificación final de un niño expuesto que falleció sin clasificación'),
    ('CLASIFICACION_FINAL_NINO_EXPUESTO', 'Sin clasificación', 'Valor relacionado con la clasificación final de un niño expuesto sin clasificación');

--TIPO_PRUEBA_TRIPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba Rápida', 'Descripción para Prueba Rápida'),
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba TPHA', 'Descripción para Prueba TPHA'),
    ('TIPO_PRUEBA_TREPONEMICA', 'Prueba TPPA', 'Descripción para Prueba TPPA');

--RESULTADO_PRUEBA_TREPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA_TREPONEMICA', 'Reactiva', 'Descripción para Reactiva'),
    ('RESULTADO_PRUEBA_TREPONEMICA', 'No reactiva', 'Descripción para No reactiva');

--TIPO_PRUEBA_NO_TRIPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('TIPO_PRUEBA_NO_TREPONEMICA', 'VDRL', 'Descripción para VDRL'),
    ('TIPO_PRUEBA_NO_TREPONEMICA', 'RPR', 'Descripción para RPR');

--RESULTADO_PRUEBA_NO_TREPONEMICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('RESULTADO_PRUEBA_NO_TREPONEMICA', 'Reactiva', 'Descripción para Reactiva'),
    ('RESULTADO_PRUEBA_NO_TREPONEMICA', 'No reactiva', 'Descripción para No reactiva');

--DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '1', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 1'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '2', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 2'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '4', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 4'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '8', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 8'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '16', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 16'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '32', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 32'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '64', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 64'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '128', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 128'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '256', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 256'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '512', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 512'),
    ('DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA', '1024', 'Descripción para DILUCIONES_PRUEBA_NO_TREPONEMICA_ES_REACTIVA con valor 1024');
    
--CLASIFICACION_ESTADIO_CLINICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CLASIFICACION_ESTADIO_CLINICO', 'Temprana', 'Descripción para Temprana'),
    ('CLASIFICACION_ESTADIO_CLINICO', 'Tardía', 'Descripción para Tardía'),
    ('CLASIFICACION_ESTADIO_CLINICO', 'Duración desconocida', 'Descripción para Duración desconocida');

--DOSIS_PENICILINA_BENZATINICA
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('DOSIS_PENICILINA_BENZATINICA', 'Primera dosis', 'Descripción para Primera dosis'),
    ('DOSIS_PENICILINA_BENZATINICA', 'Segunda dosis', 'Descripción para Segunda dosis'),
    ('DOSIS_PENICILINA_BENZATINICA', 'Tercera dosis', 'Descripción para Tercera dosis');

--MANEJO_RESULTADO_SIFILIS_GESTACIONAL
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MANEJO_RESULTADO_SIFILIS', 'Adecuado', 'Descripción para Adecuado'),
    ('MANEJO_RESULTADO_SIFILIS', 'Inadecuado', 'Descripción para Inadecuado');

--CAUSA_RETRATAMIENTO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CAUSA_RETRATAMIENTO', 'Tratamiento inadecuado', 'Descripción para Tratamiento inadecuado'),
    ('CAUSA_RETRATAMIENTO', 'Reinfección', 'Descripción para Reinfección');

--CRITERIO_UTILIZADO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('CRITERIO_UTILIZADO', 'Nexo epidemiológico', 'Descripción para Nexo epidemiológico'),
    ('CRITERIO_UTILIZADO', 'Criterio serológico', 'Descripción para Criterio serológico'),
    ('CRITERIO_UTILIZADO', 'Criterio clínico', 'Descripción para Criterio clínico'),
    ('CRITERIO_UTILIZADO', 'Diagnóstico directo', 'Descripción para Diagnóstico directo'),
    ('CRITERIO_UTILIZADO', 'Criterio paraclínico', 'Descripción para Criterio paraclínico');

--MOMENTO_DIAGNOSTICO_CHAGAS
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Embarazo', 'Embarazo: Descripción de Embarazo'),
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Parto', 'Parto: Descripción de Parto'),
    ('MOMENTO_DIAGNOSTICO_CHAGAS', 'Puerperio', 'Puerperio: Descripción de Puerperio');

--NUFURTIMOX_CONTROL_MEDICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('NUFURTIMOX_CONTROL_MEDICO', 'Día 10', 'Día 10: Descripción de Día 10'),
    ('NUFURTIMOX_CONTROL_MEDICO', 'Día 30', 'Día 30: Descripción de Día 30'),
    ('NUFURTIMOX_CONTROL_MEDICO', 'Día 60', 'Día 60: Descripción de Día 60');

--BENZNIDAZOL_CONTROL_MEDICO
INSERT INTO Parametrica (Nombre, Valor, Descripcion)
VALUES 
    ('BENZNIDAZOL_CONTROL_MEDICO', 'Día 10', 'Día 10: Descripción de Día 10'),
    ('BENZNIDAZOL_CONTROL_MEDICO', 'Día 30', 'Día 30: Descripción de Día 30'),
    ('BENZNIDAZOL_CONTROL_MEDICO', 'Día 60', 'Día 60: Descripción de Día 60');

--INSERT INTO Parametrica (Nombre, Valor, Descripcion)
--VALUES 
--    ('PRUEBA_SEROLOGICA', 'Antigenos totales', 'Antigenos totales: Descripción de Antigenos totales'),
--    ('PRUEBA_SEROLOGICA', 'Antigenos recombinantes', 'Antigenos recombinantes: Descripción de Antigenos recombinantes')
