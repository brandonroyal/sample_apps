Write-Output 'Bootstrap starting'

# copy process-level environment variables (from `docker run`) machine-wide
foreach($key in [System.Environment]::GetEnvironmentVariables('Process').Keys) {
    if ([System.Environment]::GetEnvironmentVariable($key, 'Machine') -eq $null) {
        $value = [System.Environment]::GetEnvironmentVariable($key, 'Process')
        [System.Environment]::SetEnvironmentVariable($key, $value, 'Machine')
        Write-Output "set environment variable: $key"
    }
}

Write-Host "flushing IIS logs"
netsh http flush logbuffer | Out-Null;

Write-Output 'starting w3svc service'
Start-Service w3svc
try 
{
    Write-Host "initialiing website with first request"
    $statusCode = (Invoke-WebRequest -Uri "http://localhost" -UseBasicParsing -TimeoutSec 60).StatusCode
    Write-Host "returned status $statusCode"
} 
catch 
{
    Write-Host "initial request failed"
}
while (!(Test-Path "C:\iislog\W3SVC\u_extend1.log")) 
{
    Write-Host "rechecking iis logs"
    Start-Sleep 10
}
Get-Content -path 'C:\iislog\W3SVC\u_extend1.log' -Tail 1 -Wait 