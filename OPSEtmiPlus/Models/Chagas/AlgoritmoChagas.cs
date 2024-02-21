namespace OPSEtmiPlus.Models.Chagas
{
    public class AlgoritmoChagas
    {
        public int IdAlgoritmo { get; set; }
        public int IdDiagnosticoGestante { get; set; }
        public int SospechaChagasAgudo { get; set; }
        public int IdExamenParasitologico { get; set; }
        public Parametrica? ExamenParasitologico { get; set; }
        public string ResultadoExamenParasitologico { get; set; } = string.Empty;
        public int SospechaChagasCronicoOTamizajeControlPrenatal { get; set; }

        //Algoritmo1 (Serologia para deteccion de anticuerpos totales contra Tripanozoma Cruzi por dos tecnicas de ELISA
        public DateTime FechaRecoleccionMuestraElisaAntigenosTotales { get; set; }
        public DateTime FechaEmisionResultadoElisaAntigenosTotales { get; set; }

        public int ResultadoPruebaTamizajeElisaAntigenosTotales { get; set; }
        public DateTime FechaRecoleccionMuestra { get; set; }
        public DateTime FechaEmisionResultado { get; set; }
        public int ResultadoPruebaTamizajeElisaAntigenosRecombinantes1 { get; set; }
        public DateTime FechaRecoleccionMuestraRecombinantes1 { get; set; }
        public DateTime FechaEmisionResultadoRecombinantes1 { get; set; }

        //Algoritmo2 (Serología con la primera prueba rápida y la segunda ELISA recombinante
        public int ResultadoPruebaTamizajeInmunocromatografia { get; set; }
        public DateTime FechaRecoleccionMuestraInmunocromatografia { get; set; }
        public DateTime FechaEmisionInmunocromatografia { get; set; }
        public int ResultadoPruebaTamizajeElisaAntigenosRecombinantes2 { get; set; }
        public DateTime FechaRecoleccionMuestraRecombinantes2 { get; set; }
        public DateTime FechaEmisionResultadoRecombinantes2 { get; set; }

        //Pruebas no concordantes (tercera para decidir resultado)
        public string TipoPruebaUtilizada { get; set; } = string.Empty;
        public string ResultadoPruebaUtilizada { get; set; } = string.Empty;
        public DateTime FechaRecoleccionMuestraNoConcordante { get; set; }
        public DateTime FechaEmisionNoConcordante { get; set; }
        public int ResultadoPruebaTamizajeElisaAntigenosRecombinantes3 { get; set; }
        public DateTime FechaRecoleccionMuestraRecombinantes3 { get; set; }
        public DateTime FechaEmisionResultadoRecombinantes3 { get; set; }

        //Confirmación
        public int EsConfirmadoGestanteConChagas { get; set; }
        public int EsDescartadoGestanteConChagas { get; set; }
        public int NumeroHijosDiferenteAlEmbarazoParaRealizarDiagnosticoChagas { get; set; }

        public List<TratamientoMaternoChagas>? TratamientosMaternoChagas { get; set; } = [];
    }
}
