-- create user operation
print '%Create user operation%'
go

DECLARE @GlobalAdminRole bigint
DECLARE @ControllingRole bigint
DECLARE @CountryAdminRole bigint
DECLARE @RegionAdminRole bigint
DECLARE @StoreAdminRole  bigint

DECLARE @FullAccess int
DECLARE @ReadWriteAccess int
DECLARE @ReadAccess int
DECLARE @WriteAccess int
DECLARE @ImportAccess int
DECLARE @ReadWrite int

DECLARE @UserSvc bigint
DECLARE @CountrySvc bigint
DECLARE @LanguageSvc bigint
DECLARE @RegionSvc bigint
DECLARE @StoreSvc bigint
DECLARE @EmployeeSvc bigint
DECLARE @AvgAmountSvc bigint
DECLARE @ColouringSvc bigint
DECLARE @FeastSvc bigint
DECLARE @AbsenceSvc bigint
DECLARE @WorkingModelSvc bigint
DECLARE @YearlyWorkingDaySvc bigint
DECLARE @WorldSvc bigint
DECLARE @HwgrSvc bigint
DECLARE @WgrSvc bigint
DECLARE @StoreWorkingTimeSvc bigint
DECLARE @BufferHoursSvc bigint
DECLARE @BenchmarkSvc bigint
DECLARE @TrendCorrectionSvc bigint
DECLARE @StoreToWorldSvc bigint
DECLARE @WorldToHwgrSvc bigint
DECLARE @HwgrToWgrSvc bigint
DECLARE @UserRoleSvc bigint
DECLARE @EmployeeRelationSvc bigint
DECLARE @EmployeeContractSvc bigint
DECLARE @LongTimeAbsenceSvc bigint
DECLARE @EmployeeLongTimeAbsenceSvc bigint
DECLARE @PersonMinMaxSvc bigint
DECLARE @WorkingTimePlanningSvc bigint
DECLARE @AbsenceTimePlanningSvc bigint
DECLARE @AbsenceTimeRecordingSvc bigint
DECLARE @WorkingTimeRecordingSvc bigint
DECLARE @EmployeeTimeSvc bigint
DECLARE @AvgWorkingDaysInWeekSvc bigint
DECLARE @EmployeeDayStatePlanningSvc bigint
DECLARE @EmployeeDayStateRecordingSvc bigint
DECLARE @EmployeeWeekTimePlanningSvc bigint
DECLARE @EmployeeWeekTimeRecordingSvc bigint
DECLARE @EmployeePlanningWorkingModelSvc bigint
DECLARE @EmployeeRecordingWorkingModelService bigint
DECLARE @CountryAdditionalHourSvc bigint
DECLARE @StoreAdditionalHourSvc bigint
DECLARE @EmployeeHolidaysInfoSvc bigint
DECLARE @BufferHourAvailableSvc bigint
DECLARE @EmployeeAllInSvc bigint

SET @GlobalAdminRole = 50
SET @ControllingRole = 51
SET @CountryAdminRole = 52
SET @RegionAdminRole = 53
SET @StoreAdminRole  = 54 

SET @ReadAccess = 1
SET @WriteAccess = 2
SET @ImportAccess  = 4
SET @FullAccess  = @ReadAccess + @WriteAccess + @ImportAccess
SET @ReadWriteAccess = @ReadAccess + @WriteAccess

