$tag = "1.0"

Write-Host "publishing Web Image"
docker push broyal/samplefxapp-web:$tag

Write-Host "publishing Windows Auth Image"
docker push broyal/samplefxapp-web-winauth:$tag

Write-Host "publishing Api Project"
docker push broyal/samplefxapp-api:$tag