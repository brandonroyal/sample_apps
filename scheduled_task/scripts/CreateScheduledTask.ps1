$TaskName = "MyScheduledTask"
$TaskCommand = "c:\windows\system32\WindowsPowerShell\v1.0\powershell.exe"
$TaskScript = "C:\Task.ps1"
$TaskArg = "-WindowStyle Hidden -NonInteractive -Executionpolicy unrestricted -file $TaskScript"
$TaskStartTime = [datetime]::Now.AddMinutes(1) 

$TaskAction = New-ScheduledTaskAction -Execute "$TaskCommand" -Argument "$TaskArg" 
$TaskTrigger = New-ScheduledTaskTrigger -At $TaskStartTime -Once
Register-ScheduledTask -Action $TaskAction -Trigger $Tasktrigger -TaskName "$TaskName" -User "System" -RunLevel Highest