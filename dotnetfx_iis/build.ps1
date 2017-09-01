$tag = "1.1"

Write-Host "building Web Image"
docker build -f ./src/Dockerfile.Web -t broyal/samplefxapp-web:$tag ./src/

Write-Host "building Windows Auth Image"
docker build -f ./src/Dockerfile.WindowsAuth -t broyal/samplefxapp-web-winauth:$tag ./src/

Write-Host "building Api Project"
docker build -f ./src/Dockerfile.Api -t broyal/samplefxapp-api:$tag ./src/

