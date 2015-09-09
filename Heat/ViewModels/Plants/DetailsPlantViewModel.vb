Namespace ViewModels.Plants

    ''' <summary>
    ''' Modello per la vista Details per un impianto. I dati da presentare sono molti quindi vengono suddivisi in tab.
    ''' Il modello è strutturato con un sub-modello per ogni tab.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class DetailsPlantViewModel

        Property IdentifyViewModel As DetailsIdentifyPlantViewModel
        Property ThermalViewModel As DetailsThermalPlantViewModel
        Property ContactViewModel As DetailsContactPlantViewModel

    End Class

End Namespace