SET @UserSvc = 1
SET @CountrySvc = 2
SET @LanguageSvc = 3
SET @RegionSvc = 4
SET @StoreSvc = 5
SET @EmployeeSvc = 6
SET @AvgAmountSvc = 8
SET @ColouringSvc = 9
SET @FeastSvc = 10
SET @AbsenceSvc = 11
SET @WorkingModelSvc = 12
SET @YearlyWorkingDaySvc = 13
SET @WorldSvc = 14
SET @HwgrSvc = 15
SET @WgrSvc = 16
SET @StoreWorkingTimeSvc = 17
SET @BufferHoursSvc = 18
SET @BenchmarkSvc = 19
SET @TrendCorrectionSvc = 20
SET @StoreToWorldSvc = 21
SET @WorldToHwgrSvc = 22
SET @HwgrToWgrSvc = 23
SET @UserRoleSvc = 24
SET @EmployeeRelationSvc = 25
SET @EmployeeContractSvc = 26
SET @LongTimeAbsenceSvc = 27
SET @EmployeeLongTimeAbsenceSvc = 28
SET @PersonMinMaxSvc = 29
SET @WorkingTimePlanningSvc = 30
SET @AbsenceTimePlanningSvc = 31
SET @AbsenceTimeRecordingSvc = 32
SET @WorkingTimeRecordingSvc = 33
SET @EmployeeTimeSvc = 34
SET @AvgWorkingDaysInWeekSvc = 35
SET @EmployeeDayStatePlanningSvc = 36
SET @EmployeeDayStateRecordingSvc = 37
SET @EmployeeWeekTimePlanningSvc = 38
SET @EmployeeWeekTimeRecordingSvc = 39
SET @EmployeePlanningWorkingModelSvc = 40
SET @CountryAdditionalHourSvc = 41
SET @EmployeeRecordingWorkingModelService = 42
SET @StoreAdditionalHourSvc = 43
SET @EmployeeHolidaysInfoSvc = 44
SET @BufferHourAvailableSvc = 45
SET @EmployeeAllInSvc = 46

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeWeekTimePlanningSvc,'{3DB78DC8-D7CE-4b92-8EA3-CBDA6FBF2A45}','EmployeeWeekTimePlanning Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeRecordingWorkingModelService,'{42BBA523-3E77-42d4-B9BC-89087BF4B514}','EmployeeRecordingWorkingModel Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeWeekTimeRecordingSvc,'{67E591C1-0028-4d8c-A27B-3B3553831FB8}','EmployeeWeekTimeRecording Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeePlanningWorkingModelSvc,'{CEF42569-7F43-4389-B0AA-A59B460B9E21}','EmployeePlanningWorkingModel Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeDayStatePlanningSvc,'{6DE0208A-058C-430a-BF5D-5B9229DFE073}','EmployeeDayStatePlanning Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeDayStateRecordingSvc,'{0EDD7D68-A2E3-4f41-8DED-FFFA3D4422D7}','EmployeeDayStateRecording Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@AvgWorkingDaysInWeekSvc,'{E8D0B971-2D2A-40a7-B97D-DFE1388C7A99}','AvgWorkingDaysInWeek Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WorkingTimePlanningSvc,'{449877F0-0536-452f-8A5A-333F6F95728A}','WorkingTimePlanning Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@AbsenceTimePlanningSvc,'{754ECD10-F7D2-43b3-A907-F94463721600}','AbsenceTimePlanning Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@AbsenceTimeRecordingSvc,'{8732D076-D742-4fe1-B63D-14E2EFE60DA2}','AbsenceTimeRecording Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WorkingTimeRecordingSvc,'{05C6E37B-F1FB-46b0-93C7-7252143B89BB}','WorkingTimeRecordin Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@UserSvc,'{8D8053A1-AFA8-4086-8530-B8CCFECC25EA}','User Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@CountrySvc,'{5F6D8376-3313-4500-835B-72ABFCE87D65}','Country Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@LanguageSvc,'{5F58A713-C043-4c94-8613-AE9789A872AE}','Language Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@RegionSvc,'{ACCE3AFC-9A36-4c11-A447-6FA7E9A3DF69}','Region Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@StoreSvc,'{3CDC01E1-ADC1-4efe-84F2-92D47A4AEA29}','Store Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@PersonMinMaxSvc,'{D01247A6-DED0-49ed-B5C9-181BAB48F3A8}','PersonMinMax Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeSvc,'{EC1DD1C0-EECC-4944-A669-2BB63C8E5463}','Employee Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeRelationSvc,'{8EAA3C3F-7BFA-419e-88F4-547FFD04E4D3}','Employee Relation Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeAllInSvc,'{8287B74B-1B8C-4e07-A0D7-93E791559DBA}','Employee AllIn Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeContractSvc,'{898FDFC8-86A8-464b-8E2C-1D12A463AFC2}','Employee Contract Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@LongTimeAbsenceSvc,'{F6903242-8334-4aeb-B5BB-6CBDFCB64664}','Long Time Absence Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeLongTimeAbsenceSvc,'{58F50F16-3E32-48b1-A963-EE419608512E}','Long Time Absence Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@AvgAmountSvc,'{E40B63B9-6584-45a2-88C0-0B651B502003}','AvgAmount Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@CountryAdditionalHourSvc,'{644B1872-49EC-48f6-8A39-D2F85E62CEF2}','Country Additional Hours Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@ColouringSvc,'{71913269-F37B-49ac-AD2B-C80FB1773815}','Colouring Management')

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@FeastSvc,'{86DE68FA-6EC6-4b6f-8285-55A96C7886C3}','Feast Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@AbsenceSvc,'{9A8754BB-760E-493b-A7F1-291824EAED5D}','Absence Management')    

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WorkingModelSvc,'{55E4F21C-6283-4913-82D6-81FB0391979C}','Working Model Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@YearlyWorkingDaySvc,'{1D8E192F-67F6-4390-A05D-4FAE7BFAFDC5}','Yearly Working Day Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WorldSvc,'{DBC4BD8F-036E-408f-91B2-83B8FD3E29BC}','World Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@HwgrSvc,'{39001C13-55A7-44b9-B03B-788E697713CC}','HWGR Management')           

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WgrSvc,'{CD575B72-D3A4-4931-824B-A9E5B5618259}','WGR Management')           

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@StoreWorkingTimeSvc,'{0A3593D6-8618-45ad-9574-36FD8EA2F54A}','Store Working Time Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@StoreAdditionalHourSvc,'{1A4FEB0E-231D-4106-9AEB-E24C7ED4BE04}','Store Additional Hours Management')           

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@BufferHoursSvc,'{F97F427C-0355-43ca-AD07-911F516217A3}','Buffer Hours Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@BufferHourAvailableSvc,'{B5F3DCDD-0F1B-4010-B610-D97282A0922B}','Buffer Hour Available Management')           

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@BenchmarkSvc,'{8C287495-43F0-4d64-8958-D495F53BF150}','Benchmark Management')           

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@TrendCorrectionSvc,'{0C5825D0-073B-45f2-BC81-D11EC8119409}','Trend Correction Management')           
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@StoreToWorldSvc,'{6A0AD725-9A41-4ff4-9C6F-AA233531EFCD}','StoreToWorld Management')         

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@WorldToHwgrSvc,'{26724DF1-D6BF-443f-841E-BA0141C2ADE4}','World To HWGR Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@HwgrToWgrSvc,'0CFBEEBA-EB71-4b87-AF2F-E98CBAF7F9E5','HWGR To WGR Management')                      

INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@UserRoleSvc,'5F61F016-3E30-45e4-ACC5-BA9D80437540','User Roles Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeHolidaysInfoSvc,'{16EE5443-DC27-4c55-A0A8-7D6A1FF2C5E7}','Employee Holiday Info Management')
           
INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeTimeSvc,'{292D9942-DA73-408a-B01C-50D342AC3810}','Employee Time Management')

--create user role
print '%Create user role%'

INSERT INTO [UserRole]
           ([UserRoleID])
     VALUES
           (@GlobalAdminRole)
           
INSERT INTO [UserRoleName]
           ([Id],[UserRoleID],[LanguageID],[Name])
     VALUES
           (60, @GlobalAdminRole, 1, 'Zentrale Administration')
           
INSERT INTO [UserRole]
           ([UserRoleID])
     VALUES
           (@ControllingRole)
           
INSERT INTO [UserRoleName]
           ([Id],[UserRoleID],[LanguageID],[Name])
     VALUES
           (61, @ControllingRole, 1, 'Controlling')           
           
INSERT INTO [UserRole]
           ([UserRoleID])
     VALUES
           (@CountryAdminRole)
           
INSERT INTO [UserRoleName]
           ([Id],[UserRoleID],[LanguageID],[Name])
     VALUES
           (62, @CountryAdminRole, 1, 'Vertriebslinien Administration')           
           
INSERT INTO [UserRole]
           ([UserRoleID])
     VALUES
           (@RegionAdminRole)
           
INSERT INTO [UserRoleName]
           ([Id],[UserRoleID],[LanguageID],[Name])
     VALUES
           (63, @RegionAdminRole, 1, 'Regionen Administration')                      
           
INSERT INTO [UserRole]
           ([UserRoleID])
     VALUES
           (@StoreAdminRole)
           
