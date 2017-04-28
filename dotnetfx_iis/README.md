# Sample Windows Apps

## Windows Auth
_Requires deployment on Windows domain joined nodes with Windows Server 2012 R2 or higher domain controller_

1) Create Global Managed Service Account (gMSA)
```
> New-ADServiceAccount -name test -DnsHostName test.mta.lab  -ServicePrincipalNames http/test.mta.lab -PrincipalsAllowedToRetrieveManagedPassword containerhostsv3c
```

2) Deploy Service (using host mode)
```
$ docker service create --name test --hostname myapplication.mta.lab -p mode=host,target=80,published=80 --credential-spec "file://myapplication.json" broyal/test-winauth-web:latest
```

3) Deploy Service (using HRM)
```
$ docker service create --name test --hostname myapplication.mta.lab --network ucp-hrm --label com.docker.ucp.mesh.http.80='external_route=http://myapplication.mta.lab,internal_port=80' --credential-spec "file://myapplication.json" broyal/test-winauth-web:latest
```