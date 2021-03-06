﻿Module modIMU_Checks_v3_3

    Public Sub IMU_Checks_v3_3()

        'This part only check the correct data structure of the data line
        'and prepares the variables ready for the MainAnalysis which
        'is called directly after by this code.

        ' THIS CODE MUST ONLY BE CALLED AFTER THE DATA LINE HAS BEEN VALIDATED AS THE CORRECT TYPE !!!

        ' v3.2 FMT, 131, 31, IMU, Iffffff,    TimeMS, GyrX, GyrY, GyrZ, AccX, AccY, AccZ
        ' v3.3 FMT, 132, 49, IMU, QffffffIIfBB, TimeUS,GyrX,GyrY,GyrZ,AccX,AccY,AccZ,ErrG,ErrA,Temp,GyHlt,AcHlt

        'An IMU value should have only 10 pieces of numeric data!

        If ReadFileResilienceCheck(12) = True Then
            'Debug.Print("IMU Data Detected...")
            Log_IMU_TimeMS = Val(DataArray(1)) / 1000
            Log_IMU_GyrX = Val(DataArray(2))
            Log_IMU_GyrY = Val(DataArray(3))
            Log_IMU_GyrZ = Val(DataArray(4))
            Log_IMU_AccX = Val(DataArray(5))
            Log_IMU_AccY = Val(DataArray(6))
            Log_IMU_AccZ = Val(DataArray(7))
            Call IMU_MainAnalysis()
        End If

    End Sub

End Module