INSERT INTO [UserRoleName]
           ([Id],[UserRoleID],[LanguageID],[Name])
     VALUES
           (64, @StoreAdminRole, 1, 'Markt Administration')           
           
--connect user role & operations           
print '%Connect user role and operations%'

---global administration role
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeWeekTimePlanningSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeRecordingWorkingModelService, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeWeekTimeRecordingSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeePlanningWorkingModelSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeDayStatePlanningSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeDayStateRecordingSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @AvgWorkingDaysInWeekSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WorkingTimePlanningSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @AbsenceTimePlanningSvc , @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @AbsenceTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WorkingTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @UserSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @CountrySvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @LanguageSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @RegionSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @StoreSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeRelationSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeAllInSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeContractSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @LongTimeAbsenceSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeLongTimeAbsenceSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @PersonMinMaxSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @AvgAmountSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @CountryAdditionalHourSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @ColouringSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @FeastSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @AbsenceSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WorkingModelSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @YearlyWorkingDaySvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WorldSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @HwgrSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WgrSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @StoreWorkingTimeSvc, @FullAccess)             

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @StoreAdditionalHourSvc, @FullAccess)             

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @BufferHoursSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @BufferHourAvailableSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @BenchmarkSvc, @FullAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @TrendCorrectionSvc, @FullAccess)                        
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @StoreToWorldSvc, @FullAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @WorldToHwgrSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @HwgrToWgrSvc, @FullAccess)                         
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeTimeSvc, @FullAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeHolidaysInfoSvc, @FullAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @UserRoleSvc, @ReadAccess)
                   
-- controlling role
-- insert here analitics service. or something else?                   
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeWeekTimePlanningSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeRecordingWorkingModelService, @ReadAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeWeekTimeRecordingSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeePlanningWorkingModelSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeDayStatePlanningSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeDayStateRecordingSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @AvgWorkingDaysInWeekSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WorkingTimePlanningSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @AbsenceTimePlanningSvc , @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @AbsenceTimeRecordingSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WorkingTimeRecordingSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @UserSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @CountrySvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @LanguageSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @RegionSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @StoreSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeRelationSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeAllInSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeContractSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @LongTimeAbsenceSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeLongTimeAbsenceSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @PersonMinMaxSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @AvgAmountSvc, @ReadAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @CountryAdditionalHourSvc, @ReadAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @ColouringSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @FeastSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @AbsenceSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WorkingModelSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @YearlyWorkingDaySvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WorldSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @HwgrSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WgrSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @StoreWorkingTimeSvc, @ReadAccess)             
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @StoreAdditionalHourSvc, @ReadAccess)             

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @BufferHoursSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @BufferHourAvailableSvc, @ReadAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @BenchmarkSvc, @ReadAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @TrendCorrectionSvc, @ReadAccess)                        
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @StoreToWorldSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @WorldToHwgrSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @HwgrToWgrSvc, @ReadAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeTimeSvc, @ReadAccess)                         
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeHolidaysInfoSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @UserRoleSvc, @ReadAccess)

--country administration role
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeWeekTimePlanningSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeRecordingWorkingModelService, @ReadWriteAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeWeekTimeRecordingSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeePlanningWorkingModelSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeDayStatePlanningSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeDayStateRecordingSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @AvgWorkingDaysInWeekSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WorkingTimePlanningSvc, @ReadWriteAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @AbsenceTimePlanningSvc , @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @AbsenceTimeRecordingSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WorkingTimeRecordingSvc, @ReadWriteAccess)


INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @UserSvc, @ReadAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @CountrySvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @LanguageSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @RegionSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @StoreSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeRelationSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeContractSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @LongTimeAbsenceSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeLongTimeAbsenceSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @PersonMinMaxSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @AvgAmountSvc, @ReadWriteAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @CountryAdditionalHourSvc, @ReadWriteAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @ColouringSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @FeastSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @AbsenceSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WorkingModelSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @YearlyWorkingDaySvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WorldSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @HwgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @StoreWorkingTimeSvc, @ReadWriteAccess)             
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @StoreAdditionalHourSvc, @ReadWriteAccess)             

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @BufferHoursSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @BufferHourAvailableSvc, @ReadWriteAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @BenchmarkSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @TrendCorrectionSvc, @ReadWriteAccess)                        
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @StoreToWorldSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @WorldToHwgrSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @HwgrToWgrSvc, @ReadWriteAccess)                         
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeTimeSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeHolidaysInfoSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @UserRoleSvc, @ReadAccess)
           
