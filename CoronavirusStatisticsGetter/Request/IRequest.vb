Public Interface IRequest
    Function GetVaccinationStatByCounty() As CStatList

    Function GetVaccinationStatByAgeGroup() As CStatList

    Function GetVaccinationStatGeneral() As CStatList

    Function GetTestStatPositiveGeneral() As CStatList

    Function GetTestStatCounty(Optional countyName As String = "all",
                               Optional positiveOnly As Boolean = True) As CStatList

    Function GetTestStatByAverageAge(Optional positiveOnly As Boolean = True) As CStatList

    Function GetHospitalizationAveragePatientAgeCurrent() As CStatList

    Function GetHospitalizationPatientInfoCurrent() As CStatList

    Function GetAverageHospitalizationTime() As CStatList

    Function GetHospitalizationPatients() As CStatList

    Function GetDeceased(Optional accumulative As Boolean = False) As CStatList

    Function GetSick(Optional period As Integer = 14) As CStatList

    Function GetSickCounty(Optional period As Integer = 14,
                           Optional aimCounty As String = Nothing) As CStatList

End Interface
