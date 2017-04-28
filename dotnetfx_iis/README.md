# .NET Framework // IIS

## Minimum Requirements
* Docker 17.05
* Windows Server 2016 w/ KB4015217 installed
* 2+ nodes deployed in swarm cluster

## Configuration #1: Windows Auth
_Requires deployment on Windows domain joined nodes with Windows Server 2012 R2 or higher domain controller_

1) Deploy Service

Using host mode
```
$ docker service create --name test --hostname myapplication.mta.lab -p mode=host,target=80,published=80 --credential-spec "file://myapplication.json" broyal/test-winauth-web:latest
```
_or_

Using HTTP Routing Mesh (HRM)
```
$ docker service create --name test --hostname myapplication.mta.lab --network ucp-hrm --label com.docker.ucp.mesh.http.80='external_route=http://myapplication.mta.lab,internal_port=80' --credential-spec "file://myapplication.json" broyal/test-winauth-web:latest
```

## Configuration #2: Multiple Services (Host Mode Networking)

1) Download docker-compose.yml file
```
# Windows Client
> iwr -UseBasicParsing -Uri https://github.com/BrandonRoyal/sample_apps/blob/master/dotnetfx_iis/docker-compose.yml -OutFile docker-compose.yml

# macOS/Linux Client
$ wget https://github.com/BrandonRoyal/sample_apps/blob/master/dotnetfx_iis/docker-compose.yml
```

2) Deploy stack from manager node
```
$ docker stack deploy -c docker-compose.yml teststack
```

# Configuration #3: Multiple Services (Http Routing Mesh Networking)

1) Create `ucp-hrm` network from manager node (required to override default encyption which currently isn't supported on Windows)
```
$ docker network create --label com.docker.ucp.mesh.http=true --driver overlay ucp-hrm
```
2) In UCP UI, enable HTTP Routing Mesh (Admin Settings >> Routing Mesh)

![image](https://cloud.githubusercontent.com/assets/2762697/25358303/ce1c037e-28f5-11e7-95da-e22f0921df68.png)

3) Download docker-compose.yml file
```
# Windows Client
> iwr -UseBasicParsing -Uri https://github.com/BrandonRoyal/sample_apps/blob/master/dotnetfx_iis/docker-compose.hrm.yml -OutFile docker-compose.hrm.yml

# macOS/Linux Client
$ wget https://github.com/BrandonRoyal/sample_apps/blob/master/dotnetfx_iis/docker-compose.hrm.yml
```

4) Open docker-compose.hrm.yml file in text editor
Change `app.example.com` to fully qualified hostname that resolve to the node(s) on which your HRM service is deployed

5) Deploy stack from manager node
```
$ docker stack deploy -c docker-compose.yml teststack
```