--REGION administration role
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeWeekTimePlanningSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeRecordingWorkingModelService, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeWeekTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeePlanningWorkingModelSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @AvgWorkingDaysInWeekSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeDayStatePlanningSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeDayStateRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WorkingTimePlanningSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @AbsenceTimePlanningSvc , @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @AbsenceTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WorkingTimeRecordingSvc, @FullAccess)


INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @UserSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @CountrySvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @LanguageSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @RegionSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @StoreSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeRelationSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeContractSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @LongTimeAbsenceSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeLongTimeAbsenceSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @PersonMinMaxSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @AvgAmountSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @CountryAdditionalHourSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @ColouringSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @FeastSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @AbsenceSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WorkingModelSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @YearlyWorkingDaySvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WorldSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @HwgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @StoreWorkingTimeSvc, @ReadWriteAccess)             
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @StoreAdditionalHourSvc, @ReadWriteAccess)             

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @BufferHoursSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @BufferHourAvailableSvc, @ReadWriteAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @BenchmarkSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @TrendCorrectionSvc, @ReadWriteAccess)                        
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @StoreToWorldSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @WorldToHwgrSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @HwgrToWgrSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeTimeSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeHolidaysInfoSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @UserRoleSvc, @ReadAccess)

--STORE administration role
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeWeekTimePlanningSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeRecordingWorkingModelService, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeWeekTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeePlanningWorkingModelSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @AvgWorkingDaysInWeekSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeDayStatePlanningSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeDayStateRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WorkingTimePlanningSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @AbsenceTimePlanningSvc , @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @AbsenceTimeRecordingSvc, @FullAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WorkingTimeRecordingSvc, @FullAccess)


INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @UserSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @CountrySvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @LanguageSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @RegionSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @StoreSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeRelationSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeContractSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @LongTimeAbsenceSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeLongTimeAbsenceSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @PersonMinMaxSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @AvgAmountSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @CountryAdditionalHourSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @ColouringSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @FeastSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @AbsenceSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WorkingModelSvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @YearlyWorkingDaySvc, @ReadAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WorldSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @HwgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @StoreWorkingTimeSvc, @ReadWriteAccess)             
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @StoreAdditionalHourSvc, @ReadWriteAccess)             
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @BufferHoursSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @BufferHourAvailableSvc, @ReadWriteAccess)           

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @BenchmarkSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @TrendCorrectionSvc, @ReadWriteAccess)                        
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @StoreToWorldSvc, @ReadWriteAccess)
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @WorldToHwgrSvc, @ReadWriteAccess)

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @HwgrToWgrSvc, @ReadWriteAccess)           
           
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeTimeSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeHolidaysInfoSvc, @ReadWriteAccess)                         

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @UserRoleSvc, @ReadAccess)           
                                                       
--create users           
print '%Create users%'

INSERT INTO [User]
           ([Id]
		   ,[EmployeeID]
           ,[LoginName]
           ,[Password]
           ,[UserRoleID]
           ,[LanguageID]
           ,[Active]
           ,[Salt])
     VALUES
           (71
		   ,NULL
           ,'admin'
           ,'LJ+gNFK01Dm++odWogQ8pw=='
           ,@GlobalAdminRole
           ,NULL
           ,1
           ,-1141632335)
           
INSERT INTO [User]
           ([Id]
		   ,[EmployeeID]
           ,[LoginName]
           ,[Password]
           ,[UserRoleID]
           ,[LanguageID]
           ,[Active]
           ,[Salt]
           ,[ShouldChangePassword])
     VALUES
           (72
		   ,NULL
           ,'scheduler'
           ,'JZXlCiGxTy0RAzl8kia0Ng=='
           ,@GlobalAdminRole
           ,NULL
           ,1
           ,-1905021473
           ,0)
                      
           
GO

INSERT INTO [dbo].[PKGen]
           ([DomainName]
           ,[Value])
     VALUES
           ('Entities'
           ,1000)
GO
