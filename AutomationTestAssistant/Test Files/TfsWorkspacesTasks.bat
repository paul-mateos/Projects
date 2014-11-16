"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" "D:\AutomationTestHelper\TfsOperations.proj" /t:DeleteWorkspace /p:WorkspaceName="TestProfessionalE"
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" "D:\AutomationTestHelper\TfsOperations.proj" /t:CreateWorkspace /p:WorkspaceName="TestProfessionalE"
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" "D:\AutomationTestHelper\TfsOperations.proj" /t:GetLatest /p:PathToGet="E:\TestProfessional\AutomationTestAssistant\TestEncryption"
"C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\tf.exe" 

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" D:\AutomationTestAssistant\TfsOperations.proj /t:GetLatest /p:PathToGet="E:\TestProjessional\AutomationTestAssistant\TestEncryption" /fl /l:AutomationTestAssistantCore.MsBuildLogger.TcpIpLogger,D:\AutomationTestAssistant\AutomationTestAssistantDesktopApp\bin\Debug\AutomationTestAssistantCore.dll;Ip=127.0.0.1;Port=8889;


tf workspaces /remove:* /collection:http://aangelov-pc:8080/tfs/DefaultCollection

"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" "D:\AutomationTestAssistant\TestTime\TestTime.csproj" /t:rebuild"C:\Windows\Microsoft.NET\Framework\v4.0.30319\MsBuild.exe" "D:\AutomationTestAssistant\TestEncryption\TestEncryption.csproj" /t:rebuild
