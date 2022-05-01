Imports StatisticsObject
Public Interface IDataDowload

    Function GetVaccinationStatByCountyRaw() As Task(Of CStatList)

    Function GetVaccinationStatByAgeGroupRaw() As Task(Of CStatList)

    Function GetVaccinationStatGeneralRaw() As Task(Of CStatList)

    Function GetTestStatPositiveGeneralRaw() As Task(Of CStatList)

    Function GetTestStatCountyRaw() As Task(Of CStatList)

    Function GetTestStatByAverageAgeRaw() As Task(Of CStatList)

    Function GetHospitalizationAveragePatientAgeCurrentRaw() As Task(Of CStatList)

    Function GetHospitalizationPatientInfoCurrentRaw() As Task(Of CStatList)

    Function GetAverageHospitalizationTimeRaw() As Task(Of CStatList)

    Function GetHospitalizationPatientsRaw() As Task(Of CStatList)

    Function GetDeceasedRaw() As Task(Of CStatList)

    Function GetSickRaw() As Task(Of CStatList)

End Interface
