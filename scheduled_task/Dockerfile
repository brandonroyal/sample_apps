FROM microsoft/windowsservercore:latest
MAINTAINER Brandon Royal <broyal@docker.com>  
SHELL ["powershell", "-command"] 

COPY scripts /

RUN .\CreateScheduledTask.ps1

CMD Start-Sleep -Seconds 100000